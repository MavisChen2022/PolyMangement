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
    public class SearchPresenter
    {
        private ISearchView searchView;
        private ISearchRepository searchRepository;
        private BindingSource SearchBindingSource;
        private IEnumerable<SearchModel> searchList;

        public SearchPresenter(ISearchView searchView, ISearchRepository searchRepository)
        {
            this.SearchBindingSource=new BindingSource();
            this.searchView = searchView;
            this.searchRepository = searchRepository;

            this.searchView.SearchEvent += SearchSpecifiedDate;
            this.searchView.OutputExcelEvent += OutoutExcelFile;

            this.searchView.SetSearchBindingSource(SearchBindingSource);
            LoadCurrentCondition();
            this.searchView.Show();
        }

        private void LoadCurrentCondition()//還沒實作此功能，先寫成撈全部資料;GetNow也是先寫成撈全部資料
        {
            searchList = searchRepository.GetNow();
            SearchBindingSource.DataSource = searchList;
        }

        private void SearchSpecifiedDate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OutoutExcelFile(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
