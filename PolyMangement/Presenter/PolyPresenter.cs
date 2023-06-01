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
            polyView.RemainPoly1 = polyRepository.UpdateRemainStock("poly1").ToString();
            polyView.RemainPoly2 = polyRepository.UpdateRemainStock("poly2").ToString();
            polyView.RemainPoly3 = polyRepository.UpdateRemainStock("poly3").ToString();
            polyView.RemainPoly4 = polyRepository.UpdateRemainStock("poly4").ToString();
            polyView.RemainPoly5 = polyRepository.UpdateRemainStock("poly5").ToString();

            polyView.RemainDopant1 = polyRepository.UpdateRemainStock("dopant1").ToString();
            polyView.RemainDopant2 = polyRepository.UpdateRemainStock("dopant2").ToString();
            polyView.RemainDopant3 = polyRepository.UpdateRemainStock("dopant3").ToString();

            polyView.RemainCrucible1 = polyRepository.UpdateRemainStock("crucible1").ToString();
            polyView.RemainCrucible2 = polyRepository.UpdateRemainStock("crucible2").ToString();
            polyView.RemainCrucible3 = polyRepository.UpdateRemainStock("crucible3").ToString();
            polyView.RemainCrucible4 = polyRepository.UpdateRemainStock("crucible4").ToString();
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
            polyView.poly1Text = poly.poly1.ToString();
            polyView.poly2Text = poly.poly2.ToString();
            polyView.poly3Text = poly.poly3.ToString();
            polyView.poly4Text = poly.poly4.ToString();
            polyView.poly5Text = poly.poly5.ToString();
            polyView.dopant1Text = poly.dopant1.ToString();
            polyView.dopant2Text = poly.dopant2.ToString();
            polyView.dopant3Text = poly.dopant3.ToString();
            polyView.chargeTime= poly.specifiedTime.ToString();

            polyView.crucible1Rad = poly.crucible1!= 0;
            polyView.crucible2Rad = poly.crucible2!= 0;
            polyView.crucible3Rad= poly.crucible3!= 0;
            polyView.crucible4Rad= poly.crucible4!= 0;

            polyView.IsEdit=true;
        }
        private void SaveRecord(object sender, EventArgs e)
        {
            var poly = new StockModel();
           
            poly.machine = polyView.machineNum;
            poly.poly1 = int.TryParse(polyView.poly1Text, out _) ? Convert.ToInt32(polyView.poly1Text) : 0;
            poly.poly2 = int.TryParse(polyView.poly2Text, out _) ? Convert.ToInt32(polyView.poly2Text) : 0;
            poly.poly3 = int.TryParse(polyView.poly3Text, out _) ? Convert.ToInt32(polyView.poly3Text) : 0;
            poly.poly4 = int.TryParse(polyView.poly4Text, out _) ? Convert.ToInt32(polyView.poly4Text) : 0;
            poly.poly5 = int.TryParse(polyView.poly5Text, out _) ? Convert.ToInt32(polyView.poly5Text) : 0;
            poly.dopant1 = int.TryParse(polyView.dopant1Text, out _) ? Convert.ToInt32(polyView.dopant1Text) : 0;
            poly.dopant2 = int.TryParse(polyView.dopant2Text, out _) ? Convert.ToInt32(polyView.dopant2Text) : 0;
            poly.dopant3 = int.TryParse(polyView.dopant3Text, out _) ? Convert.ToInt32(polyView.dopant3Text) : 0;

            poly.crucible1 = Convert.ToInt32(polyView.crucible1Rad);
            poly.crucible2 = Convert.ToInt32(polyView.crucible2Rad);
            poly.crucible3 = Convert.ToInt32(polyView.crucible3Rad);
            poly.crucible4 = Convert.ToInt32(polyView.crucible4Rad);

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
            polyView.poly1Text = null;
            polyView.poly2Text = null;
            polyView.poly3Text = null;
            polyView.poly4Text = null;
            polyView.poly5Text = null;
            polyView.chargeTime = null;
            polyView.dopant1Text = null;
            polyView.dopant2Text = null;
            polyView.dopant3Text = null;
            polyView.IsEdit = false;
        }
    }
}
