using PolyMangement.Model;
using PolyMangement.Repositories;
using PolyMangement.Repositories.Implement;
using PolyMangement.Repositories.Interface;
using PolyMangement.View;
using PolyMangement.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.Presenter
{
    public class MainPresenter
    {
        private IMainView mainview;
        private readonly string sqliteConnectionString;

        public MainPresenter(IMainView mainview, string sqliteConnectionString)
        {
            this.mainview = mainview;
            this.sqliteConnectionString = sqliteConnectionString;
            this.mainview.ShowStockListEvent += ShowStockListView;
            this.mainview.SearchStockListEvent += SearchStockListView;
            this.mainview.CalculateRedopantEvent += CalculateRedopantView;
            this.mainview.CorrectAmountEvent += CorrectStockAmountView;
        }

       

        private void CalculateRedopantView(object sender, EventArgs e)
        {
            IRedopantRepository redopantRepository = new RedopantRepository(sqliteConnectionString);
            IRedopantView redopantView = RedopantView.GetInstance((Form)mainview);
            new RedopantPresenter(redopantView, redopantRepository);
        }

        private void SearchStockListView(object sender, EventArgs e)
        {
            ISearchRepository searchRepository=new SearchRepository(sqliteConnectionString);
            ISearchView searchView = SearchView.GetInstance((Form)mainview);
            new SearchPresenter(searchView, searchRepository);
        }

        private void ShowStockListView(object sender, EventArgs e)
        {
            IPolyRepository polyRepository = new PolyRepository(sqliteConnectionString);
            IPolyView polyView = PolyView.GetInstance((Form)mainview);
            new PolyPresenter(polyView, polyRepository);
        }
        private void CorrectStockAmountView(object sender, EventArgs e)
        {
            ICorrectAmountRepository correctAmountRepository=new CorrectAmountRepository(sqliteConnectionString);
            ICorrectAmountView correctAmountView= CorrectAmountView.GetInstance((Form)mainview);
            new CorrectAmountPresenter(correctAmountView, correctAmountRepository);
        }
    }
}
