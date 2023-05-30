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
        public static IMainView mainview;
        private readonly string sqliteConnectionString;
        private PolyPresenter _polyPresenter;
        private SearchPresenter _searchPresenter;
        private RedopantPresenter _redopantPresenter;
        private PasswordValidationPresenter _passwordValidationPresenter;

        public MainPresenter(IMainView mainvieww, string sqliteConnectionString)
        {
            mainview = mainvieww;
            this.sqliteConnectionString = sqliteConnectionString;
            mainview.ShowStockListEvent += StockListView;
            mainview.SearchStockListEvent += SearchStockListView;
            mainview.CalculateRedopantEvent += CalculateRedopantView;
            mainview.PasswordValidEvent += PasswordValidView;
        }

        private void StockListView(object sender, EventArgs e)
        {
            SetStockPresenter();
            ShowStockListView();
        }
        private void SetStockPresenter()
        {
            IPolyRepository polyRepository = new PolyRepository(sqliteConnectionString);
            IPolyView polyView = PolyView.GetInstance((Form)mainview);
            _polyPresenter = new PolyPresenter(polyView, polyRepository);
        }
        private void ShowStockListView()
        {
            _polyPresenter.Show();
        }

        private void SearchStockListView(object sender, EventArgs e)
        {
            SetSearchPresenter();
            ShowSearchView();
        }
        private void SetSearchPresenter()
        {
            ISearchRepository searchRepository = new SearchRepository(sqliteConnectionString);
            ISearchView searchView = SearchView.GetInstance((Form)mainview);
            _searchPresenter = new SearchPresenter(searchView, searchRepository);
        }
        private void ShowSearchView()
        {
            _searchPresenter.Show();
        }

        private void CalculateRedopantView(object sender, EventArgs e)
        {
            SetRedopantPresenter();
            ShowRedopantView();
        }
        private void SetRedopantPresenter()
        {
            IRedopantRepository redopantRepository = new RedopantRepository(sqliteConnectionString);
            IRedopantView redopantView = RedopantView.GetInstance((Form)mainview);
            _redopantPresenter = new RedopantPresenter(redopantView, redopantRepository);
        }
        private void ShowRedopantView()
        {
            _redopantPresenter.Show();
        }
        
        private void PasswordValidView(object sender, EventArgs e)
        {
            SetPasswordValidationPresenter();
            ShowPasswordValidationView();
        }
        private void SetPasswordValidationPresenter()
        {
            IPasswordValidationRepository passwordValidationRepository = new PasswordValidationRepository(sqliteConnectionString);
            IPasswordValidtionView passwordValidtionView = new PasswordValidtionView();
            _passwordValidationPresenter = new PasswordValidationPresenter(passwordValidtionView, passwordValidationRepository);
        }
        private void ShowPasswordValidationView()
        {
            _passwordValidationPresenter.Show();
        }
    }
}
