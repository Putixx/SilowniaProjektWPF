using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Gym _gym;

        public MakeReservationCommand(MakeReservationViewModel MakeReservationViewModel, Gym Gym)
        {
            _makeReservationViewModel = MakeReservationViewModel;
            _gym = Gym;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.PassNumber) && !string.IsNullOrEmpty(_makeReservationViewModel.InstructorIndex) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Reservation reservation = new Reservation(
                _makeReservationViewModel.PassNumber,
                _makeReservationViewModel.InstructorIndex,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate
                );

            try
            {
                _gym.MakeReservation(reservation);
                MessageBox.Show("Successfuly reserved.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(ReservationConflictException)
            {
                MessageBox.Show("Already reserved.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
