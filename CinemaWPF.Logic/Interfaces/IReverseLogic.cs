using CinemaWPF.Models;
using System.Collections.Generic;

namespace CinemaWPF.Logic.Interfaces
{
    public interface IReverseLogic
    {
        void Create(Seat brand);
        void Delete(int id);
        IEnumerable<Seat> ReadAll();
        Seat Read(int id);
        void Update(Seat brand);
    }
}
