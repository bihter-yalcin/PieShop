using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    //We just add a property for each type of data that we will need in our view
    public class PiesListViewModel
    {

        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }

    }
}
