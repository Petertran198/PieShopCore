using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PieShop.Models;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {

        public readonly IPieRepository _pieRepository;
        //Bringing in an instance of pieRepository because of  dependency injection 
        // we have access to a pieRepository because we specify it in the startup page. 
        public HomeController( IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.PieOfTheWeek = _pieRepository.PiesOfTheWeek;
            return View(homeViewModel);
        }
    }
}
