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
    public class PasswordValidationPresenter
    {
        IPasswordValidtionView passwordValidtionView;
        IPasswordValidationRepository passwordValidationRepository;

        public PasswordValidationPresenter(IPasswordValidtionView passwordValidtionView, IPasswordValidationRepository passwordValidationRepository)
        {
            this.passwordValidtionView = passwordValidtionView;
            this.passwordValidationRepository = passwordValidationRepository;
            passwordValidtionView.PasswordValidationEvent += PasswordValidation;
            passwordValidtionView.Show();
        }
        private void PasswordValidation(object sender, EventArgs e)
        {
            string password=passwordValidtionView.PasswordText;
            bool validationResult=passwordValidationRepository.IsPasswordIncorrect(password);
            if (!validationResult)
            {
                passwordValidationRepository.ShowCorrectAmountWindows();
                passwordValidtionView.CloseValidation();
            }
            else
            {
                MessageBox.Show("密碼錯誤");
            }
        }
    }
}
