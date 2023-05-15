using PolyMangement.Model;
using PolyMangement.Presenter;
using PolyMangement.Repositories;
using PolyMangement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqliteConnectionString = @"URI=file:"+Application.StartupPath+"\\stockTable.db";
            
            IMainView mainView = new MainView();
            new MainPresenter(mainView, sqliteConnectionString);
            Application.Run((Form)mainView);
        }
    }
}
