using PolyMangement.Model;
using PolyMangement.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories.Implement
{
    public class CorrectAmountRepository : BaseRepository,ICorrectAmountRepository
    {
        public CorrectAmountRepository(string connection)
        {
            connectionString = connection;
        }
        public void Correct(string poly, string realpoly)  //待改成只要代入 物品名、帳上、實際 這三個參數就能對指定物品數量做修正
        {
            int different = Convert.ToInt32(poly) - Convert.ToInt32(realpoly);
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO test(machine,pca,xinhua,aspoly,arpoly,hemlock,asdopant,phdopant,bdopant,aqm,yoxing,aqmG3,mejing,time) 
                                 VALUES(@machine,@pca,@xinhua,@aspoly,@arpoly,@hemlock,@asdopant,@phdopant,@bdopant,@aqm,@yoxing,@aqmG3,@mejing,@time)";
                cmd.Parameters.Add("@machine", DbType.String).Value = "修正";
                cmd.Parameters.Add("@pca", DbType.Int32).Value = different;
                cmd.Parameters.Add("@xinHua", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@aspoly", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@arpoly", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@hemlock", DbType.Int32).Value = 0;

                cmd.Parameters.Add("@asdopant", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@phdopant", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@bdopant", DbType.Int32).Value = 0;

                cmd.Parameters.Add("@aqm", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@yoxing", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@aqmG3", DbType.Int32).Value = 0;
                cmd.Parameters.Add("@mejing", DbType.Int32).Value = 0;

                cmd.Parameters.Add("@time", DbType.DateTime).Value = DateTime.Now;
                cmd.ExecuteNonQuery();

            }
        }
        public int UpdateRemainStock(string stockName)
        {
            int remaingStock = 0;
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
                        remaingStock = Convert.ToInt32(dr[0]);
                    }
                }
            }
            return remaingStock;
        }
       
    }
}
