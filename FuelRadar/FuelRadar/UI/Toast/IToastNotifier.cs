using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.UI.Toast
{
    public interface IToastNotifier
    {
        void ShowToast(String message);
    }
}
