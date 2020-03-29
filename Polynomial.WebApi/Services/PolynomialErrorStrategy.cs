using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Polynomial.WebApi.Services
{
    public class PolynomialErrorStrategy : DefaultErrorStrategy
    {
        public override void ReportError(Parser recognizer, RecognitionException e)
        {
            throw e;
        }

        public override void Recover(Parser recognizer, RecognitionException e)
        {
            for (ParserRuleContext context = recognizer.Context; context != null; context = (ParserRuleContext) context.Parent) {
                context.exception = e;
            }

            throw new ParseCanceledException(e);
        }

        public override IToken RecoverInline(Parser recognizer)
        {
            InputMismatchException e = new InputMismatchException(recognizer);
            for (ParserRuleContext context = recognizer.Context; context != null; context = (ParserRuleContext) context.Parent) {
                context.exception = e;
            }

            throw new ParseCanceledException(e);
        }

        protected override void ReportInputMismatch(Parser recognizer, InputMismatchException e)
        {
            string msg = "mismatched input " + GetTokenErrorDisplay(e.OffendingToken);
            // msg += " expecting one of " + e.GetExpectedTokens().ToString(recognizer.());
            RecognitionException ex = new RecognitionException(msg, recognizer, recognizer.InputStream, recognizer.Context);
            throw ex;
        }

        protected override void ReportMissingToken(Parser recognizer)
        {
            BeginErrorCondition(recognizer);
            IToken token = recognizer.CurrentToken;
            IntervalSet expecting = GetExpectedTokens(recognizer);
            string msg = "missing " + expecting.ToString() + " at " + GetTokenErrorDisplay(token);
            throw new RecognitionException(msg, recognizer, recognizer.InputStream, recognizer.Context);
        }
    }
}