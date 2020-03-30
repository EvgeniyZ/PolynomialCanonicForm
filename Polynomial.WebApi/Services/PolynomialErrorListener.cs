using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Polynomial.WebApi.Services
{
    public class PolynomialErrorListener : BaseErrorListener
    {
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            if (e is InputMismatchException ime)
            {
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Missing an expression after ${ime.OffendingToken.Text} sign");
            }

            if (e is NoViableAltException)
            {
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Probably, not closed operator");
            }

            throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. {msg}");
        }

        private static string GetSyntaxErrorHeader(int errorPosition)
        {
            return $"Expression is invalid. Input is not valid at {--errorPosition} position";
        }
    }
}