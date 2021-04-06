using Microsoft.EntityFrameworkCore;
using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository

    {

        private readonly ApplicationDbContext _appDbContext;

        public PieRepository(ApplicationDbContext applicationDbContext )
        {
            _appDbContext = applicationDbContext;
        }
        public IEnumerable<Pie> AllPies 
        { 
            get
            {
                //category alsın diye include
                return _appDbContext.Pies.Include(c => c.Category);
            } 
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                //category alsın diye include
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
