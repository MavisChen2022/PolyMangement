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
            var searchTime = new SearchModel();
            searchTime.SpecifiedTime = DateTime.Now;
            searchList = searchRepository.GetNow(searchTime.SpecifiedTime);
            SearchBindingSource.DataSource = searchList;
        }

        private void SearchSpecifiedDate(object sender, EventArgs e) 
        {
            var shift=searchView.DayNight.ToString();
            if (shift == "日班" || shift == "夜班")
            {
                searchView.IsExportCurrentFile = false;
                var searchTime = new SearchModel();
                searchTime.SpecifiedTime = searchView.SearchTime;
                searchList = searchRepository.GetByValue(searchTime.SpecifiedTime, shift);
                SearchBindingSource.DataSource = searchList;
            }
            else
            {
                searchView.IsExportCurrentFile = true;
                searchView.SearchTime=DateTime.Now;
                LoadCurrentCondition();
            }
        }

        private void ExportExcelFile(object sender, EventArgs e)     //暫時寫成輸出全部的資料
        {
            if (searchView.IsExportCurrentFile)
            {
                var searchTime = new SearchModel();
                searchTime.SpecifiedTime = DateTime.Now;
                searchList = searchRepository.GetNow(searchTime.SpecifiedTime);
                SearchBindingSource.DataSource = searchList;
                searchRepository.ExportExcel(searchTime);
            }
        }
    }
}
