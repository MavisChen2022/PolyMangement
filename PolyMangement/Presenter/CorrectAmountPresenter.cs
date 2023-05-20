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
            correctAmountView.Show();
        }

        private void CorrectAmount(object sender, EventArgs e)  //暫時先寫成指定只有修正PCA
        {
            string pca = correctAmountView.PCAText;
            string realpca = correctAmountView.RemainPCA;
            correctAmountRepository.Correct(pca, realpca);
            UpdateRemainingStock();
        }
        private void UpdateRemainingStock()
        {
            correctAmountView.RemainPCA = correctAmountRepository.UpdateRemainStock("pca").ToString();
            correctAmountView.RemainXinhua = correctAmountRepository.UpdateRemainStock("xinhua").ToString();
            correctAmountView.RemainAS = correctAmountRepository.UpdateRemainStock("aspoly").ToString();
            correctAmountView.RemainAR = correctAmountRepository.UpdateRemainStock("arpoly").ToString();
            correctAmountView.RemainHemLock = correctAmountRepository.UpdateRemainStock("hemlock").ToString();

            correctAmountView.RemainASDopant = correctAmountRepository.UpdateRemainStock("asdopant").ToString();
            correctAmountView.RemainPHDopant = correctAmountRepository.UpdateRemainStock("phdopant").ToString();
            correctAmountView.RemainBDopant = correctAmountRepository.UpdateRemainStock("bdopant").ToString();

            correctAmountView.RemainAQM = correctAmountRepository.UpdateRemainStock("aqm").ToString();
            correctAmountView.RemainYoXing = correctAmountRepository.UpdateRemainStock("yoxing").ToString();
            correctAmountView.RemainAQMG3 = correctAmountRepository.UpdateRemainStock("aqmg3").ToString();
            correctAmountView.RemainMeJing = correctAmountRepository.UpdateRemainStock("mejing").ToString();
        }
    }
}
