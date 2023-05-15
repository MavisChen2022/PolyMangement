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
        public void Add(StockModel stockModel)
        {
            string addCommand= @"INSERT INTO test(machine,pca,xinhua,aspoly,arpoly,hemlock,asdopant,phdopant,bdopant,aqm,yoxing,aqmG3,mejing,time) 
                                 VALUES(@machine,@pca,@xinhua,@aspoly,@arpoly,@hemlock,@asdopant,@phdopant,@bdopant,@aqm,@yoxing,@aqmG3,@mejing,@time)";
            GetDetailFromSQLite(stockModel, addCommand);
        }
        public void Edit(StockModel stockModel)
        {
            string editCommand = @"UPDATE test 
                                  SET machine=@machine,pca=@pca,xinhua=@xinhua,aspoly=@aspoly,arpoly=@arpoly,hemlock=@hemlock
                                  ,asdopant=@asdopant,phdopant=@phdopant,bdopant=@bdopant,aqm=@aqm,yoxing=@yoxing,aqmG3=@aqmG3,mejing=@mejing
                                  WHERE id=@id";
            GetDetailFromSQLite(stockModel, editCommand);
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
        public IEnumerable<StockModel> GetAll()
        {
            string getAllData = "SELECT * FROM  test";
            return GetDataFromSQLite(getAllData);
        }


        private void GetDetailFromSQLite(StockModel stockModel, string action)
        {
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = action;
                cmd.Parameters.Add("@id", DbType.Int32).Value = stockModel.id;
                cmd.Parameters.Add("@machine", DbType.String).Value = stockModel.machine;
                cmd.Parameters.Add("@pca", DbType.Int32).Value = stockModel.pca;
                cmd.Parameters.Add("@xinHua", DbType.Int32).Value = stockModel.xinhua;
                cmd.Parameters.Add("@aspoly", DbType.Int32).Value = stockModel.aSpoly;
                cmd.Parameters.Add("@arpoly", DbType.Int32).Value = stockModel.aRpoly;
                cmd.Parameters.Add("@hemlock", DbType.Int32).Value = stockModel.hemlock;

                cmd.Parameters.Add("@asdopant", DbType.Int32).Value = stockModel.asDopant;
                cmd.Parameters.Add("@phdopant", DbType.Int32).Value = stockModel.phDopant;
                cmd.Parameters.Add("@bdopant", DbType.Int32).Value = stockModel.bDopant;

                cmd.Parameters.Add("@aqm", DbType.Int32).Value = stockModel.aqm;
                cmd.Parameters.Add("@yoxing", DbType.Int32).Value = stockModel.yoxing;
                cmd.Parameters.Add("@aqmG3", DbType.Int32).Value = stockModel.aqmG3;
                cmd.Parameters.Add("@mejing", DbType.Int32).Value = stockModel.mejing;

                cmd.Parameters.Add("@time", DbType.DateTime).Value = stockModel.specifiedTime;
                cmd.ExecuteNonQuery();
            }
        }

        public int UpdateRemainStock(string stockName)
        {
            int remaingStock=0;
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT sum({stockName}) FROM test";
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        remaingStock= Convert.ToInt32(dr[0]);
                    }
                }
            }
            return remaingStock;
        }
    }
}
