using System;
using System.Globalization;
using System.Linq;

namespace Polynomial.WebApi.Entities
{
    public class Monom
    {
        public double Coefficient { get; set; }
        public int Power { get; set; }
        public string Variable { get; set; }

        public int GetIdentifier()
        {
            if (string.IsNullOrEmpty(Variable))
            {
                //if no variable then monom is const
                return 1;
            }

            return string.Concat(Variable.OrderBy(x => x)).GetHashCode() ^ Power;
        }

        public string ToHeadlinerString()
        {
            var monomAsString = ToString();
            var startWithPlus = monomAsString[0] == '+';
            if (monomAsString.Length == 1)
            {
                if (startWithPlus)
                {
                    return "1";
                }

                return "-1";
            }

            if (startWithPlus)
            {
                return monomAsString.Substring(1);
            }

            return monomAsString;
        }

        public override string ToString()
        {
            if (Coefficient == 0)
            {
                if (Power > 0)
                {
                    if (string.IsNullOrEmpty(Variable))
                    {
                        throw new Exception($"Power {Power} specified but no Variable set");
                    }

                    return $"{Variable}{PowerToString(Power)}";
                }

                return $"{Variable}";
            }

            if (Power > 0)
            {
                if (string.IsNullOrEmpty(Variable))
                {
                    throw new Exception($"Power {Power} specified but no Variable set");
                }

                return $"{CoefficientToString(Coefficient)}{Variable}{PowerToString(Power)}";
            }

            if (Power == 0)
            {
                return $"{CoefficientToString(Coefficient, true)}";
            }

            return $"{CoefficientToString(Coefficient)}{Variable}";
        }

        private static string PowerToString(int power)
        {
            if (power > 1)
            {
                return $"^{power}";
            }

            return string.Empty;
        }

        private static string CoefficientToString(double coefficient, bool powerIsZero = false)
        {
            if (coefficient == 1)
            {
                if (powerIsZero)
                {
                    return "+1";
                }
                return "+";
            }

            if (coefficient == -1)
            {
                if (powerIsZero)
                {
                    return "-1";
                }
                return "-";
            }

            if (coefficient > 0)
            {
                return $"+{coefficient.ToString(CultureInfo.InvariantCulture)}";
            }

            return $"{coefficient.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}