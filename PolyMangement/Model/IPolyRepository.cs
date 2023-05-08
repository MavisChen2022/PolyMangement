using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.Model
{
    public interface IPolyRepository
    {
        void Add(StockModel stockModel);
        void Edit(StockModel stockModel);
        void Delete(int id);

        IEnumerable<StockModel> GetAll();

    }
}
