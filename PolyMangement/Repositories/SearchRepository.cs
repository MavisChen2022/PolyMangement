using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository(string connection)
        {
            connectionString=connection;
        }

        public IEnumerable<SearchModel> GetByValue(DateTime selectedTime, string shift)
        {
            string startTime = shift == "日班" ? selectedTime.ToString("yyyy-MM-dd 08:00:00") : selectedTime.ToString("yyyy-MM-dd 20:00:00");
            string endTime = shift == "日班" ? selectedTime.ToString("yyyy-MM-dd 20:00:00") : selectedTime.AddDays(1).ToString("yyyy-MM-dd 08:00:00");

            var searchList = new List<SearchModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT * FROM  test WHERE time>='{startTime}' AND time<'{endTime}'";
                DatabaseReader(searchList, cmd);
            }
            return searchList;
        }

        public IEnumerable<SearchModel> GetNow(DateTime currentTime)
        {
            TimeSpan choiceTime = Convert.ToDateTime(currentTime.ToShortTimeString()).TimeOfDay;
            TimeSpan dayStart = DateTime.Parse("08:00").TimeOfDay;
            TimeSpan dayEnd = DateTime.Parse("20:00").TimeOfDay;
            string targetStart;
            string targetEnd = currentTime.ToLongTimeString();
            if (choiceTime >= dayStart && choiceTime < dayEnd)
            {
                targetStart = currentTime.ToString("yyyy-MM-dd 08:00:00");
            }
            else
            {
                targetStart= currentTime.AddDays(-1).ToString("yyyy-MM-dd 20:00:00");
            }

            var searchList = new List<SearchModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT * FROM  test WHERE time>='{targetStart}' AND time<'{targetEnd}'";
                DatabaseReader(searchList, cmd);
            }
            return searchList;
        }
        private void DatabaseReader(List<SearchModel> searchList, SQLiteCommand cmd)
        {
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var search = new SearchModel();
                    search.Id = Convert.ToInt32(dr[0]);
                    search.Machine = dr[1].ToString();
                    search.Pca = Convert.ToInt32(dr[2]);
                    search.Xinhua = Convert.ToInt32(dr[3]);
                    search.ASpoly = Convert.ToInt32(dr[4]);
                    search.ARpoly = Convert.ToInt32(dr[5]);
                    search.Hemlock = Convert.ToInt32(dr[6]);

                    search.AsDopant = Convert.ToInt32(dr[7]);
                    search.PhDopant = Convert.ToInt32(dr[8]);
                    search.BDopant = Convert.ToInt32(dr[9]);

                    search.Aqm = Convert.ToInt32(dr[10]);
                    search.Yoxing = Convert.ToInt32(dr[11]);
                    search.AqmG3 = Convert.ToInt32(dr[12]);
                    search.Mejing = Convert.ToInt32(dr[13]);

                    search.SpecifiedTime = (DateTime)dr[14];
                    searchList.Add(search);
                }
            }
        }
    }
}
