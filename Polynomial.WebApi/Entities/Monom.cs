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

            return Variable.OrderBy(x => x).ToString().GetHashCode() ^ Power;
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

            return $"{CoefficientToString(Coefficient)}{Variable}";
        }

        private string PowerToString(int power)
        {
            if (power > 1)
            {
                return $"^{power}";
            }

            return string.Empty;
        }

        private string CoefficientToString(double coefficient)
        {
            if (coefficient == 1)
            {
                return string.Empty;
            }

            return coefficient.ToString(CultureInfo.InvariantCulture);
        }
    }
}