using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Polynomial.WebApi.Services
{
    public class PolynomialErrorListener : BaseErrorListener
    {
        private const string Eof = "EOF";

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            if (msg.Contains(Eof))
            {
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Missing an expression after '=' sign");
            }

            if (e is NoViableAltException || e is InputMismatchException)
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