﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Polynomial.WebApi.Entities;
using Polynomial.WebApi.Traversing;

namespace Polynomial.WebApi.Services
{
    public class CanonicalFormer
    {
        public (string canonical, string errorMessage) ToCanonical(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return (string.Empty, $"{nameof(expression)} is empty");
            }

            string trimmedExpression = expression.Replace(" ", string.Empty);
            if (string.IsNullOrEmpty(trimmedExpression))
            {
                return (string.Empty, $"{nameof(expression)} is empty");
            }

            (IParseTree tree, string parseErrorMessage) = TryParseExpression(expression);
            if (string.IsNullOrEmpty(parseErrorMessage))
            {
                PolynomialVisitor polynomialVisitor = new PolynomialVisitor();
                Polynom canonical = polynomialVisitor.Visit(tree);

                return (canonical.ToString(), string.Empty);
            }

            return (string.Empty, parseErrorMessage);
        }

        private static (IParseTree tree, string parseErrorMessage) TryParseExpression(string expression)
        {
            ICharStream stream = CharStreams.fromstring(expression);
            ITokenSource lexer = new PolynomialLexer(stream);

            ITokenStream tokens = new CommonTokenStream(lexer);
            PolynomialParser parser = new PolynomialParser(tokens) {BuildParseTree = true};
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new PolynomialErrorListener());

            try
            {
                var tree = parser.canonical();
                return (tree, string.Empty);
            }
            catch (ParseCanceledException pce)
            {
                return (null, pce.Message);
            }
        }
    }
}