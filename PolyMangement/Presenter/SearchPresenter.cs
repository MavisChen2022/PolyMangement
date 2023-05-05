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

        private void SearchSpecifiedDate(object sender, EventArgs e) //日班0點~24點功能已完成，待調整至0800~2000
        {
            if (searchView.DayNight == "日班")
            {
                var searchTime = new SearchModel();
                searchTime.SpecifiedTime = searchView.SearchTime;
                searchList = searchRepository.GetByValue(searchTime.SpecifiedTime);
                SearchBindingSource.DataSource = searchList;
            }
            else if(searchView.DayNight == "夜班")
            {
                throw new NotImplementedException();
            }
            else
            {
                LoadCurrentCondition();
            }
        }

        private void OutoutExcelFile(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
