using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories
{
    public class BaseRepository
    {
        protected string connectionString;

        protected IEnumerable<StockModel> GetDataFromSQLite(string timeInterval)
        {
            var searchList = new List<StockModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = timeInterval;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var search = new StockModel();
                        search.id = Convert.ToInt32(dr[0]);
                        search.machine = dr[1].ToString();
                        search.pca = Convert.ToInt32(dr[2]);
                        search.xinhua = Convert.ToInt32(dr[3]);
                        search.aSpoly = Convert.ToInt32(dr[4]);
                        search.aRpoly = Convert.ToInt32(dr[5]);
                        search.hemlock = Convert.ToInt32(dr[6]);

                        search.asDopant = Convert.ToInt32(dr[7]);
                        search.phDopant = Convert.ToInt32(dr[8]);
                        search.bDopant = Convert.ToInt32(dr[9]);

                        search.aqm = Convert.ToInt32(dr[10]);
                        search.yoxing = Convert.ToInt32(dr[11]);
                        search.aqmG3 = Convert.ToInt32(dr[12]);
                        search.mejing = Convert.ToInt32(dr[13]);

                        search.specifiedTime = (DateTime)dr[14];
                        searchList.Add(search);
                    }
                }
            }
            return searchList;
        }
    }
}
