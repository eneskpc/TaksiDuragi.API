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

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

