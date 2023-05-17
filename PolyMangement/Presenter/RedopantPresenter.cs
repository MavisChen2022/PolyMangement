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
        public RedopantView view;
        private IRedopantRepository redopantRepository;
        private IRedopantView redopantView;
        private BindingSource redopantBindingSource;
        private DataTable redopantsRecipe;

        public RedopantPresenter(IRedopantView redopantView, IRedopantRepository redopantRepository)
        {
            this.redopantBindingSource=new BindingSource();
            this.redopantRepository = redopantRepository;
            this.redopantView = redopantView;
           
            this.redopantView.CalculateTimeIntervalEvent += CalculateTimeInterval;  //測完季的記得取消註解+改回來
            this.redopantView.ShowCorrespondRecipeEvent += ShowCorrespondRecipeRule; 
            this.redopantView.UpdateRecipeNameEvent += UpdateRecipeName;
            this.redopantView.CalRedopantEvent += CalRedopant;
            this.redopantView.SetRedopantBindingSource(redopantBindingSource);
            redopantView.Show();
        }

        private void UpdateRecipeName(object sender, EventArgs e)
        {
            redopantView.RecipeNameText = redopantView.RecipeName;
        }
        private void CalculateTimeInterval(object sender, EventArgs e) 
        {
            redopantRepository.StartTimeFormat(redopantView.StartYearText, redopantView.StartMonthDayText, redopantView.StartHourMinsText);
            redopantRepository.EndTimeFormat(redopantView.EndYearText, redopantView.EndMonthDayText, redopantView.EndHourMinsText);
            redopantRepository.CalTimeInterval();
            redopantView.RealText = redopantRepository.realTimeText;
            redopantView.RuleText = redopantRepository.ruleTimeText;

        }
        private void ShowCorrespondRecipeRule(object sender, EventArgs e)  
        {
            string recipeName = redopantView.RecipeName;
            string neckTimes = redopantView.NeckTimes;
            redopantsRecipe =redopantRepository.ShowCorrespondRecipe(recipeName, neckTimes);
            redopantBindingSource.DataSource = redopantsRecipe;
        }
        private void CalRedopant(object sender, EventArgs e)
        {
            string recipeName = redopantView.RecipeName;
            string hour = redopantView.RuleText;
            string neckTimes = redopantView.NeckTimes;
            redopantView.RedopantWeightText = redopantRepository.CalRedopant(recipeName,hour, neckTimes);
        }
    }
}
