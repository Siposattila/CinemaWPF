using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CinemaWPF.Client.RestCollection;
using CinemaWPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace CinemaWPF.Client.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {

        public RestCollection<Reserve> Seats { get; set; }

        Reserve selectedSeat;
        string name;
        public string Name 
        {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged();
                (ReserveSeat as RelayCommand).NotifyCanExecuteChanged();
                }
        }
        public Reserve SelectedSeat
        {
            get {  return selectedSeat; }
            set { 
                selectedSeat = value;
                OnPropertyChanged();
                (ReserveSeat as RelayCommand).NotifyCanExecuteChanged();
                (DeleteReserve as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand ReserveSeat;
        public ICommand DeleteReserve;
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Seats = new RestCollection<Reserve>("http://localhost:5000/", "api/reserve", "hub");
                


                ReserveSeat = new RelayCommand(() =>
                {
                    SelectedSeat.Name = this.Name;
                    Seats.Update(selectedSeat);
                }, () =>
                {
                    return this.SelectedSeat != null && this.Name.Length > 2;
                }
                );

                DeleteReserve = new RelayCommand(() =>
                {
                    SelectedSeat.Name = "";
                    Seats.Update(SelectedSeat);
                },
                () =>
                {
                    return SelectedSeat != null && SelectedSeat.Name != "";
                });
            }

        }


    }
    
}
