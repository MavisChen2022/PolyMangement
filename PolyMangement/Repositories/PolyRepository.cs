using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.Repositories
{
    public class PolyRepository : BaseRepository, IPolyRepository
    {
        public PolyRepository(string connection)
        {
            connectionString = connection;
        }
        public void Add(PolyModel polymodel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(PolyModel polymodel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PolyModel> GetAll()
        {
            var stockList=new List<PolyModel>();
            using(var conn=new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM  test";
                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var poly = new PolyModel();
                        poly.Pca = Convert.ToInt32(dr[0]);
                        poly.Xinhua = Convert.ToInt32(dr[1]);
                        poly.ASpoly = Convert.ToInt32(dr[2]);
                        poly.ARpoly = Convert.ToInt32(dr[3]);
                        poly.Hemlock = Convert.ToInt32(dr[4]);
                        stockList.Add(poly);
                    }
                }
            }
            return stockList;
        }

        public IEnumerable<PolyModel> GetByValue(PolyModel polymodel)
        {
            throw new NotImplementedException();
        }

    }
}
