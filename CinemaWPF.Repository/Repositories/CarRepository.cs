using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Models;

namespace CinemaWPF.Repository.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarDbContext ctx) : base(ctx)
        {
        }
    }
}
