using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.Exceptions.ReservationExceptions;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly GymStore _gymStore;

        public MakeReservationCommand(MakeReservationViewModel MakeReservationViewModel, GymStore GymStore)
        {
            _makeReservationViewModel = MakeReservationViewModel;
            _gymStore = GymStore;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.PassNumber) && !string.IsNullOrEmpty(_makeReservationViewModel.InstructorIndex) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new Reservation(
                _makeReservationViewModel.PassNumber,
                _makeReservationViewModel.InstructorIndex,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate
                );

            try
            {
                await _gymStore.MakeReservation(reservation);
                MessageBox.Show("Successfuly reserved.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(ReservationConflictException)
            {
                MessageBox.Show("Already reserved.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ReservationWorkerNotExistingException)
            {
                MessageBox.Show("There is no such instructor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ReservationClientNotExistingException)
            {
                MessageBox.Show("There is no such client.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to make reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservationViewModel.PassNumber) ||
                e.PropertyName == nameof(MakeReservationViewModel.InstructorIndex))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
