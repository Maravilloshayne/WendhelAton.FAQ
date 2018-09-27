using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WendhelAton.FAQ.Web.Areas.Manage.ViewModels.Threads;
using WendhelAton.FAQ.Web.Infrastructure.Data.Helpers;
using WendhelAton.FAQ.Web.Infrastructure.Data.Models;

namespace WendhelAton.FAQ.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ThreadsController : Controller
    {
        private readonly DefaultDbContext _context;
        public ThreadsController(DefaultDbContext context)
        {
            _context = context;
        }



        [HttpGet, Route("manage/faqs/index")]
        [HttpGet, Route("manage/faqs")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {

            Page<Thread> result = new Page<Thread>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Thread> threadQuery = (IQueryable<Thread>)this._context.Threads;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                threadQuery = threadQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = threadQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Thread> users = threadQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Threads = result
            });
        }


        [HttpGet, Route("manage/faqs/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/faqs/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Thread thread = new Thread()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content,
                UpdatedAt = model.UpdatedAt,
                IsPublished = true




            };
            this._context.Threads.Add(thread);
            this._context.SaveChanges();
            return View();
        }

        [HttpPost, Route("manage/faqs/unpublish")]
        public IActionResult Unpublish(ThreadIdViewModels model)
        {
            var post = this._context.Threads.FirstOrDefault(p => p.Id == model.Id);
            if (post != null)
            {
                post.IsPublished = false;
                this._context.Threads.Update(post);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpGet, Route("/manage/faqs/update-title/{threadId}")]
        public IActionResult UpdateTitle(Guid? threadId)
        {
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == threadId);
            if (thread != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = thread.Id,
                    Content = thread.Content,
                    Title = thread.Title,
                    UpdatedAt = thread.UpdatedAt,
                   
                };
                return View(model);
            }
            return RedirectToAction("Create");
        }
        [HttpPost, Route("/manage/faqs/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == model.Id);
            if (thread != null)
            {
                thread.Title = model.Title;
                thread.Content = model.Content;
                thread.UpdatedAt = model.UpdatedAt;
                this._context.Threads.Update(thread);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}