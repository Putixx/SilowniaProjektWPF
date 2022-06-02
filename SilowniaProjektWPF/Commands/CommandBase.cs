using System;
using System.Windows.Input;

namespace SilowniaProjektWPF.Commands
{
    /// <summary>
    /// Command base for buttons that are not used async
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
