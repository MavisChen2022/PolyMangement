using System;
using System.Collections.Generic;
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
        string ChangeTimeFormat(string year, string monthDay, string hourMins);
        void CalRedopant(string timeInterval);
        double CalculateTimeInterval(string startTime, string endTime);
        IEnumerable<RedopantModel> ShowCorrespondRecipe(string recipeName);


    }
}
