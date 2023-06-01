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
                        search.poly1 = Convert.ToInt32(dr[2]);
                        search.poly2 = Convert.ToInt32(dr[3]);
                        search.poly3 = Convert.ToInt32(dr[4]);
                        search.poly4 = Convert.ToInt32(dr[5]);
                        search.poly5 = Convert.ToInt32(dr[6]);

                        search.dopant1 = Convert.ToInt32(dr[7]);
                        search.dopant2 = Convert.ToInt32(dr[8]);
                        search.dopant3 = Convert.ToInt32(dr[9]);

                        search.crucible1 = Convert.ToInt32(dr[10]);
                        search.crucible2 = Convert.ToInt32(dr[11]);
                        search.crucible3 = Convert.ToInt32(dr[12]);
                        search.crucible4 = Convert.ToInt32(dr[13]);

                        search.specifiedTime = (DateTime)dr[14];
                        searchList.Add(search);
                    }
                }
            }
            return searchList;
        }
    }
}
