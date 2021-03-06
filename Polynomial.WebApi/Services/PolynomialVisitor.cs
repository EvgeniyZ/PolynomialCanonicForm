﻿using System.Collections.Generic;
using System.Linq;
using Polynomial.WebApi.Domain.Entities;

namespace Polynomial.WebApi.Services
{
    public class PolynomialVisitor : PolynomialBaseVisitor<Polynom>
    {
        private const string Sub = "-";
        private const string Equal = "=";

        public override Polynom VisitParens(PolynomialParser.ParensContext context)
        {
            List<Monom> monoms = context.polynomial().Select(Visit).SelectMany(x => x.Monoms).ToList();
            foreach (var monom in monoms)
            {
                AdjustCoefficientIfSignIsSub(monom, context.SIGN()?.GetText());
            }

            return ConstructCanonicalPolynom(monoms);
        }

        public override Polynom VisitNumber(PolynomialParser.NumberContext context)
        {
            var monom = new Monom {Coefficient = double.Parse(context.coefficient().GetText())};
            AdjustCoefficientIfSignIsSub(monom, context.SIGN()?.GetText());

            return new Polynom {Monoms = new List<Monom> {monom}};
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
                }
                else
                {
                    polynom.Monoms.Add(new Monom
                    {
                        Coefficient = 1,
                        Variable = context.VAR().GetText(),
                        Power = int.Parse(power.GetText())
                    });
                }
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
                }
                else
                {
                    polynom.Monoms.Add(new Monom
                    {
                        Coefficient = double.Parse(coefficient),
                        Variable = context.VAR().GetText(),
                        Power = int.Parse(power.GetText())
                    });
                }
            }

            AdjustCoefficientIfSignIsSub(polynom.Monoms.First(), context.SIGN()?.GetText());

            return polynom;
        }

        public override Polynom VisitCanonicalPolynom(PolynomialParser.CanonicalPolynomContext context)
        {
            return ConstructCanonicalPolynom(context.polynomial().Select(Visit).SelectMany(x => x.Monoms).ToList());
        }

        public override Polynom VisitEquality(PolynomialParser.EqualityContext context)
        {
            var monomsBeforeEquality = context.children.TakeWhile(x => x.GetText() != Equal)
                .Select(Visit)
                .SelectMany(x => x.Monoms)
                .ToList();
            var monomsAfterEquality = context.children.SkipWhile(x => x.GetText() != Equal)
                .Skip(1)
                .Select(Visit)
                .SelectMany(x => x.Monoms)
                .ToList();
            foreach (var monom in monomsAfterEquality)
            {
                monom.Coefficient *= -1;
            }

            monomsBeforeEquality.AddRange(monomsAfterEquality);

            return ConstructCanonicalPolynom(monomsBeforeEquality, true);
        }

        public override Polynom VisitParse(PolynomialParser.ParseContext context)
        {
            return Visit(context.canonical());
        }

        private static void AdjustCoefficientIfSignIsSub(Monom monom, string sign)
        {
            switch (sign)
            {
                case Sub:
                    monom.Coefficient *= -1;
                    return;
            }
        }

        private static Polynom ConstructCanonicalPolynom(List<Monom> monoms, bool hasEqualsSign = false)
        {
            var currentMonomIndex = 0;
            var lastMonomIndex = monoms.Count - 1;
            while (currentMonomIndex < lastMonomIndex)
            {
                var addendMonomIndex = currentMonomIndex + 1;
                while (addendMonomIndex <= lastMonomIndex)
                {
                    bool joined = TryJoinToCurrentIfIdentifiersEquals(monoms[currentMonomIndex], monoms[addendMonomIndex]);
                    if (joined)
                    {
                        lastMonomIndex--;
                        monoms.Remove(monoms[addendMonomIndex]);
                        continue;
                    }

                    addendMonomIndex++;
                }

                currentMonomIndex++;
            }

            return new Polynom {Monoms = monoms.Where(x => x.Coefficient != 0).ToList(), HasEqualsSign = hasEqualsSign};
        }

        private static bool TryJoinToCurrentIfIdentifiersEquals(Monom currentMonom, Monom addendMonom)
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