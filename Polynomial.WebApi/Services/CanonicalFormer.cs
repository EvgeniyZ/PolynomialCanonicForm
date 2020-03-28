using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Polynomial.WebApi.Entities;

namespace Polynomial.WebApi.Services
{
    public class CanonicalFormer
    {
        public string ToCanonical(string expression)
        {
            var tree = GetParsedTree(expression);

            PolynomialVisitor polynomialVisitor = new PolynomialVisitor();
            Polynom canonical = polynomialVisitor.Visit(tree);

            return canonical.ToString();
        }

        private static IParseTree GetParsedTree(string expression)
        {
            ICharStream stream = CharStreams.fromstring(expression);
            ITokenSource lexer = new PolynomialLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            PolynomialParser parser = new PolynomialParser(tokens);

            parser.BuildParseTree = true;
            IParseTree tree = parser.canonical();

            return tree;
        }
    }
}