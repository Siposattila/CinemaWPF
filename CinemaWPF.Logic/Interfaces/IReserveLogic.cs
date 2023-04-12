using CinemaWPF.Models;
using System.Collections.Generic;

namespace CinemaWPF.Logic.Interfaces
{
    public interface IReserveLogic
    {
        void Create(Reserve reserve);
        void Delete(int id);
        IEnumerable<Reserve> ReadAll();
        Reserve Read(int id);
        void Update(Reserve reserve);
    }
}
