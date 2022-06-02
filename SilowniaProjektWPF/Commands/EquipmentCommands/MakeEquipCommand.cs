using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    /// <summary>
    /// Logic for button that adds new equipment
    /// </summary>
    public class MakeEquipCommand : AsyncCommandBase
    {
        private readonly MakeEquipmentViewModel _makeEquipmentViewModel;
        private readonly GymStore _gymStore;

        public MakeEquipCommand(MakeEquipmentViewModel MakeEquipViewModel, GymStore GymStore)
        {
            _makeEquipmentViewModel = MakeEquipViewModel;
            _gymStore = GymStore;

            _makeEquipmentViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeEquipmentViewModel.Name) && !string.IsNullOrEmpty(_makeEquipmentViewModel.Quantity) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Equipment equip = new Equipment(
                _makeEquipmentViewModel.Name,
                _makeEquipmentViewModel.Quantity.ToString(),
                _makeEquipmentViewModel.PurchaseDate,
                _makeEquipmentViewModel.WarrantyExpireDate
                );

            try
            {
                await _gymStore.MakeEquipment(equip);
                MessageBox.Show("Successfuly reserved.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (EquipmentConflictException)
            {
                MessageBox.Show("Already existing in gym store.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to make reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeEquipmentViewModel.Name) ||
                e.PropertyName == nameof(MakeEquipmentViewModel.Quantity))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
