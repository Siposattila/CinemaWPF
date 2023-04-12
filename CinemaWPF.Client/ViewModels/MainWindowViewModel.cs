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

        public RestCollection<Reserve> Reserves { get; set; }
        public RestCollection<Seat> Seats { get; set; }

        Seat selectedSeat;
        public string Name { get; set; }
        public Seat SelectedSeat
        {
            get {  return selectedSeat; }
            set { selectedSeat = value; }
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
                Reserves = new RestCollection<Reserve>("http://localhost:5000/", "reserve", "hub");
                Seats = new RestCollection<Seat>("http://localhost:5000/", "seat", "hub");


                ReserveSeat = new RelayCommand(() =>
                {
                    Reserves.Add(new Reserve()
                    {
                        SeatId = this.SelectedSeat.Id,
                        Name = this.Name
                    });

                }, () =>
                {
                    return this.SelectedSeat != null && this.Name.Length > 2;
                }
                );
                DeleteReserve = new RelayCommand(() =>
                {
                    Reserves.Delete(SelectedSeat.Id);
                },
                () =>
                {
                    return SelectedSeat != null && Reserves.FirstOrDefault(x => x.SeatId == SelectedSeat.Id) != null;
                });
            }

        }


    }
    
}
