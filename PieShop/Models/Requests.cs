using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Requests
    {

        public int Id { get; set; }
        
        public string NameofPie { get; set; }
      
        public string Description { get; set; }
       
        public string Contact { get; set; }
    }
}
