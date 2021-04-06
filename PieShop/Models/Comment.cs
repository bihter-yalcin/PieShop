using PieShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [DisplayName("Comment")]
        public string comment { get; set; }
       
        [DisplayName("Pie Name")]
        public int PieId { get; set; }

        [NotMapped]
        public List<Pie> PieCollection { get; set; }



    }

}
