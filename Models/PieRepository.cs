using Microsoft.EntityFrameworkCore;
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        //We have access to this due to dependency injection. In startup.cs configureservice method we have access to AppDbContext 
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                //Return all the pies and include it with it the category
                // _appDbContext.Pies is talking about the PieRepository dbset
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {

            get
            {
                //Return all the pies that returns true for IsPieOfTheWeek and include it with it the category 
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            //Return the first pie with that id;
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
