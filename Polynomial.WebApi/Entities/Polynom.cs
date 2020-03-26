using System.Collections.Generic;
using System.Linq;
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