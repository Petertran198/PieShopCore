using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class PiesController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        //Constructor
        //The pieRpository and CategoryRepository params is added because we registered them earlier in startups,
        //Therefore we do not need to initalize a pieRepository or categoryRepository as it is already done
        public PiesController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            //Create a ViewModel called PieListViewModel which can be use to collect data to transfer to view page 
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = _pieRepository.AllPies;
            pieListViewModel.CurrentCategory = "Pies";
            return View(pieListViewModel);
        }
    }
}
