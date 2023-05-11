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

            this.redopantView.CalTimeIntervalEvent += CalTimeInterval;
            this.redopantView.CalRedopantEvent += CalRedopant;
            this.redopantView.SetRedopantBindingSource(redopantBindingSource);
            //ShowCorrespondRecipeRule();
            redopantView.Show();
        }

        private void ShowCorrespondRecipeRule()
        {
            throw new NotImplementedException();
        }

        private void CalTimeInterval(object sender, EventArgs e)
        {
            //redopantView.RealText=redopantRepository.CalTimeInterval()
            throw new NotImplementedException();
        }

        private void CalRedopant(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
