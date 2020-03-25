using System;

namespace Polynomial.WebApi.Entities
{
    public class Polynom
    {
        public double Coefficient { get; set; }
        public int Power { get; set; }
        public string Variable { get; set; }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (char character in Variable)
            {
                hashCode += character.GetHashCode();
            }

            return hashCode ^ Power;
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