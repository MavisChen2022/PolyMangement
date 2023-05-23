using PolyMangement.Presenter;
using PolyMangement.Repositories.Interface;
using PolyMangement.View.Interface;
using PolyMangement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.Repositories.Implement
{
    public class PasswordValidationRepository : BaseRepository,IPasswordValidationRepository
    {
        private CorrectAmountPresenter _correctAmountPresenter;
        public PasswordValidationRepository(string connection)
        {
            connectionString = connection;
        }
        //密碼:123
        private readonly string Password = "2WNA7gXfRKzo8ePz3XnqRbhOouNsl6FIM0XvTUa/l2g=";
        public bool IsPasswordIncorrect(string password)  
        {
            var hashPwd = HashPassword(password);
            return hashPwd!= Password? true:false;
        }

        private string HashPassword(string password)
        {
            const string saltKey = "apple";
            var saltAndPassword=string.Concat(password, saltKey);
            var sHa256Hasher=SHA256.Create();
            var passwordData=Encoding.Default.GetBytes(saltAndPassword);
            var hashData=sHa256Hasher.ComputeHash(passwordData);
            string hashedPwd = Convert.ToBase64String(hashData);
            return hashedPwd;
        }

        public void ShowCorrectAmountWindows()
        {
            SetCorrectAmountPresenter();
            ShowCorrectAmountView();
        }
        private void SetCorrectAmountPresenter()
        {
            ICorrectAmountRepository correctAmountRepository = new CorrectAmountRepository(connectionString);
            ICorrectAmountView correctAmountView = CorrectAmountView.GetInstance((Form)MainPresenter.mainview);
            _correctAmountPresenter =new CorrectAmountPresenter(correctAmountView, correctAmountRepository);
        }
        private void ShowCorrectAmountView()
        {
            _correctAmountPresenter.Show();
        }
    }
}
