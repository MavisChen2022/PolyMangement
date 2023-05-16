
using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories
{
    public class RedopantRepository:BaseRepository,IRedopantRepository
    {
        private string realTime;
        private string ruleTime;

        public string realTimeText 
        {
            get => realTime;
            set => realTime=value; 
        }
        public string ruleTimeText 
        { 
            get => ruleTime;
            set => ruleTime=value;
        }

        public RedopantRepository(string connection)
        {
            connectionString=connection;
        }

        public void CalRedopant(string timeInterval)
        {
            throw new NotImplementedException();
        }
        public DataTable ShowCorrespondRecipe(string recipeName)  //指定秀出RecipeA還沒有實作，目前裡面的實際功能是一次秀全部
        {
            DataTable dataTable = new DataTable();
            using (var conn = new SQLiteConnection(connectionString))
            using (var adapter = new SQLiteDataAdapter($"SELECT hour,{recipeName} FROM redopantTest", conn))
            {
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        public void StartTimeFormat(string year, string monthDay, string hourMins)
        {
            var hourMin = hourMins.Insert(2, ":");
            realTime = year + "/" + monthDay + " " + hourMin;
        }
        public void EndTimeFormat(string year, string monthDay, string hourMins)
        {
            var hourMin = hourMins.Insert(2, ":");
            ruleTime = year + "/" + monthDay + " " + hourMin;
        }
        public void CalTimeInterval()
        {
            var s = Convert.ToDateTime(realTime);
            var e = Convert.ToDateTime(ruleTime);
            TimeSpan ts = e - s;
            double hrs = ts.TotalSeconds / 3600;
            realTimeText =Math.Round(hrs, 2).ToString();
            ruleTimeText= Math.Floor(hrs).ToString();
        }
    }
}
