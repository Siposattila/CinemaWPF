using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Logic.Interfaces;
using CinemaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaWPF.Logic.Services
{
    public class ReserveLogic : IReserveLogic
    {
        IRepository<Reserve> repo;

        public void Create(Reserve reserve)
        {
            this.repo.Create(reserve);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Reserve Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<Reserve> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Reserve reserve)
        {
            this.repo.Update(reserve);
        }
    }
}
