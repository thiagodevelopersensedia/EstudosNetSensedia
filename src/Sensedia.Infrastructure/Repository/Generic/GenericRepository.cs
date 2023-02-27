using Microsoft.EntityFrameworkCore;
using Sensedia.Core.Entities;
using Sensedia.Core.Interfaces.Specifications;
using Sensedia.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensedia.Core.Interfaces.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SensediaContext _context;

        public GenericRepository(SensediaContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetListEntityAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }
    }
}
