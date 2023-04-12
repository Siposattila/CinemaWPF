using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Models;

namespace CinemaWPF.Repository.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(CarDbContext ctx) : base(ctx)
        {
        }
    }
}
