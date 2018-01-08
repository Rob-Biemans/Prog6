using System;
using System.ComponentModel;
using Tamagotchi.Domein;
using Tamagotchi.Domein.Models;
using Tamagotchi.Domein.Repository;

namespace Tamagotchi.Models
{
    public class BookingViewModel
    {
        [DisplayName("Start")]
        public System.DateTime Start {
            get { return _booking.Start; }
            set { _booking.Start = value; }
        }
        [DisplayName("End")]
        public Nullable<System.DateTime> End {
            get { return _booking.End; }
            set { _booking.End = value; }
        }

        public int TamagotchiId {
            get { return _booking.TamagotchiId; }
            set { _booking.TamagotchiId = value; }
        }
        public int HotelroomId {
            get { return _booking.HotelroomId; }
            set { _booking.HotelroomId = value; }
        }

        private IBookingRepository _bookingRepo;
        private Booking _booking;

        public BookingViewModel(Booking b)
        {
            Start = b.Start;
            End = b.End;
            TamagotchiId = b.TamagotchiId;
            HotelroomId = b.HotelroomId;
        }

        private void Add()
        {
            if (IsNotEmpty() == true)
            {
                _bookingRepo.Add(_booking);
                RepositoryLocator.Repositories.Save();
            }
            else
            {
                //MessageBox.Show("Vul alle velden in aub.", "Toevoegen mislukt", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Read()
        {

        }

        private void Update()
        {
            if (_bookingRepo.GetAll().Exists(b => b.Id == _booking.Id))
            {
                _bookingRepo.GetAll().Find(b => b.Id == _booking.Id);
                _bookingRepo.GetAll().Find(b => b.Id == _booking.Id).Start = Start;
                _bookingRepo.GetAll().Find(b => b.Id == _booking.Id).End = End;
                _bookingRepo.GetAll().Find(b => b.Id == _booking.Id).TamagotchiId = TamagotchiId;
                _bookingRepo.GetAll().Find(b => b.Id == _booking.Id).HotelroomId = HotelroomId;
                RepositoryLocator.Repositories.Save();
            }
        }

        private void Delete()
        {
            Booking booking = _bookingRepo.GetAll().Find(b => b.Id == _booking.Id);
            _bookingRepo.Remove(booking);
            RepositoryLocator.Repositories.Save();
        }

        private bool IsNotEmpty()
        {
            if (this.Start != null && this.End != null
                && HotelroomId <= 0 && TamagotchiId <= 0)
            {
                return true;
            }

            return false;
        }

    }
}