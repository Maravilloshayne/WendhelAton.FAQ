using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WendhelAton.FAQ.Web.Infrastructure.Data.Helpers;
using WendhelAton.FAQ.Web.Infrastructure.Data.Models;
using WendhelAton.FAQ.Web.Models;
using System.IO;

namespace WendhelAton.FAQ.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly DefaultDbContext _context;

        public HomeController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("")]
        [HttpGet, Route("home")]
        [HttpGet, Route("home/index")]


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        [HttpGet, Route("home/initialize")]
        public IActionResult Init()
        {
            var thread = this._context.Threads.FirstOrDefault();

            if (thread == null)
            {
                Thread thread1 = new Thread()
                {
                    Id = Guid.Parse("3a88bea9-8a65-4c23-941a-972a6195b940"),
                    Title = "Pogi Problems",
                    Content = "Nagmukhang All Girl School yung pinasukan ko, Sa dami ng babaeng nag-enroll makita lang ako." +
                    "Kahit katiting lang na kapogian masaya na ko, Pero bakit ganun? Sobra sobrang kapogian ang naibigay sa akin." +
                    "Ayaw ko na sanang pumasok bukas.Tinatamad ako.Kaya lang naawa na ako sa mga estudyanteng nagpipilit pumasok masilayan lang ako. #PogiProblems",

                    UpdatedAt = DateTime.UtcNow,
                    IsPublished = true


                };
                this._context.Threads.Add(thread1);


                Thread thread2 = new Thread()
                {

                    Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                    Title = "God Inspirational Words",
                    Content = "The very first step toward change is to believe that you can. You don't have to stay the way you are because God is a God of change and transformation. He can bring change to your life and bring the best out of you.",

                    UpdatedAt = DateTime.UtcNow,
                    IsPublished = true
                };
                this._context.Threads.Add(thread2);

                Thread thread3 = new Thread()
                {
                    Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                    Title = "Love Quoutes",
                    Content = "I am happiest when Im right next to you." +
                    "Absolutely true for any person who is in real love with their partner. In this era of leechers, it is tough to find such people. If you happen to find one, treat him/her as a rare gem. You deserved it. ",

                    UpdatedAt = DateTime.UtcNow,
                    IsPublished = true
                };
                this._context.Threads.Add(thread3);

                this._context.SaveChanges();
            }


            var user = this._context.Users.FirstOrDefault();
            if (user == null)
            {
                var admin = new User()
                {
                    Id = Guid.Parse("b2e5a4fc-ca4e-4d3f-b9ac-d8a088cd6401"),
                    EmailAddress = "Wendhelgregorio@gmail.com",
                    FirstName = "Wendhel",
                    LastName = "Gregorio",
                    Gender = Infrastructure.Data.Enums.gender.Male,
                    LoginStatus = Infrastructure.Data.Enums.LoginStatus.Active,
                    LoginTrials = 0,
                    RegistrationCode = RandomString(6),
                    Password = BCrypt.BCryptHelper.HashPassword("Accord605", BCrypt.BCryptHelper.GenerateSalt(8))
                };
                this._context.Users.Add(admin);
                this._context.SaveChanges();
                this._context.UserRoles.Add(new UserRole()
                {
                    Id = Guid.Parse("b2e5a4fc-ca4e-4d3f-b9ac-d8a088cd6401"),
                    Role = Infrastructure.Data.Enums.Role.Admins,
                    UserId = admin.Id
                });
                this._context.SaveChanges();
            }
            return RedirectToAction("index");
            //return RedirectPermanent("~/posts/index");
        }
        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
