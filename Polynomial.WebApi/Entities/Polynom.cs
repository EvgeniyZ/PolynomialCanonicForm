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
                var orderedMonoms = Monoms.OrderByDescending(x => x.Power)
                    .ThenByDescending(x => x.Variable?.Length);
                var headliner = orderedMonoms.First();
                canonical.Append(headliner.ToHeadlinerString());
                foreach (var monom in orderedMonoms.Skip(1))
                {
                    canonical.Append(monom);
                }
            }

            return canonical.ToString();
        }
    }
}