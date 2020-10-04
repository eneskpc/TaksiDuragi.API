using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public interface ICallerRepository : IAppRepository
    {
        Task<List<T>> GetCallers<T>(int userID) where T : class;
        Task<T> GetCaller<T>(Expression<Func<Caller, bool>> query) where T : class;
    }
}
