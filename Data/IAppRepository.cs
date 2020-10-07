using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaksiDuragi.API.Data
{
    public interface IAppRepository
    {
        Task<T> Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
