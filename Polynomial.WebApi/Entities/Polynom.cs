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
            if (Monoms.Any())
            {
                var headliner = Monoms.First();
                if (headliner.Coefficient < 0)
                {
                    canonical.Append(headliner);
                }
                else
                {
                    canonical.Append(headliner.ToHeadlinerString());
                }
                foreach (var monom in Monoms.Skip(1))
                {
                    canonical.Append(monom);
                }
            }
            

            return canonical.ToString();
        }
    }
}