using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.View.Interface
{
    public interface IPasswordValidtionView
    {
        string PasswordText { get; }
        event EventHandler PasswordValidationEvent;
        void CloseValidation();
        void Show();
    }
}
