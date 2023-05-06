using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public interface ISearchRepository
    {
        IEnumerable<SearchModel> GetNow(DateTime currentTime);
        IEnumerable<SearchModel> GetByValue(DateTime selectedTime,string shift);   //分出日夜班
    }
}
