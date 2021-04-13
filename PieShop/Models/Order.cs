using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List <OrderDetail> OrderDetails { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public  decimal  total { get; set; }



    }
}
