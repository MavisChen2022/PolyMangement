using PolyMangement.Model;
using PolyMangement.Repositories;
using PolyMangement.View;
using System;
using System.Collections.Generic;
using System.Data;
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
        private DataTable redopantsRecipe;

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
            redopantsRecipe=redopantRepository.ShowCorrespondRecipe("RecipeB");
            redopantBindingSource.DataSource = redopantsRecipe;

        }

        private void CalculateTimeInterval(object sender, EventArgs e) 
        {
            redopantRepository.StartTimeFormat(redopantView.StartYearText, redopantView.StartMonthDayText, redopantView.StartHourMinsText);
            redopantRepository.EndTimeFormat(redopantView.EndYearText, redopantView.EndMonthDayText, redopantView.EndHourMinsText);
            redopantRepository.CalTimeInterval();
            redopantView.RealText = redopantRepository.realTimeText;
            redopantView.RuleText = redopantRepository.ruleTimeText;

        }

        private void CalRedopant(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
