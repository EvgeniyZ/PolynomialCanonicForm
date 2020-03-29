using System;
using System.IO;
using Antlr4.Runtime;

namespace Polynomial.WebApi.Services
{
    public class MismatchedPolynomialErrorListener : IAntlrErrorListener<IToken>
    {
        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new Exception($"line {line}:{charPositionInLine} {msg}");
        }
    }
}