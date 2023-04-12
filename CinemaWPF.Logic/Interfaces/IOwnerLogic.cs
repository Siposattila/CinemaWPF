using CinemaWPF.Models;
using System.Collections.Generic;

namespace CinemaWPF.Logic.Interfaces
{
    public interface IOwnerLogic
    {
        void Create(Owner owner);
        void Delete(int id);
        IEnumerable<Owner> ReadAll();
        Owner Read(int id);
        void Update(Owner owner);
    }
}
