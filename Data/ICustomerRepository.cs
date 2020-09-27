using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public interface ICustomerRepository : IAppRepository
    {
        Task<List<Customer>> GetCustomers(int userID);
        Task<Customer> GetCustomer(Expression<Func<Customer, bool>> query);
    }
}
