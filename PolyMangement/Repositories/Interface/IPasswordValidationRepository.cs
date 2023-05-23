using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Repositories.Interface
{
    public interface IPasswordValidationRepository
    {
        bool IsPasswordIncorrect(string password);
        void ShowCorrectAmountWindows();
    }
}
