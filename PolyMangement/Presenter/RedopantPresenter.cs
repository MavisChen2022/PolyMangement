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
    public class RedopantPresenter
    {
        private IRedopantRepository redopantRepository;
        private IRedopantView redopantView;
        private BindingSource redopantBindingSource;
        private IEnumerable<RedopantModel> redopantsRecipe;

        public RedopantPresenter(IRedopantView redopantView, IRedopantRepository redopantRepository)
        {
            this.redopantBindingSource=new BindingSource();
            this.redopantRepository = redopantRepository;
            this.redopantView = redopantView;

            this.redopantView.CalculateTimeIntervalEvent += CalculateTimeInterval;
            //this.redopantView.CalRedopantEvent += CalRedopant;
            this.redopantView.SetRedopantBindingSource(redopantBindingSource);
            ShowCorrespondRecipeRule();
            redopantView.Show();
        }

        private void ShowCorrespondRecipeRule()   //指定秀出RecipeA還沒有實作，目前吐回來的是全部的rule
        {
            redopantsRecipe=redopantRepository.ShowCorrespondRecipe("RecipeA");
            redopantBindingSource.DataSource = redopantsRecipe;
        }

        private void CalculateTimeInterval(object sender, EventArgs e) 
        {
            string startTime = redopantRepository.ChangeTimeFormat(redopantView.StartYearText, redopantView.StartMonthDayText, redopantView.StartHourMinsText);
            string endTime = redopantRepository.ChangeTimeFormat(redopantView.EndYearText, redopantView.EndMonthDayText, redopantView.EndHourMinsText);
            redopantView.RealText = Math.Round(redopantRepository.CalculateTimeInterval(startTime, endTime), 2).ToString();
            redopantView.RemeltText = Math.Floor(redopantRepository.CalculateTimeInterval(startTime, endTime)).ToString();

        }

        private void CalRedopant(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
