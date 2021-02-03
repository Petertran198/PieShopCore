using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    //This is to create a view model for pies which we can use in the list method 
    //ViewModel is good to collect multiple data to pass from controller to view 
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }

        public string CurrentCategory { get; set; }
    }
}
