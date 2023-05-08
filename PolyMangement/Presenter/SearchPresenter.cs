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
            this.searchView.ExportExcelEvent += ExportExcelFile;

            this.searchView.SetSearchBindingSource(SearchBindingSource);
            LoadCurrentCondition();
            this.searchView.Show();
        }

        private void LoadCurrentCondition()
        {
            searchView.IsExportCurrentFile = true;
            var shift = "當班使用情況";
            var searchTime = new SearchModel();
            searchTime.SpecifiedTime = DateTime.Now;
            searchList = searchRepository.GetByValue(searchTime.SpecifiedTime, shift);
            SearchBindingSource.DataSource = searchList;
        }

        private void SearchSpecifiedDate(object sender, EventArgs e) 
        {
            var shift=searchView.DayNight.ToString();
            var searchTime = new SearchModel();
            if (shift == "日班" || shift == "夜班")
            {
                searchView.IsExportCurrentFile = false;
                searchTime.SpecifiedTime = searchView.SearchTime;
                
            }
            else
            {
                searchView.IsExportCurrentFile = true;
                searchView.SearchTime=DateTime.Now;
                shift = "當班使用情況";
                searchTime.SpecifiedTime = DateTime.Now;
            }
            searchList = searchRepository.GetByValue(searchTime.SpecifiedTime, shift);
            SearchBindingSource.DataSource = searchList;
        }

        private void ExportExcelFile(object sender, EventArgs e)  
        {
            var shift = searchView.DayNight.ToString();
            var searchTime = new SearchModel();
            if (searchView.IsExportCurrentFile)
            {
                searchTime.SpecifiedTime = DateTime.Now;
            }
            else
            {
                searchTime.SpecifiedTime = searchView.SearchTime;
            }
            searchRepository.ExportExcel(searchTime.SpecifiedTime, shift);
        }
    }
}
