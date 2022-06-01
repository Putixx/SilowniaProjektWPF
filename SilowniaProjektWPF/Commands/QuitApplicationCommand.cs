using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Commands
{
    public class QuitApplicationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
