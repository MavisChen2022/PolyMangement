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
                cmd.CommandText = @"INSERT INTO test(machine,pca,xinhua,aspoly,arpoly,hemlock,asdopant,phdopant,bdopant,aqm,yoxing,aqmG3,mejing,time) 
                                    VALUES(@machine,@pca,@xinhua,@aspoly,@arpoly,@hemlock,@asdopant,@phdopant,@bdopant,@aqm,@yoxing,@aqmG3,@mejing,@time)";
                cmd.Parameters.Add("@machine",DbType.String).Value = polymodel.Machine;
                cmd.Parameters.Add("@pca", DbType.Int32).Value = polymodel.Pca;
                cmd.Parameters.Add("@xinHua", DbType.Int32).Value = polymodel.Xinhua;
                cmd.Parameters.Add("@aspoly", DbType.Int32).Value = polymodel.ASpoly;
                cmd.Parameters.Add("@arpoly", DbType.Int32).Value = polymodel.ARpoly;
                cmd.Parameters.Add("@hemlock", DbType.Int32).Value = polymodel.Hemlock;

                cmd.Parameters.Add("@asdopant", DbType.Int32).Value = polymodel.AsDopant;
                cmd.Parameters.Add("@phdopant", DbType.Int32).Value = polymodel.PhDopant;
                cmd.Parameters.Add("@bdopant", DbType.Int32).Value = polymodel.BDopant;

                cmd.Parameters.Add("@aqm", DbType.Int32).Value = polymodel.Aqm;
                cmd.Parameters.Add("@yoxing", DbType.Int32).Value = polymodel.Yoxing;
                cmd.Parameters.Add("@aqmG3", DbType.Int32).Value = polymodel.AqmG3;
                cmd.Parameters.Add("@mejing", DbType.Int32).Value = polymodel.Mejing;

                cmd.Parameters.Add("@time",DbType.DateTime).Value = polymodel.Time;
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM test WHERE id=@id";
                cmd.Parameters.Add("@id",DbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
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
                                    ,asdopant=@asdopant,phdopant=@phdopant,bdopant=@bdopant,aqm=@aqm,yoxing=@yoxing,aqmG3=@aqmG3,mejing=@mejing
                                    WHERE id=@id";
                cmd.Parameters.Add("@id",DbType.Int32).Value = polymodel.Id;
                cmd.Parameters.Add("@machine", DbType.String).Value = polymodel.Machine;
                cmd.Parameters.Add("@pca", DbType.Int32).Value = polymodel.Pca;
                cmd.Parameters.Add("@xinHua", DbType.Int32).Value = polymodel.Xinhua;
                cmd.Parameters.Add("@aspoly", DbType.Int32).Value = polymodel.ASpoly;
                cmd.Parameters.Add("@arpoly", DbType.Int32).Value = polymodel.ARpoly;
                cmd.Parameters.Add("@hemlock", DbType.Int32).Value = polymodel.Hemlock;

                cmd.Parameters.Add("@asdopant", DbType.Int32).Value = polymodel.AsDopant;
                cmd.Parameters.Add("@phdopant", DbType.Int32).Value = polymodel.PhDopant;
                cmd.Parameters.Add("@bdopant", DbType.Int32).Value = polymodel.BDopant;

                cmd.Parameters.Add("@aqm", DbType.Int32).Value = polymodel.Aqm;
                cmd.Parameters.Add("@yoxing",DbType.Int32).Value=polymodel.Yoxing;
                cmd.Parameters.Add("@aqmG3", DbType.Int32).Value = polymodel.AqmG3;
                cmd.Parameters.Add("@mejing", DbType.Int32).Value = polymodel.Mejing;

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
                        poly.Id= Convert.ToInt32(dr[0]);
                        poly.Machine = dr[1].ToString();
                        poly.Pca = Convert.ToInt32(dr[2]);
                        poly.Xinhua = Convert.ToInt32(dr[3]);
                        poly.ASpoly = Convert.ToInt32(dr[4]);
                        poly.ARpoly = Convert.ToInt32(dr[5]);
                        poly.Hemlock = Convert.ToInt32(dr[6]);

                        poly.AsDopant= Convert.ToInt32(dr[7]);
                        poly.PhDopant= Convert.ToInt32(dr[8]);
                        poly.BDopant= Convert.ToInt32(dr[9]);

                        poly.Aqm= Convert.ToInt32(dr[10]);
                        poly.Yoxing= Convert.ToInt32(dr[11]);
                        poly.AqmG3 = Convert.ToInt32(dr[12]);
                        poly.Mejing= Convert.ToInt32(dr[13]);

                        poly.Time = (DateTime)dr[14];
                        stockList.Add(poly);
                    }
                }
            }
            return stockList;
        }
    }
}
