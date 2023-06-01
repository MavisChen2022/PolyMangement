using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public class StockModel
    {
        public int id { get; set; }
        public string machine { get; set; }
        public int poly1 { get; set; }
        public int poly2 { get; set; }
        public int poly3 { get; set; }
        public int poly4 { get; set; }
        public int poly5 { get; set; }
        public int dopant1 { get; set; }
        public int dopant2 { get; set; }
        public int dopant3 { get; set; }
        public int crucible1 { get; set; }
        public int crucible2 { get; set; }
        public int crucible3 { get; set; }
        public int crucible4 { get; set; }
        public DateTime specifiedTime { get; set; }
    }
}
