using System.Collections.Generic;
using System.Linq;
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
            return new Polynom {Monoms = new List<Monom> {new Monom {Coefficient = double.Parse(context.GetText())}}};
        }

        public override Polynom VisitInteger(PolynomialParser.IntegerContext context)
        {
            return new Polynom {Monoms = new List<Monom> {new Monom {Coefficient = int.Parse(context.GetText())}}};
        }

        public override Polynom VisitMonomial(PolynomialParser.MonomialContext context)
        {
            var polynom = new Polynom();
            var realCoefficientContext = context.DOUBLE();
            if (realCoefficientContext is null)
            {
                var digits = context.INT();
                if (digits != null && digits.Any())
                {
                    var intCoefficient = digits.First().GetText();
                    var power = digits.Skip(1).FirstOrDefault();
                    if (power is null)
                    {
                        polynom.Monoms.Add(new Monom
                        {
                            Coefficient = int.Parse(intCoefficient),
                            Variable = context.VAR().GetText()
                        });
                        return polynom;
                    }

                    polynom.Monoms.Add(new Monom
                    {
                        Coefficient = int.Parse(intCoefficient),
                        Variable = context.VAR().GetText(),
                        Power = int.Parse(power.GetText())
                    });
                    return polynom;
                }
            }
            else
            {
                var realCoefficient = realCoefficientContext.GetText();
                var digits = context.INT();
                if (digits.Any())
                {
                    var power = digits.First().GetText();
                    polynom.Monoms.Add(new Monom
                    {
                        Coefficient = double.Parse(realCoefficient),
                        Variable = context.VAR().GetText(),
                        Power = int.Parse(power)
                    });
                    return polynom;
                }

                polynom.Monoms.Add(new Monom
                {
                    Coefficient = double.Parse(realCoefficient),
                    Variable = context.VAR().GetText()
                });
                return polynom;
            }

            polynom.Monoms.Add(new Monom
            {
                Variable = context.VAR().GetText()
            });
            return polynom;
        }

        public override Polynom VisitAddSub(PolynomialParser.AddSubContext context)
        {
            Polynom canonical = new Polynom();
            Polynom left = Visit(context.polynomial(0));
            Polynom right = Visit(context.polynomial(1));
            if (left.Monoms.Count == 1 && right.Monoms.Count == 1)
            {
                var leftMonom = left.Monoms.First();
                var rightMonom = right.Monoms.First();
                if (leftMonom.GetHashCode() == rightMonom.GetHashCode())
                {
                    canonical.Monoms.Add(new Monom
                    {
                        Coefficient = leftMonom.Coefficient + rightMonom.Coefficient,
                        Power = leftMonom.Power,
                        Variable = leftMonom.Variable
                    });
                }
                else
                {
                    canonical.Monoms.Add(leftMonom);
                    canonical.Monoms.Add(rightMonom);
                }
            }

            return canonical;
            // foreach (var leftMonom in left.Monoms)
            // {
            //     foreach (var rightMonom in right.Monoms)
            //     {
            //         var leftHashCode = left.GetHashCode();
            //         var rightHashCode = right.GetHashCode();
            //         if (leftHashCode == rightHashCode)
            //         {
            //             switch (context.op.Type)
            //             {
            //                 case PolynomialParser.ADD:
            //                     break;
            //                 case PolynomialParser.SUB:
            //                     break;
            //                 default:
            //                     break;
            //             }
            //         }
            //         else
            //         {
            //             canonical.Monoms.Add(rightMonom);
            //         }
            //     }
            // }
            //
            // return canonical;
        }
    }
}