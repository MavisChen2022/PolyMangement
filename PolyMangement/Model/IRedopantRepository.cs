using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public interface IRedopantRepository
    {
        void CalRedopant(string timeInterval);
        void CalTimeInterval(DateTime startTime,DateTime endTime);
        void ShowCorrespondRecipe(string recipeName);


    }
}
