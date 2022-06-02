using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Pass view model
    /// </summary>
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
