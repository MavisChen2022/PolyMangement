
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
        public DataTable ShowCorrespondRecipe(string recipeName, string neckTimes)
        {
            DataTable dataTable = new DataTable();
            using (var conn = new SQLiteConnection(connectionString))
            using (var adapter = new SQLiteDataAdapter($"SELECT hour,{recipeName + neckTimes} FROM redopantTest", conn))
            {
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
        public string CalRedopant(string recipeName, string hour,string neckTimes)
        {
            string correspondRedopantWeight="";
            using(var conn=new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT {recipeName+ neckTimes} FROM redopantTest WHERE {hour}=hour";
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        correspondRedopantWeight = dr[0].ToString();
                    }
                }
            }
            return correspondRedopantWeight;
        }
    }
}
