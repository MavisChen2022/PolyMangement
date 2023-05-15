﻿using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories
{
    public class RedopantRepository:BaseRepository,IRedopantRepository
    {
        public RedopantRepository(string connection)
        {
            connectionString=connection;
        }

        public void CalRedopant(string timeInterval)
        {
            throw new NotImplementedException();
        }

        public double CalculateTimeInterval(string startTime, string endTime)
        {
            var s = Convert.ToDateTime(startTime);
            var e=Convert.ToDateTime(endTime);
            TimeSpan ts = e - s;
            double hrs = ts.TotalSeconds / 3600;
            return hrs;
        }

        public string ChangeTimeFormat(string year, string monthDay, string hourMins)
        {
            var hourMin = hourMins.Insert(2, ":");
            return year + "/" + monthDay + " " + hourMin;
        }

        public IEnumerable<RedopantModel> ShowCorrespondRecipe(string recipeName)  //指定秀出RecipeA還沒有實作，目前裡面的實際功能是一次秀全部
        {
            var rule = new List<RedopantModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT * FROM redopantTest";
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var correspond = new RedopantModel();
                        correspond.Hour = Convert.ToInt32(dr[0]);
                        correspond.RecipeA = dr[1].ToString();
                        correspond.RecipeB = dr[2].ToString();
                        rule.Add(correspond);
                    }
                }
            }
            return rule;
        }
    }
}
