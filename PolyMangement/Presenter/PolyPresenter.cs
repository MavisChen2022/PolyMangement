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
            this.polyView.CancelEvent += CancelAction;
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
            polyView.IsEdit=false;
        }
        private void EditPoly(object sender, EventArgs e)
        {
            var poly = (PolyModel)polyBindingSource.Current;
            polyView.idText=poly.Id.ToString();
            polyView.machineNum= poly.Machine;
            polyView.PCAText=poly.Pca.ToString();
            polyView.XinhuaText=poly.Xinhua.ToString();
            polyView.ASText=poly.ASpoly.ToString();
            polyView.ARText=poly.ARpoly.ToString();
            polyView.HemlockText=poly.Hemlock.ToString();
            polyView.ASDopantText=poly.AsDopant.ToString();
            polyView.PHDopantText = poly.PhDopant.ToString();
            polyView.BDopantText = poly.BDopant.ToString();
            polyView.chargeTime= poly.Time.ToString();
            polyView.IsEdit=true;
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
            poly.AsDopant= Convert.ToInt32(polyView.ASDopantText);
            poly.PhDopant=Convert.ToInt32(polyView.PHDopantText);
            poly.BDopant= Convert.ToInt32(polyView.BDopantText);
            if (polyView.IsEdit)
            {
                poly.Id = Convert.ToInt32(polyView.idText);
                poly.Time = Convert.ToDateTime(polyView.chargeTime);
                polyRepository.Edit(poly);
            }
            else
            {
                poly.Time = DateTime.Now;
                polyRepository.Add(poly);
            }
            LoadAllStockList();
            CleanViewField();
        }
        private void DeleteRecord(object sender, EventArgs e)
        {
            var poly = (PolyModel)polyBindingSource.Current;
            polyRepository.Delete(poly.Id);
            LoadAllStockList();
        }
        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewField();
        }
        private void CleanViewField()
        {
            polyView.idText = null;
            polyView.machineNum = null;
            polyView.PCAText = null;
            polyView.XinhuaText = null;
            polyView.ASText = null;
            polyView.ARText = null;
            polyView.HemlockText = null;
            polyView.chargeTime = null;
            polyView.ASDopantText = null;
            polyView.PHDopantText = null;
            polyView.BDopantText = null;
            polyView.IsEdit = false;
        }
    }
}
