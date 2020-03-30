using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Polynomial.WebApi.Domain.Entities;

namespace Polynomial.WebApi.Services
{
    public class CanonicalFormer
    {
        private static readonly Regex AllowedCharactersRegex;

        static CanonicalFormer()
        {
            AllowedCharactersRegex = new Regex("^[0-9A-Za-z+-.=^()]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public (string canonical, string errorMessage) ToCanonical(string expression)
        {
            var (success, trimmedExpression) = TrimExpressionIfNotEmpty(expression);
            if (!success)
            {
                return (string.Empty, trimmedExpression);
            }

            var (anyUnrecognizedCharacter, unrecognizedCharacterErrorMessage) = AnyUnrecognizedCharacter(trimmedExpression);
            if (anyUnrecognizedCharacter)
            {
                return (string.Empty, unrecognizedCharacterErrorMessage);
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

        /// <summary>
        /// A hack with Regexp that checks expression on unrecognized characters.
        /// It should be ANTLR parser responsibility, however it's not working, no clue why.
        /// Raised SO question.
        /// https://stackoverflow.com/questions/60920641/c-sharp-antlr4-defaulterrorstrategy-or-custom-error-listener-does-not-catch-unre
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static (bool isValid, string errorMessage) AnyUnrecognizedCharacter(string expression)
        {
            if (AllowedCharactersRegex.IsMatch(expression))
            {
                return (false, string.Empty);
            }

            return (true, "Expression contains unrecognized characters");
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
                var tree = parser.parse();
                return (tree, string.Empty);
            }
            catch (RecognitionException re)
            {
                return (null, re.Message);
            }
            catch (ParseCanceledException pce)
            {
                return (null, pce.Message);
            }
        }
    }
}