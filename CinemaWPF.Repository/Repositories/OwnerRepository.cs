using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Models;

namespace CinemaWPF.Repository.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(CarDbContext ctx) : base(ctx)
        {
        }
    }
}
