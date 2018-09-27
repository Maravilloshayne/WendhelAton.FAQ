using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WendhelAton.FAQ.Web.Infrastructure.Data.Helpers;
using WendhelAton.FAQ.Web.ViewModels;

namespace WendhelAton.FAQ.Web.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly DefaultDbContext _context;

        public ThreadsController(DefaultDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            return View(new IndexViewModel()
            {
                Threads = this._context.Threads.ToList()
            });
        }


        public IActionResult Post(Guid? postId)
        {
            return View();
        }

        public IActionResult Carousel()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
    }
}