using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories.Interface
{
    public interface ICorrectAmountRepository
    {
        int UpdateRemainStock(string stockName);
        void Correct(string poly, string realpoly);
    }
}
