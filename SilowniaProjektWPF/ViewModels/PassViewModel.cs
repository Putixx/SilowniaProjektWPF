using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.ViewModels
{
    public class PassViewModel : ViewModelBase
    {
        private readonly Pass _pass;

        public string PassNumber => _pass.PassNumber;
        public string PassType => _pass.PassType;
        public DateTime PurchaseDate => _pass.PurchaseDate;
        public DateTime ExpireDate => _pass.ExpireDate;

        public PassViewModel(Pass pass)
        {
            _pass = pass;
        }
    }
}
