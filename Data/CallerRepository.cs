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

        public async Task<T> Add<T>(T entity) where T : class
        {
            return await _appRepo.Add(entity);
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

        public async Task<List<T>> GetCallers<T>(int userID, int take = 10, int skip = 0) where T : class
        {
            var callers = await _mapper.ProjectTo<T>(_context.Callers.Include(c => c.Customer).DefaultIfEmpty().Where(c => c.IsDeleted == false && c.UserId == userID)
                .OrderByDescending(c => c.CallDateTime).Skip(skip * take).Take(take)).ToListAsync();

            if (callers == null || callers.Count == 0)
            {
                return null;
            }
            return callers;
        }
    }
}
