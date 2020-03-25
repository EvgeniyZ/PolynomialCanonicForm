using System;
using System.Linq;

namespace Polynomial.WebApi.Entities
{
    public class Monom
    {
        public double Coefficient { get; set; }
        public int Power { get; set; }
        public string Variable { get; set; }

        public override int GetHashCode()
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
            if (Math.Abs(Coefficient) < Double.Epsilon)
            {
                if (Power > 0)
                {
                    if (string.IsNullOrEmpty(Variable))
                    {
                        throw new Exception($"Power {Power} specified but no Variable set");
                    }

                    return $"{Variable}^{Power}";
                }

                return $"{Variable}";
            }

            if (Power > 0)
            {
                if (string.IsNullOrEmpty(Variable))
                {
                    throw new Exception($"Power {Power} specified but no Variable set");
                }

                return $"{Coefficient}{Variable}^{Power}";
            }

            return $"{Coefficient}{Variable}";
        }
    }
}