using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polynomial.WebApi.Traversing;

namespace Polynomial.WebApi.Services
{
    public class CanonicalFormer
    {
        public string ToCanonical(string expression)
        {
            ICharStream stream = CharStreams.fromstring(expression);
            ITokenSource lexer = new PolynomialLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            PolynomialParser parser = new PolynomialParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.polynomial();

            PolynomialVisitor polynomialVisitor = new PolynomialVisitor();

            string canonical = polynomialVisitor.Visit(tree);

            return canonical;
        }
    }
}