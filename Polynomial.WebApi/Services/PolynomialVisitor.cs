using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using Polynomial.WebApi.Entities;

namespace Polynomial.WebApi.Services
{
    public class PolynomialVisitor : PolynomialBaseVisitor<Polynom>
    {
        public override Polynom VisitParens(PolynomialParser.ParensContext context)
        {
            return Visit(context.polynomial());
        }

        public override Polynom VisitNumber(PolynomialParser.NumberContext context)
        {
            return new Polynom {Monoms = new List<Monom> {new Monom {Coefficient = double.Parse(context.GetText())}}};
        }

        public override Polynom VisitAddend(PolynomialParser.AddendContext context)
        {
            var polynom = new Polynom();
            var coefficientContext = context.coefficient();
            if (coefficientContext is null)
            {
                var power = context.INT();
                if (power is null)
                {
                    polynom.Monoms.Add(new Monom
                    {
                        Coefficient = 1,
                        Variable = context.VAR().GetText(),
                        Power = 1
                    });
                    return polynom;
                }

                polynom.Monoms.Add(new Monom
                {
                    Coefficient = 1,
                    Variable = context.VAR().GetText(),
                    Power = int.Parse(power.GetText())
                });
                return polynom;
            }
            else
            {
                var coefficient = coefficientContext.GetText();
                var power = context.INT();
                if (power is null)
                {
                    polynom.Monoms.Add(new Monom
                    {
                        Coefficient = double.Parse(coefficient),
                        Variable = context.VAR().GetText(),
                        Power = 1
                    });
                    return polynom;
                }

                polynom.Monoms.Add(new Monom
                {
                    Coefficient = double.Parse(coefficient),
                    Variable = context.VAR().GetText(),
                    Power = int.Parse(power.GetText())
                });
                return polynom;
            }
        }

        public override Polynom VisitAddSub(PolynomialParser.AddSubContext context)
        {
            List<Monom> monoms = context.monomial().Select(Visit).SelectMany(x => x.Monoms).ToList();
            var operations = context.SIGN().ToList();
            SetCoefficientsSignsToMonoms(monoms, operations);
            var currentMonomIndex = 0;
            var monomsCount = monoms.Count - 1;
            bool joined = false;
            while (currentMonomIndex < monomsCount)
            {
                var addendMonomIndex = currentMonomIndex + 1;
                while (addendMonomIndex <= monomsCount)
                {
                    joined = TryJoinToCurrentIfIdentifiersEqual(monoms[currentMonomIndex], monoms[addendMonomIndex]);
                    if (joined)
                    {
                        monomsCount--;
                        monoms.Remove(monoms[addendMonomIndex]);
                        operations.Remove(operations[currentMonomIndex]);
                        break;
                    }

                    addendMonomIndex++;
                }

                if (joined)
                {
                    currentMonomIndex = 0;
                    joined = false;
                }
                else
                {
                    currentMonomIndex++;
                }
            }

            //TODO : Remove from monoms and operations that monoms which coefficient is ZERO

            return new Polynom {Monoms = monoms.Where(x => x.Coefficient != 0).ToList()};
        }

        private static void SetCoefficientsSignsToMonoms(List<Monom> monoms, List<ITerminalNode> operations)
        {
            var monomIndex = 0;
            var startedWithMinus = monoms.Count == operations.Count;
            if (!startedWithMinus)
            {
                monomIndex++;
            }

            foreach (var operation in operations)
            {
                switch (operation.GetText())
                {
                    case "+":
                        break;
                    case "-":
                        monoms[monomIndex].Coefficient *= -1;
                        break;
                }

                monomIndex++;
            }
        }

        private static bool TryJoinToCurrentIfIdentifiersEqual(Monom currentMonom, Monom addendMonom)
        {
            if (currentMonom.GetIdentifier() == addendMonom.GetIdentifier())
            {
                currentMonom.Coefficient += addendMonom.Coefficient;
                return true;
            }

            return false;
        }
    }
}