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
        public double b 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public void CalRedopant(string timeInterval)
        {
            throw new NotImplementedException();
        }
        public void ShowCorrespondRecipe(string recipeName)
        {
            throw new NotImplementedException();
        }
        public double CalculateTimeInterval(string startTime, string endTime)
        {
            var s = Convert.ToDateTime(startTime);
            var e=Convert.ToDateTime(endTime);
            TimeSpan ts = e - s;
            double hrs = ts.TotalSeconds / 3600;
            return hrs;
        }

        public string ChangeTimeFormat(string year, string monthDay, string hourMins)
        {
            var hourMin = hourMins.Insert(2, ":");
            return year + "/" + monthDay + " " + hourMin;
        }
    }
}
