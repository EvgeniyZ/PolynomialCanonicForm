using System.Linq;
using Polynomial.WebApi.Traversing;

namespace Polynomial.WebApi.Services
{
    public class PolynomialVisitor : PolynomialBaseVisitor<string>
    {
        public override string VisitParens(PolynomialParser.ParensContext context)
        {
            return Visit(context.polynomial());
        }

        public override string VisitDouble(PolynomialParser.DoubleContext context)
        {
            return context.GetText();
        }

        public override string VisitInteger(PolynomialParser.IntegerContext context)
        {
            return context.GetText();
        }

        public override string VisitRealMonomial(PolynomialParser.RealMonomialContext context)
        {
            var realCoefficient = context.DOUBLE().GetText();
            if (string.IsNullOrEmpty(realCoefficient))
            {
                var digits = context.INT();
                if (digits.Any())
                {
                    var intCoefficient = digits.First().GetText();
                    var power = digits.Skip(1).FirstOrDefault();
                    if (power is null)
                    {
                        return $"{intCoefficient}{context.VAR().GetText()}";
                    }
                    return $"{intCoefficient}{context.VAR().GetText()}^{power.GetText()}";
                }
            }
            else
            {
                var digits = context.INT();
                if (digits.Any())
                {
                    var power = digits.First().GetText();
                    return $"{realCoefficient}{context.VAR().GetText()}^{power}";
                }

                return $"{realCoefficient}{context.VAR().GetText()}";
            }
            return context.VAR().GetText();
        }

        public override string VisitAddSub(PolynomialParser.AddSubContext context)
        {
            var monomials = context.monomial();
            var signs = context.SIGN();
            
        }
    }
}