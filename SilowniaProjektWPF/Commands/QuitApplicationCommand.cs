
namespace SilowniaProjektWPF.Commands
{
    /// <summary>
    /// Logic for button used to exit application
    /// </summary>
    public class QuitApplicationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
