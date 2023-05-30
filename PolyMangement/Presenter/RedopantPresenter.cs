using PolyMangement.Model;
using PolyMangement.Repositories;
using PolyMangement.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
        private bool isEmpty=true;

        public RedopantPresenter(IRedopantView redopantView, IRedopantRepository redopantRepository)
        {
            this.redopantBindingSource=new BindingSource();
            this.redopantRepository = redopantRepository;
            this.redopantView = redopantView;

            redopantView.ValidInputValueEvent += ValidationInputValue;
            redopantView.ShowCorrespondRecipeEvent += ShowCorrespondRecipeRule;
            redopantView.UpdateRecipeNameEvent += UpdateRecipeName;
            redopantView.SetRedopantBindingSource(redopantBindingSource);
            
        }
        public void Show()
        {
            redopantView.Show();
        }
        private void HavingCompleteInformationCanDo()
        {
            if (isEmpty==false)
            {
                this.redopantView.CalculateTimeIntervalEvent += CalculateTimeInterval;  
                this.redopantView.CalRedopantEvent += CalRedopant;
            }
        }
        private void ValidationInputValue(object sender, EventArgs e) 
        {
            var model = new ValidationModel();
            model.startYear = redopantView.StartYearText;
            model.startMonthDay = redopantView.StartMonthDayText;
            model.startHourMins = redopantView.StartHourMinsText;
            model.endYear = redopantView.EndYearText;
            model.endMonthDay = redopantView.EndMonthDayText;
            model.endHourMins = redopantView.EndHourMinsText;
            try
            {
                new Coo.ModelDataValidtion().Validate(model);
                isEmpty = false;
                HavingCompleteInformationCanDo();
                redopantView.Message = "計算完成";
            }
            catch (Exception ex)
            {
                redopantView.Message = ex.Message;
            }
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
