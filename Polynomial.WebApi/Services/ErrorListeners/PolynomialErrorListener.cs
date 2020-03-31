using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Polynomial.WebApi.Services.ErrorListeners
{
    public class PolynomialErrorListener : BaseErrorListener
    {
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            var bufferedTokenStream = recognizer.InputStream as BufferedTokenStream;
            if (e is InputMismatchException)
            {
                if (offendingSymbol.Text == "<EOF>")
                {
                    IToken previousToken = GetPreviousToken(offendingSymbol, bufferedTokenStream);
                    throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Missing an expression after '{previousToken?.Text}' sign");
                }

                throw new ParseCanceledException($"{GetSyntaxErrorHeader(++charPositionInLine)}. Missing an expression after '{offendingSymbol.Text}' sign");
            }

            if (e is NoViableAltException)
            {
                IToken previousToken = GetPreviousToken(offendingSymbol, bufferedTokenStream);
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. Not closed '{previousToken?.Text}' operator");
            }

            if (msg.StartsWith("extraneous input"))
            {
                throw new ParseCanceledException($"{GetSyntaxErrorHeader(++charPositionInLine)}. Unrecognized character '{offendingSymbol.Text}'");
            }

            throw new ParseCanceledException($"{GetSyntaxErrorHeader(charPositionInLine)}. {msg}");
        }

        private static IToken GetPreviousToken(IToken offendingSymbol, BufferedTokenStream bufferedTokenStream)
        {
            return bufferedTokenStream?.GetTokens(offendingSymbol.TokenIndex - 1, offendingSymbol.TokenIndex).First();
        }

        private static string GetSyntaxErrorHeader(int errorPosition)
        {
            return $"Expression is invalid. Input is not valid at {--errorPosition} position";
        }
    }
}