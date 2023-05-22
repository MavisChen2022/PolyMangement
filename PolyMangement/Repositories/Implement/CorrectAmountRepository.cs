using PolyMangement.Model;
using PolyMangement.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        public void Correct(List<string> inventoryRecord, List<string> endingInventory)
        {
            List<string> stockNameList = new List<string> { "pca", "xinhua", "aspoly", "arpoly", "hemlock", "asdopant", "phdopant", "bdopant", "aqm", "yoxing", "aqmG3", "mejing" };
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO test(machine,pca,xinhua,aspoly,arpoly,hemlock,asdopant,phdopant,bdopant,aqm,yoxing,aqmG3,mejing,time) 
                                    VALUES(@machine,@pca,@xinhua,@aspoly,@arpoly,@hemlock,@asdopant,@phdopant,@bdopant,@aqm,@yoxing,@aqmG3,@mejing,@time)";
                for (int i = 0; i < stockNameList.Count; i++)
                {
                    if (inventoryRecord[i] == "")
                    {
                        cmd.Parameters.Add(stockNameList[i],DbType.Int32).Value=0;
                    }
                    else
                    {
                        int different = Convert.ToInt32(inventoryRecord[i]) - Convert.ToInt32(endingInventory[i]);
                        cmd.Parameters.Add(stockNameList[i], DbType.Int32).Value = different;
                    }
                }
                cmd.Parameters.Add("@machine", DbType.String).Value = "修正數量";
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
