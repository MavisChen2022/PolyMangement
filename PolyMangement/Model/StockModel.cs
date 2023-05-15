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
        public int pca { get; set; }
        public int xinhua { get; set; }
        public int aSpoly { get; set; }
        public int aRpoly { get; set; }
        public int hemlock { get; set; }
        public int asDopant { get; set; }
        public int phDopant { get; set; }
        public int bDopant { get; set; }
        public int aqm { get; set; }
        public int yoxing { get; set; }
        public int aqmG3 { get; set; }
        public int mejing { get; set; }
        public DateTime specifiedTime { get; set; }
    }
}
