using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Models;

namespace CinemaWPF.Repository.Repositories
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        public SeatRepository(CinemaDbContext ctx) : base(ctx)
        {
        }
    }
}
