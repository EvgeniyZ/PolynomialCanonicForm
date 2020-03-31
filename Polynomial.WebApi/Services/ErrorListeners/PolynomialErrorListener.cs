using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Polynomial.WebApi.Services.ErrorListeners
{
    public class PolynomialErrorListener : BaseErrorListener
    {
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            if (e is InputMismatchException)
            {
                if (offendingSymbol.Text == "<EOF>")
                {
                    throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Missing an expression after '=' sign");
                }

                throw new ParseCanceledException($"{GetSyntaxErrorHeader(++charPositionInLine)}. Missing an expression after {offendingSymbol.Text} sign");
            }

            if (e is NoViableAltException)
            {
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Not closed operator");
            }

            if (msg.StartsWith("extraneous input"))
            {
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(++charPositionInLine)}. Unrecognized character {offendingSymbol.Text}");
            }

            throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. {msg}");
        }

        private static string GetSyntaxErrorHeader(int errorPosition)
        {
            return $"Expression is invalid. Input is not valid at {--errorPosition} position";
        }
    }
}