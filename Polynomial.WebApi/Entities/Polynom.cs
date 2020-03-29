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
        public bool HasEqualsSign { get; set; }

        public override string ToString()
        {
            var canonical = new StringBuilder();
            bool isOnlyConstantCanonical = false;
            if (Monoms.Any())
            {
                var orderedMonoms = Monoms.OrderByDescending(x => x.Power)
                    .ThenByDescending(x => x.Variable?.Length);
                var headliner = orderedMonoms.First();
                canonical.Append(headliner.ToHeadlinerString());
                var monomsWithSigns = orderedMonoms.Skip(1);
                if (monomsWithSigns.Any())
                {
                    foreach (var monom in monomsWithSigns)
                    {
                        canonical.Append(monom);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(headliner.Variable))
                    {
                        isOnlyConstantCanonical = true;
                    }
                }
            }

            return HasEqualsSign && !isOnlyConstantCanonical ? $"{canonical}=0" : canonical.ToString();
        }
    }
}