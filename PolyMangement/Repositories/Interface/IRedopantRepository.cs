using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public interface IRedopantRepository
    {
        string realTimeText { get; set; }
        string ruleTimeText { get; set; }
        void StartTimeFormat(string year, string monthDay, string hourMins);
        void EndTimeFormat(string year, string monthDay, string hourMins);
        void CalTimeInterval();
        
        string CalRedopant(string recipeName, string hour,string neckTimes);

        DataTable ShowCorrespondRecipe(string recipeName, string neckTimes);


    }
}
