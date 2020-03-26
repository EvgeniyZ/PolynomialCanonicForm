﻿using System;
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
            var currentMonomIndex = 0;
            var monomsCount = monoms.Count - 1;
            bool joined = false;
            while (currentMonomIndex < monomsCount)
            {
                var addendMonomIndex = currentMonomIndex + 1;
                while (addendMonomIndex <= monomsCount)
                {
                    joined = JoinToCurrentIfIdentifiersEqual(monoms[currentMonomIndex], monoms[addendMonomIndex], operations[currentMonomIndex]);
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
            var (nonZeroMonoms, nonZeroOperations) = SkipMonomsAndOperationsWithZeroCoefficient(monoms, operations);

            return new Polynom {Monoms = nonZeroMonoms, Operations = nonZeroOperations.Select(x => x.GetText()).ToList()};
        }

        private static (List<Monom> nonZeroMonoms, List<ITerminalNode> nonZeroOperations) SkipMonomsAndOperationsWithZeroCoefficient(List<Monom> monoms,
            List<ITerminalNode> operations)
        {
            var nonZeroMonoms = new List<Monom>();
            var nonZeroOperations = new List<ITerminalNode>();
            for (int i = 0; i < monoms.Count; i++)
            {
                if (monoms[i].Coefficient == 0)
                {
                    continue;
                }

                nonZeroMonoms.Add(monoms[i]);
                if (i > 0)
                {
                    nonZeroOperations.Add(operations[i - 1]);
                }
            }

            return (nonZeroMonoms, nonZeroOperations);
        }

        private static bool JoinToCurrentIfIdentifiersEqual(Monom currentMonom, Monom addendMonom, ITerminalNode operation)
        {
            if (currentMonom.GetIdentifier() == addendMonom.GetIdentifier())
            {
                if (operation.GetText() == "+")
                {
                    currentMonom.Coefficient += addendMonom.Coefficient;
                    return true;
                }

                currentMonom.Coefficient -= addendMonom.Coefficient;
                return true;
            }

            return false;
        }
    }
}