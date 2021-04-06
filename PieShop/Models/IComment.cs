using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public  interface IComment
    {
        IEnumerable<Comment> AllComments { get; }
        IEnumerable<Comment> Getcommentlistbyid (int pieId);
        IEnumerable<Pie> AllPies { get; }

    }
}
