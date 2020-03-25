using System.Linq;
using System.Text.RegularExpressions;
using Polynomial.WebApi.Entities;

namespace Polynomial.WebApi.Services
{
    public class PolynomialVisitor : PolynomialBaseVisitor<Polynom>
    {
        public override Polynom VisitParens(PolynomialParser.ParensContext context)
        {
            return Visit(context.polynomial());
        }

        public override Polynom VisitDouble(PolynomialParser.DoubleContext context)
        {
            return new Polynom {Coefficient = double.Parse(context.GetText())};
        }

        public override Polynom VisitInteger(PolynomialParser.IntegerContext context)
        {
            return new Polynom {Coefficient = int.Parse(context.GetText())};
        }

        public override Polynom VisitMonomial(PolynomialParser.MonomialContext context)
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
                        return new Polynom
                        {
                            Coefficient = int.Parse(intCoefficient),
                            Variable = context.VAR().GetText()
                        };
                    }

                    return new Polynom
                    {
                        Coefficient = int.Parse(intCoefficient),
                        Variable = context.VAR().GetText(),
                        Power = int.Parse(power.GetText())
                    };
                }
            }
            else
            {
                var digits = context.INT();
                if (digits.Any())
                {
                    var power = digits.First().GetText();
                    return new Polynom
                    {
                        Coefficient = double.Parse(realCoefficient),
                        Variable = context.VAR().GetText(),
                        Power = int.Parse(power)
                    };
                }

                return new Polynom
                {
                    Coefficient = double.Parse(realCoefficient),
                    Variable = context.VAR().GetText()
                };
            }

            return new Polynom
            {
                Variable = context.VAR().GetText()
            };
        }

        public override Polynom VisitAddSub(PolynomialParser.AddSubContext context)
        {
            Polynom left = Visit(context.polynomial(0));
            Polynom right = Visit(context.polynomial(1));


            return left + right;
        }
    }
}