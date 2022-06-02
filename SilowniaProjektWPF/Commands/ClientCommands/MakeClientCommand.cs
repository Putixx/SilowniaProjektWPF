using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using SilowniaProjektWPF.DAL.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using SilowniaProjektWPF.Exceptions;

namespace SilowniaProjektWPF.Commands
{
    public class MakeClientCommand : AsyncCommandBase
    {
        private readonly MakeClientViewModel _makeClientViewModel;
        private readonly GymStore _gymStore;

        public MakeClientCommand(MakeClientViewModel MakeClientViewModel, GymStore GymStore)
        {
            _makeClientViewModel = MakeClientViewModel;
            _gymStore = GymStore;

            _makeClientViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeClientViewModel.Name) && 
                !string.IsNullOrEmpty(_makeClientViewModel.Surname) &&
                !string.IsNullOrEmpty(_makeClientViewModel.PhoneNumber) &&
                !string.IsNullOrEmpty(_makeClientViewModel.PassNumber) &&
                !string.IsNullOrEmpty(_makeClientViewModel.PassType) &&
                !string.IsNullOrEmpty(_makeClientViewModel.PurchaseDate.ToString()) &&
                !string.IsNullOrEmpty(_makeClientViewModel.ExpireDate.ToString()) &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Client Client = new Client(
                _makeClientViewModel.Name,
                _makeClientViewModel.Surname,
                _makeClientViewModel.PhoneNumber,
                _makeClientViewModel.PassNumber
                );

            Pass Pass = new Pass(
                _makeClientViewModel.PassNumber,
                _makeClientViewModel.PassType,
                _makeClientViewModel.PurchaseDate,
                _makeClientViewModel.ExpireDate
                );

            try
            {
                await _gymStore.MakeClient(Client);
                await _gymStore.MakePass(Pass);
                MessageBox.Show("Successfuly added new client.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ClientConflictException)
            {
                MessageBox.Show("Already existing client.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PassConflictException)
            {
                MessageBox.Show("Already taken pass.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to make reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeClientViewModel.Name) ||
                e.PropertyName == nameof(MakeClientViewModel.Surname) ||
                e.PropertyName == nameof(MakeClientViewModel.PhoneNumber) ||
                e.PropertyName == nameof(MakeClientViewModel.PassNumber) ||
                e.PropertyName == nameof(MakeClientViewModel.PassType) ||
                e.PropertyName == nameof(MakeClientViewModel.PurchaseDate) ||
                e.PropertyName == nameof(MakeClientViewModel.ExpireDate))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
