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

            polyView.AddEvent += AddPoly;
            polyView.EditEvent += EditPoly;
            polyView.DeleteEvent += DeleteRecord;
            polyView.SaveEvent += SaveRecord;
            polyView.SetPolyBindingSource(polyBindingSource);
            UpdateRemainingStock();
            LoadAllStockList();
        }
        public void Show()
        {
            polyView.Show();
        }

        private void UpdateRemainingStock()  
        {
            polyView.RemainPCA = polyRepository.UpdateRemainStock("pca").ToString();
            polyView.RemainXinhua = polyRepository.UpdateRemainStock("xinhua").ToString();
            polyView.RemainAS = polyRepository.UpdateRemainStock("aspoly").ToString();
            polyView.RemainAR = polyRepository.UpdateRemainStock("arpoly").ToString();
            polyView.RemainHemLock = polyRepository.UpdateRemainStock("hemlock").ToString();

            polyView.RemainASDopant = polyRepository.UpdateRemainStock("asdopant").ToString();
            polyView.RemainPHDopant = polyRepository.UpdateRemainStock("phdopant").ToString();
            polyView.RemainBDopant = polyRepository.UpdateRemainStock("bdopant").ToString();

            polyView.RemainAQM = polyRepository.UpdateRemainStock("aqm").ToString();
            polyView.RemainYoXing = polyRepository.UpdateRemainStock("yoxing").ToString();
            polyView.RemainAQMG3 = polyRepository.UpdateRemainStock("aqmg3").ToString();
            polyView.RemainMeJing = polyRepository.UpdateRemainStock("mejing").ToString();
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
            polyView.idText=poly.id.ToString();
            polyView.machineNum= poly.machine;
            polyView.PCAText=poly.pca.ToString();
            polyView.XinhuaText=poly.xinhua.ToString();
            polyView.ASText=poly.aSpoly.ToString();
            polyView.ARText=poly.aRpoly.ToString();
            polyView.HemlockText=poly.hemlock.ToString();
            polyView.ASDopantText=poly.asDopant.ToString();
            polyView.PHDopantText = poly.phDopant.ToString();
            polyView.BDopantText = poly.bDopant.ToString();
            polyView.chargeTime= poly.specifiedTime.ToString();

            polyView.AqmRadio = poly.aqm!=0;
            polyView.YoxingRad = poly.yoxing != 0;
            polyView.AqmG3Rad= poly.aqmG3 != 0;
            polyView.MejingRad= poly.mejing != 0;

            polyView.IsEdit=true;
        }
        private void SaveRecord(object sender, EventArgs e)
        {
            var poly = new StockModel();
           
            poly.machine = polyView.machineNum;
            poly.pca = int.TryParse(polyView.PCAText, out _) ? Convert.ToInt32(polyView.PCAText) : 0;
            poly.xinhua = int.TryParse(polyView.XinhuaText, out _) ? Convert.ToInt32(polyView.XinhuaText) : 0;
            poly.aSpoly = int.TryParse(polyView.ASText, out _) ? Convert.ToInt32(polyView.ASText) : 0;
            poly.aRpoly = int.TryParse(polyView.ARText, out _) ? Convert.ToInt32(polyView.ARText) : 0;
            poly.hemlock = int.TryParse(polyView.HemlockText, out _) ? Convert.ToInt32(polyView.HemlockText) : 0;
            poly.asDopant = int.TryParse(polyView.ASDopantText, out _) ? Convert.ToInt32(polyView.ASDopantText) : 0;
            poly.phDopant = int.TryParse(polyView.PHDopantText, out _) ? Convert.ToInt32(polyView.PHDopantText) : 0;
            poly.bDopant = int.TryParse(polyView.BDopantText, out _) ? Convert.ToInt32(polyView.BDopantText) : 0;

            poly.aqm = Convert.ToInt32(polyView.AqmRadio);
            poly.yoxing = Convert.ToInt32(polyView.YoxingRad);
            poly.aqmG3 = Convert.ToInt32(polyView.AqmG3Rad);
            poly.mejing = Convert.ToInt32(polyView.MejingRad);

            if (polyView.IsEdit)
            {
                poly.id = int.TryParse(polyView.idText, out _) ? Convert.ToInt32(polyView.idText) : 0;
                poly.specifiedTime = Convert.ToDateTime(polyView.chargeTime);
                polyRepository.Edit(poly);
            }
            else
            {
                poly.specifiedTime = DateTime.Now;
                polyRepository.Add(poly);
            }
            LoadAllStockList();
            UpdateRemainingStock();
            CleanViewField();
        }
        private void DeleteRecord(object sender, EventArgs e)
        {
            var poly = (StockModel)polyBindingSource.Current;
            polyRepository.Delete(poly.id);
            LoadAllStockList();
            UpdateRemainingStock();
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
