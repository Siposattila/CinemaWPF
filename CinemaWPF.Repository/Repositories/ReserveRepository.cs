using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Models;

namespace CinemaWPF.Repository.Repositories
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(CinemaDbContext ctx) : base(ctx)
        {
        }
    }
}
