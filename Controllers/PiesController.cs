using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
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
            return View(_pieRepository.AllPies);
        }
    }
}
