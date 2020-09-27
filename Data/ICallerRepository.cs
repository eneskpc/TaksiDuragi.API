using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public interface ICallerRepository: IAppRepository
    {
        Task<List<Caller>> GetCallers(int userID);
        Task<Caller> GetCaller(Expression<Func<Caller, bool>> query);
    }
}
