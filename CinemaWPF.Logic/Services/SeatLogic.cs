using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Logic.Interfaces;
using CinemaWPF.Models;
using System;
using System.Collections.Generic;

namespace CinemaWPF.Logic.Services
{
    public class SeatLogic : IReverseLogic
    {
        ISeatRepository brandRepo;
        public SeatLogic(ISeatRepository brandRepo)
        {
            this.brandRepo = brandRepo;
        }

        public void Create(Seat brand)
        {
            brandRepo.Create(brand);
        }

        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }

        public Seat Read(int id)
        {
            Seat brand = brandRepo.Read(id);
            if (brand == null)
                throw new ArgumentException("Brand with the specified id does not exists.");
            return brand;

            //return brandRepo.Read(id) ?? throw new ArgumentException("Brand with the specified id does not exists.");
        }

        public IEnumerable<Seat> ReadAll()
        {
            return brandRepo.ReadAll();
        }

        public void Update(Seat brand)
        {
            brandRepo.Update(brand);
        }
    }
}
