using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.WebApi.Entities
{
    public class Polynom
    {
        public Polynom()
        {
            Monoms = new List<Monom>();
        }

        public IList<Monom> Monoms { get; set; }
        public IList<string> Operations { get; set; }

        public override string ToString()
        {
            var canonical = new StringBuilder();
            for (int i = 0; i < Monoms.Count; i++)
            {
                canonical.Append(Monoms[i]);
                if (i > Operations.Count - 1)
                {
                    continue;
                }
                canonical.Append(Operations[i]);
            }

            return canonical.ToString();
        }
    }
}