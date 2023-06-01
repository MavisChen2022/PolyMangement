using PolyMangement.Model;
using PolyMangement.Repositories;
using PolyMangement.Repositories.Implement;
using PolyMangement.Repositories.Interface;
using PolyMangement.View;
using PolyMangement.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Presenter
{
    public class CorrectAmountPresenter
    {
        private ICorrectAmountView correctAmountView;
        private ICorrectAmountRepository correctAmountRepository;

        public CorrectAmountPresenter(ICorrectAmountView correctAmountView, ICorrectAmountRepository correctAmountRepository)
        {
            this.correctAmountView = correctAmountView;
            this.correctAmountRepository = correctAmountRepository;

            UpdateRemainingStock();
            correctAmountView.CorrectEvent += CorrectAmount;
        }
        public void Show()
        {
            correctAmountView.Show();
        }

        private void CorrectAmount(object sender, EventArgs e)  
        {
            List<string> inventoryRecord= new List<string> { correctAmountView.poly1Text, correctAmountView.poly2Text, correctAmountView.poly3Text, correctAmountView.poly4Text, correctAmountView.poly5Text,correctAmountView.dopant1Text, correctAmountView.dopant2Text, correctAmountView.dopant3Text, correctAmountView.crucible1Text, correctAmountView.crucible2Text, correctAmountView.crucible3Text, correctAmountView.crucible4Text };
            List<string> endingInventory = new List<string> { correctAmountView.RemainPoly1, correctAmountView.RemainPoly2, correctAmountView.RemainPoly3, correctAmountView.RemainPoly4, correctAmountView.RemainPoly5, correctAmountView.RemainDopant1, correctAmountView.RemainDopant2, correctAmountView.RemainDopant3, correctAmountView.RemainCrucible1, correctAmountView.RemainCrucible2, correctAmountView.RemainCrucible3, correctAmountView.RemainCrucible4 };
            correctAmountRepository.Correct(inventoryRecord, endingInventory);
            UpdateRemainingStock();
        }
        private void UpdateRemainingStock()
        {
            correctAmountView.RemainPoly1 = correctAmountRepository.UpdateRemainStock("poly1").ToString();
            correctAmountView.RemainPoly2 = correctAmountRepository.UpdateRemainStock("poly2").ToString();
            correctAmountView.RemainPoly3 = correctAmountRepository.UpdateRemainStock("poly3").ToString();
            correctAmountView.RemainPoly4 = correctAmountRepository.UpdateRemainStock("poly4").ToString();
            correctAmountView.RemainPoly5 = correctAmountRepository.UpdateRemainStock("poly5").ToString();

            correctAmountView.RemainDopant1 = correctAmountRepository.UpdateRemainStock("dopant1").ToString();
            correctAmountView.RemainDopant2 = correctAmountRepository.UpdateRemainStock("dopant2").ToString();
            correctAmountView.RemainDopant3 = correctAmountRepository.UpdateRemainStock("dopant3").ToString();

            correctAmountView.RemainCrucible1 = correctAmountRepository.UpdateRemainStock("crucible1").ToString();
            correctAmountView.RemainCrucible2 = correctAmountRepository.UpdateRemainStock("crucible2").ToString();
            correctAmountView.RemainCrucible3 = correctAmountRepository.UpdateRemainStock("crucible3").ToString();
            correctAmountView.RemainCrucible4 = correctAmountRepository.UpdateRemainStock("crucible4").ToString();
        }
    }
}
