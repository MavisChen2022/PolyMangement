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
            this.polyView.SaveEvent += SaveRecord;

            this.polyView.SetPolyBindingSource(polyBindingSource);

            LoadAllStockList();
            polyView.Show();
        }

        private void SaveRecord(object sender, EventArgs e)
        {
            var poly = new PolyModel();
            poly.Machine = polyView.machineNum;
            poly.Pca = Convert.ToInt32(polyView.PCAText);
            poly.Xinhua = Convert.ToInt32(polyView.XinhuaText);
            poly.ASpoly = Convert.ToInt32(polyView.ASText);
            poly.ARpoly = Convert.ToInt32(polyView.ARText);
            poly.Hemlock = Convert.ToInt32(polyView.HemlockText);
            poly.Time = DateTime.Now;
            polyRepository.Add(poly);
            LoadAllStockList();
        }

        private void LoadAllStockList()
        {
            stockList = polyRepository.GetAll();
            polyBindingSource.DataSource = stockList;
        }

        private void AddPoly(object sender, EventArgs e)
        {
            var poly = new PolyModel();
            poly.Machine = polyView.machineNum;
            poly.Pca = Convert.ToInt32(polyView.PCAText);
            poly.Xinhua= Convert.ToInt32(polyView.XinhuaText);
            poly.ASpoly= Convert.ToInt32(polyView.ASText);
            poly.ARpoly= Convert.ToInt32(polyView.ARText);
            poly.Hemlock= Convert.ToInt32(polyView.HemlockText);
            poly.Time=DateTime.Now;
            polyRepository.Add(poly);
            LoadAllStockList();
        }

        private void EditPoly(object sender, EventArgs e)
        {
            var poly = (PolyModel)polyBindingSource.Current;
            polyView.machineNum= poly.Machine;
            polyView.PCAText=poly.Pca.ToString();
            polyView.XinhuaText=poly.Xinhua.ToString();
            polyView.ASText=poly.ASpoly.ToString();
            polyView.ARText=poly.ARpoly.ToString();
            polyView.HemlockText=poly.Hemlock.ToString();
            polyRepository.Edit(poly);
            LoadAllStockList();
        }

        private void DeleteRecord(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
