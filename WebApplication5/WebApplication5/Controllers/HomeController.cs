using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.DAL;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext _dbContext;
        public HomeController(AppDbContext appDbContext)
        {
         _dbContext = appDbContext;
            
        }

        public IActionResult Index()
        {
            return View(_dbContext.Speakers.ToList());
        }

    }
}
