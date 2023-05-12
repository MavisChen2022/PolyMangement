using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories
{
    public class RedopantRepository:BaseRepository,IRedopantRepository
    {
        public RedopantRepository(string connection)
        {
            connectionString=connection;
        }

        public void CalRedopant(string timeInterval)
        {
            throw new NotImplementedException();
        }

        public string CalTimeInterval(string startTime, string endTime)
        {
            var s = Convert.ToDateTime(startTime);
            var e=Convert.ToDateTime(endTime);
            TimeSpan ts = e - s;
            double hrs = ts.TotalSeconds / 3600;
            return hrs.ToString();
        }

        public void ShowCorrespondRecipe(string recipeName)
        {
            throw new NotImplementedException();
        }
    }
}
