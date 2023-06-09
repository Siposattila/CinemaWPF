using CinemaWPF.Repository.Interfaces;
using CinemaWPF.Models;
using System;
using System.Linq;

namespace CinemaWPF.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected CinemaDbContext ctx;

        public Repository(CinemaDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public virtual T Read(int id)
        {
           return ctx.Set<T>().FirstOrDefault(item => item.Id.Equals(id));
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public virtual void Update(T item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
