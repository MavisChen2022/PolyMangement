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
        void Add(PolyModel polymodel);
        void Edit(PolyModel polymodel);
        void Delete(int id);

        IEnumerable<PolyModel> GetAll();
        IEnumerable<PolyModel> GetByValue(PolyModel polymodel);

        void SetPolyBindingSource(BindingSource polyList);
    }
}
