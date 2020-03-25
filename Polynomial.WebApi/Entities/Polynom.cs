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

        public ICollection<Monom> Monoms { get; set; }

        public override string ToString()
        {
            var canonical = new StringBuilder();
            foreach (var monom in Monoms)
            {
                canonical.Append(monom);
            }

            return canonical.ToString();
        }
    }
}