using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }
        public int Description { get; set; }
        public List<Pie> Pie { get; set; }

    }
}
