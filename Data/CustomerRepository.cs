using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private TaksiVarmiContext _context;
        private IAppRepository _appRepo;

        public CustomerRepository(TaksiVarmiContext context, IAppRepository appRepo)
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

        public async Task<Customer> GetCustomer(Expression<Func<Customer, bool>> query)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(query);

            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public async Task<List<Customer>> GetCustomers(int userID)
        {
            var customers = await _context.Customers.Where(c => c.IsDeleted == false && c.UserId == userID).ToListAsync();

            if (customers == null || customers.Count == 0)
            {
                return null;
            }
            return customers;
        }

        public async Task<bool> SaveAll()
        {
            return await _appRepo.SaveAll();
        }
    }
}
