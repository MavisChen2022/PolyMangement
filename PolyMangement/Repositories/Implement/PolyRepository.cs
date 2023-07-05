using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
            string addCommand= @"INSERT INTO test(machine,poly1,poly2,poly3,poly4,poly5,dopant1,dopant2,dopant3,crucible1,crucible2,crucible3,crucible4,time) 
                                 VALUES(@machine,@poly1,@poly2,@poly3,@poly4,@poly5,@dopant1,@dopant2,@dopant3,@crucible1,@crucible2,@crucible3,@crucible4,@time)";
            GetDetailFromSQLite(stockModel, addCommand);
        }
        public void Edit(StockModel stockModel)
        {
            string editCommand = @"UPDATE test 
                                  SET machine=@machine,poly1=@poly1,poly2=@poly2,poly3=@poly3,poly4=@poly4,poly5=@poly5
                                  ,dopant1=@dopant1,dopant2=@dopant2,dopant3=@dopant3,crucible1=@crucible1,crucible2=@crucible2,crucible3=@crucible3,crucible4=@crucible4
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
                cmd.Parameters.Add("@poly1", DbType.Int32).Value = stockModel.poly1;
                cmd.Parameters.Add("@poly2", DbType.Int32).Value = stockModel.poly2;
                cmd.Parameters.Add("@poly3", DbType.Int32).Value = stockModel.poly3;
                cmd.Parameters.Add("@poly4", DbType.Int32).Value = stockModel.poly4;
                cmd.Parameters.Add("@poly5", DbType.Int32).Value = stockModel.poly5;

                cmd.Parameters.Add("@dopant1", DbType.Int32).Value = stockModel.dopant1;
                cmd.Parameters.Add("@dopant2", DbType.Int32).Value = stockModel.dopant2;
                cmd.Parameters.Add("@dopant3", DbType.Int32).Value = stockModel.dopant3;

                cmd.Parameters.Add("@crucible1", DbType.Int32).Value = stockModel.crucible1;
                cmd.Parameters.Add("@crucible2", DbType.Int32).Value = stockModel.crucible2;
                cmd.Parameters.Add("@crucible3", DbType.Int32).Value = stockModel.crucible3;
                cmd.Parameters.Add("@crucible4", DbType.Int32).Value = stockModel.crucible4;

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
        public Color StockSafety(int current,int stockSafety)
        {
            return current <= stockSafety ? Color.Red : Color.Black;
        }
    }
}
