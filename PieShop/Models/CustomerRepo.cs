using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CustomerRepo
    {
        private readonly ApplicationDbContext _appDbContext;

        public CustomerRepo(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public Customer GetByUsernameAndPassword(string username,string password)
        {
            var user = _appDbContext.Customers.SingleOrDefault(a => a.UserName == username && a.Password == password);
            return user;
        }

    }
}
