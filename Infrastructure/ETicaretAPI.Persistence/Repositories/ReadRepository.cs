using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIDAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(X => X.ID == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> Method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(Method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> Method, bool tracking = true)
        {
            var query = Table.Where(Method);
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return query;
        }
    }
}
