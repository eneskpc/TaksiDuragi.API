using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaksiDuragi.API.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly TaksiVarmiContext _context;

        public AppRepository(TaksiVarmiContext context)
        {
            _context = context;
        }

        public async Task<T> Add<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            if(await _context.SaveChangesAsync() > 0)
            {
                return entity;
            }
            return null;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}

