using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CusName { get; set; }
        public string LastName { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Returnurl { get; set; }

        public bool RememberLogin { get;  set; }
    }
}
