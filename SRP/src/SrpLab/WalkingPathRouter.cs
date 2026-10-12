using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.srpLabRefactor
{
    public class WalkingPathRouter
    {
        public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> Order(PickListRequirements reqs) =>
            reqs.Lines.OrderBy(l => l.Aisle).ThenBy(l => l.Bin).Select(l => (l.Aisle, l.Bin, l.Sku, Math.Min(l.Needed, l.OnHand))).Where(x => x.Item4 > 0).ToList();
    }
}
