using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO test(machine,pca,xinhua,aspoly,arpoly,hemlock,time) VALUES(@machine,@pca,@xinhua,@aspoly,@arpoly,@hemlock,@time)";
                cmd.Parameters.Add("@machine",DbType.String).Value = polymodel.Machine;
                cmd.Parameters.Add("@pca", DbType.Int32).Value = polymodel.Pca;
                cmd.Parameters.Add("@xinHua", DbType.Int32).Value = polymodel.Xinhua;
                cmd.Parameters.Add("@aspoly", DbType.Int32).Value = polymodel.ASpoly;
                cmd.Parameters.Add("@arpoly", DbType.Int32).Value = polymodel.ARpoly;
                cmd.Parameters.Add("@hemlock", DbType.Int32).Value = polymodel.Hemlock;
                cmd.Parameters.Add("@time",DbType.DateTime).Value = polymodel.Time;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(PolyModel polymodel)
        {
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"UPDATE test 
                                    SET machine=@machine,pca=@pca,xinhua=@xinhua,aspoly=@aspoly,arpoly=@arpoly,hemlock=@hemlock 
                                    WHERE time=@time";
                cmd.Parameters.Add("@machine", DbType.String).Value = polymodel.Machine;
                cmd.Parameters.Add("@pca", DbType.Int32).Value = polymodel.Pca;
                cmd.Parameters.Add("@xinHua", DbType.Int32).Value = polymodel.Xinhua;
                cmd.Parameters.Add("@aspoly", DbType.Int32).Value = polymodel.ASpoly;
                cmd.Parameters.Add("@arpoly", DbType.Int32).Value = polymodel.ARpoly;
                cmd.Parameters.Add("@hemlock", DbType.Int32).Value = polymodel.Hemlock;
                cmd.Parameters.Add("@time", DbType.DateTime).Value = polymodel.Time;
                cmd.ExecuteNonQuery();
            }
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
                        poly.Machine = dr[0].ToString();
                        poly.Pca = Convert.ToInt32(dr[1]);
                        poly.Xinhua = Convert.ToInt32(dr[2]);
                        poly.ASpoly = Convert.ToInt32(dr[3]);
                        poly.ARpoly = Convert.ToInt32(dr[4]);
                        poly.Hemlock = Convert.ToInt32(dr[5]);
                        poly.Time = (DateTime)dr[6];
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
