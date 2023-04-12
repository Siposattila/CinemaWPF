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

                
            //    CreateActorCommand = new RelayCommand(() =>
            //    {
            //        Actors.Add(new Actor()
            //        {
            //            ActorName = SelectedActor.ActorName
            //        });
            //    });

            //    UpdateActorCommand = new RelayCommand(() =>
            //    {
            //        try
            //        {
            //            Actors.Update(SelectedActor);
            //        }
            //        catch (ArgumentException ex)
            //        {
            //            ErrorMessage = ex.Message;
            //        }

            //    });

            //    DeleteActorCommand = new RelayCommand(() =>
            //    {
            //        Actors.Delete(SelectedActor.ActorId);
            //    },
            //    () =>
            //    {
            //        return SelectedActor != null;
            //    });
            //    SelectedActor = new Actor();
            }

        }


    }
    
}
