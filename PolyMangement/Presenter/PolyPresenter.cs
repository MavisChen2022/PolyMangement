using PolyMangement.Model;
using PolyMangement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.Presenter
{
    public class PolyPresenter
    {
        private IPolyView polyView;
        private IPolyRepository polyRepository;
        private BindingSource polyBindingSource;
        private IEnumerable<PolyModel> stockList;

        public PolyPresenter(IPolyView polyView, IPolyRepository polyRepository)
        {
            this.polyBindingSource = new BindingSource();
            this.polyView = polyView;
            this.polyRepository = polyRepository;

            this.polyView.AddEvent += AddPoly;
            this.polyView.EditEvent += EditPoly;
            this.polyView.DeleteEvent += DeleteRecord;

            this.polyView.SetPolyBindingSource(polyBindingSource);

            LoadAllStockList();
            polyView.Show();
        }

        private void LoadAllStockList()
        {
            stockList = polyRepository.GetAll();
            polyBindingSource.DataSource = stockList;
        }

        private void AddPoly(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditPoly(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteRecord(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
