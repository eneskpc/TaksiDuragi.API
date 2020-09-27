using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public class CallerRepository : ICallerRepository
    {
        private TaksiVarmiContext _context;
        private IAppRepository _appRepo;
        public CallerRepository(TaksiVarmiContext context, IAppRepository appRepo)
        {
            _context = context;
            _appRepo = appRepo;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await _appRepo.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appRepo.Delete(entity);
        }

        public async Task<Caller> GetCaller(Expression<Func<Caller, bool>> query)
        {
            var caller = await _context.Callers.FirstOrDefaultAsync(query);

            if (caller == null)
            {
                return null;
            }
            return caller;
        }

        public async Task<List<Caller>> GetCallers(int userID)
        {
            var callers = await _context.Callers.Where(c=> c.IsDeleted == false && c.UserId == userID).ToListAsync();

            if (callers == null || callers.Count == 0)
            {
                return null;
            }
            return callers;
        }

        public async Task<bool> SaveAll()
        {
            return await _appRepo.SaveAll();
        }
    }
}
