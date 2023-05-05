using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
        public IEnumerable<SearchModel> GetByValue(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchModel> GetNow()
        {
            var searchList = new List<SearchModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM  test";
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

                        search.Time = (DateTime)dr[14];
                        searchList.Add(search);
                    }
                }
            }
            return searchList;
        }
    }
}
