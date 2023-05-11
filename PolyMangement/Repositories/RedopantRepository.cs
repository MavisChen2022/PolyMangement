using PolyMangement.Model;
using System;
using System.Collections.Generic;
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

        public void CalTimeInterval(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public void ShowCorrespondRecipe(string recipeName)
        {
            throw new NotImplementedException();
        }
    }
}
