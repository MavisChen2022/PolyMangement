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
        private IEnumerable<StockModel> searchList;

        public SearchPresenter(ISearchView searchView, ISearchRepository searchRepository)
        {
            this.SearchBindingSource=new BindingSource();
            this.searchView = searchView;
            this.searchRepository = searchRepository;

            searchView.SearchEvent += SearchSpecifiedDate;
            searchView.ExportExcelEvent += ExportExcelFile;

            searchView.SetSearchBindingSource(SearchBindingSource);
            LoadCurrentCondition();
            searchView.Show();
        }

        private void LoadCurrentCondition()
        {
            searchView.IsExportCurrentFile = true;
            var shift = "當班使用情況";
            var searchTime = new StockModel();
            searchTime.specifiedTime = DateTime.Now;
            searchList = searchRepository.GetByValue(searchTime.specifiedTime, shift);
            SearchBindingSource.DataSource = searchList;
        }

        private void SearchSpecifiedDate(object sender, EventArgs e) 
        {
            var shift=searchView.DayNight.ToString();
            var searchTime = new StockModel();
            if (shift == "日班" || shift == "夜班")
            {
                searchView.IsExportCurrentFile = false;
                searchTime.specifiedTime = searchView.SearchTime;
                
            }
            else
            {
                searchView.IsExportCurrentFile = true;
                searchView.SearchTime=DateTime.Now;
                shift = "當班使用情況";
                searchTime.specifiedTime = DateTime.Now;
            }
            searchList = searchRepository.GetByValue(searchTime.specifiedTime, shift);
            SearchBindingSource.DataSource = searchList;
        }

        private void ExportExcelFile(object sender, EventArgs e)  
        {
            var shift = searchView.DayNight.ToString();
            var searchTime = new StockModel();
            if (searchView.IsExportCurrentFile)
            {
                searchTime.specifiedTime = DateTime.Now;
            }
            else
            {
                searchTime.specifiedTime = searchView.SearchTime;
            }
            searchRepository.ExportExcel(searchTime.specifiedTime, shift);
        }
    }
}
