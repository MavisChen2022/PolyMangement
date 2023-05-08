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
        private IEnumerable<StockModel> stockList;

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
            var poly = (StockModel)polyBindingSource.Current;
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
            polyView.chargeTime= poly.SpecifiedTime.ToString();

            polyView.AqmRadio = poly.Aqm!=0;
            polyView.YoxingRad = poly.Yoxing != 0;
            polyView.AqmG3Rad= poly.AqmG3 != 0;
            polyView.MejingRad= poly.Mejing != 0;

            polyView.IsEdit=true;
        }
        private void SaveRecord(object sender, EventArgs e)
        {
            var poly = new StockModel();
           
            poly.Machine = polyView.machineNum;
            poly.Pca = int.TryParse(polyView.PCAText, out _) ? Convert.ToInt32(polyView.PCAText) : 0;
            poly.Xinhua = int.TryParse(polyView.XinhuaText, out _) ? Convert.ToInt32(polyView.XinhuaText) : 0;
            poly.ASpoly = int.TryParse(polyView.ASText, out _) ? Convert.ToInt32(polyView.ASText) : 0;
            poly.ARpoly = int.TryParse(polyView.ARText, out _) ? Convert.ToInt32(polyView.ARText) : 0;
            poly.Hemlock = int.TryParse(polyView.HemlockText, out _) ? Convert.ToInt32(polyView.HemlockText) : 0;
            poly.AsDopant = int.TryParse(polyView.ASDopantText, out _) ? Convert.ToInt32(polyView.ASDopantText) : 0;
            poly.PhDopant = int.TryParse(polyView.PHDopantText, out _) ? Convert.ToInt32(polyView.PHDopantText) : 0;
            poly.BDopant = int.TryParse(polyView.BDopantText, out _) ? Convert.ToInt32(polyView.BDopantText) : 0;

            poly.Aqm = Convert.ToInt32(polyView.AqmRadio);
            poly.Yoxing = Convert.ToInt32(polyView.YoxingRad);
            poly.AqmG3 = Convert.ToInt32(polyView.AqmG3Rad);
            poly.Mejing = Convert.ToInt32(polyView.MejingRad);

            if (polyView.IsEdit)
            {
                
                poly.Id = int.TryParse(polyView.idText, out _) ? Convert.ToInt32(polyView.idText) : 0;
                poly.SpecifiedTime = Convert.ToDateTime(polyView.chargeTime);
                polyRepository.Edit(poly);
            }
            else
            {
                poly.SpecifiedTime = DateTime.Now;
                polyRepository.Add(poly);
            }
            LoadAllStockList();
            CleanViewField();
        }
        private void DeleteRecord(object sender, EventArgs e)
        {
            var poly = (StockModel)polyBindingSource.Current;
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
