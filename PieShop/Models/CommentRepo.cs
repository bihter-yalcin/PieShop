using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CommentRepo : IComment
    {

        private readonly ApplicationDbContext _appDbContext;

        public CommentRepo(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public IEnumerable<Comment> AllComments
          { 
            get
            {
                //category alsın diye include
                return _appDbContext.Comments;
            }
}

        public IEnumerable<Pie> AllPies
        {
            get
            {
                //category alsın diye include
                return _appDbContext.Pies;
            }
        }
        public IEnumerable<Comment> Getcommentlistbyid(int pieId)
        {
            IEnumerable<Comment> objList = from comment in AllComments
                                           where comment.PieId == pieId
                                           select comment;
            /*string t = (from a in AllPies
                        where a.PieId == pieId
                        select a.Name).FirstOrDefault();*/
                                           
            return objList;
        }
    }
}
