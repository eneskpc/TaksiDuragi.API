using AutoMapper;
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
        private readonly TaksiVarmiContext _context;
        private readonly IAppRepository _appRepo;
        private readonly IMapper _mapper;

        public CallerRepository(TaksiVarmiContext context, IAppRepository appRepo, IMapper mapper)
        {
            _context = context;
            _appRepo = appRepo;
            _mapper = mapper;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await _appRepo.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appRepo.Delete(entity);
        }

        public async Task<T> GetCaller<T>(Expression<Func<Caller, bool>> query) where T : class
        {
            var caller = await _mapper.ProjectTo<T>(_context.Callers.Where(query)).FirstOrDefaultAsync();

            if (caller == null)
            {
                return null;
            }
            return caller;
        }

        public async Task<List<T>> GetCallers<T>(int userID) where T : class
        {
            var callers = await _mapper.ProjectTo<T>(_context.Callers.Where(c => c.IsDeleted == false && c.UserId == userID)).ToListAsync();

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
