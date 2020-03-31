using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Polynomial.WebApi.Domain.Entities;
using Polynomial.WebApi.Services.ErrorListeners;

namespace Polynomial.WebApi.Services
{
    public class CanonicalFormer
    {
        public (string canonical, string errorMessage) ToCanonical(string expression)
        {
            var (success, trimmedExpression) = TrimExpressionIfNotEmpty(expression);
            if (!success)
            {
                return (string.Empty, trimmedExpression);
            }

            (IParseTree tree, string parseErrorMessage) = TryParseExpression(trimmedExpression);
            if (string.IsNullOrEmpty(parseErrorMessage))
            {
                PolynomialVisitor polynomialVisitor = new PolynomialVisitor();
                Polynom canonical = polynomialVisitor.Visit(tree);

                return ($"{canonical}", string.Empty);
            }

            return (string.Empty, parseErrorMessage);
        }

        private static (bool success, string trimmedResult) TrimExpressionIfNotEmpty(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return (false, $"{nameof(expression)} is empty");
            }

            string trimmedExpression = expression.Replace(" ", string.Empty);
            if (string.IsNullOrEmpty(trimmedExpression))
            {
                return (false, $"{nameof(expression)} is empty");
            }

            return (true, trimmedExpression);
        }

        private static (IParseTree tree, string parseErrorMessage) TryParseExpression(string expression)
        {
            ICharStream stream = CharStreams.fromstring(expression);
            PolynomialLexer lexer = new PolynomialLexer(stream);

            ITokenStream tokens = new CommonTokenStream(lexer);
            PolynomialParser parser = new PolynomialParser(tokens) {BuildParseTree = true};

            parser.RemoveErrorListeners();
            parser.AddErrorListener(new PolynomialErrorListener());

            try
            {
                var tree = parser.parse();
                return (tree, string.Empty);
            }
            catch (ParseCanceledException pce)
            {
                return (null, pce.Message);
            }
        }
    }
}