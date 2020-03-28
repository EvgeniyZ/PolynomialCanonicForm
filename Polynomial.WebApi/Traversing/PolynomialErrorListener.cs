using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Polynomial.WebApi.Traversing
{
    public class PolynomialErrorListener : BaseErrorListener
    {
        private const string EOF = "EOF";
        private const string SyntaxErrorHeader = "Expression is invalid: ";

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            if (msg.Contains(EOF))
            {
                throw new ParseCanceledException($"{SyntaxErrorHeader}{charPositionInLine} position: missing an expression after '=' sign");
            }

            if (e is NoViableAltException)
            {
                throw new ParseCanceledException($"{SyntaxErrorHeader}{--charPositionInLine} position: not closed operator");
            }

            throw new ParseCanceledException($"{SyntaxErrorHeader}{charPositionInLine} {msg}");
        }
    }
}