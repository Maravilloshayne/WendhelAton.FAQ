﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using WendhelAton.FAQ.Web.Areas.Manage.ViewModels.Threads;
using WendhelAton.FAQ.Web.Infrastructure.Data.Helpers;
using WendhelAton.FAQ.Web.Infrastructure.Data.Models;


namespace WendhelAton.FAQ.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ThreadsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;


        public ThreadsController(DefaultDbContext context)
        {
            _context = context;
        }



        [HttpGet, Route("manage/threads/index")]
        [HttpGet, Route("manage/threads")]
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

        [HttpGet, Route("/manage/threads/update-thumbnail/{threadId}")]
        public IActionResult Thumbnail(Guid? threadId)
        {
            return View(new ThumbnailViewModel() { ThreadId = threadId });
        }
        [HttpPost, Route("/manage/threads/update-thumbnail")]
        public async Task<IActionResult> Thumbnail(ThumbnailViewModel model)
        {
            //Check file size of the uploaded thumbnail
            //reject if the file is greater than 2mb
            var fileSize = model.Thumbnail.Length;
            if ((fileSize / 1048576.0) > 2)
            {
                ModelState.AddModelError("", "The file you uploaded is too large. Filesize limit is 2mb.");
                return View(model);
            }
            //Check file type of the uploaded thumbnail
            //reject if the file is not a jpeg or png
            if (model.Thumbnail.ContentType != "image/jpeg" && model.Thumbnail.ContentType != "image/png")
            {
                ModelState.AddModelError("", "Please upload a jpeg or png file for the thumbnail.");
                return View(model);
            }
            //Formulate the directory where the file will be saved
            //create the directory if it does not exist
            var dirPath = _env.WebRootPath + "/threads/" + model.ThreadId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            //always name the file thumbnail.png
            var filePath = dirPath + "/thumbnail.png";
            if (model.Thumbnail.Length > 0)
            {
                //Open a file stream to read all the file data into a byte array
                byte[] bytes = await FileBytes(model.Thumbnail.OpenReadStream());
                //load the file into the third party (ImageSharp) Nuget Plugin                
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    //use the Mutate method to resize the image 150px wide by 150px long
                    image.Mutate(x => x.Resize(150, 150));
                    //save the image into the path formulated earlier
                    image.Save(filePath);
                }
            }
            return RedirectToAction("Thumbnail", new { ThreadId = model.ThreadId });
        }
        //this method is used to load the file stream into 
        //a byte array
        public async Task<byte[]> FileBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        [HttpGet, Route("/manage/threads/update-banner/{threadId}")]
        public IActionResult Banner(Guid? threadId)
        {
            return View(new BannerViewModel() { ThreadId = threadId });
        }
        [HttpPost, Route("/manage/threads/update-banner")]
        public async Task<IActionResult> Banner(BannerViewModel model)
        {
            var fileSize = model.Thumbnail.Length;
            if ((fileSize / 1048576.0) > 5)
            {
                ModelState.AddModelError("", "The file you uploaded is too large. Filesize limit is 5mb.");
                return View(model);
            }
            if (model.Thumbnail.ContentType != "image/jpeg" && model.Thumbnail.ContentType != "image/png")
            {
                ModelState.AddModelError("", "Please upload a jpeg or png file for the banner.");
                return View(model);
            }
            var dirPath = _env.WebRootPath + "/threads/" + model.ThreadId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var filePath = dirPath + "/banner.png";
            if (model.Thumbnail.Length > 0)
            {
                byte[] bytes = await FileBytes(model.Thumbnail.OpenReadStream());
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    image.Mutate(x => x.Resize(750, 300));
                    image.Save(filePath);
                }
            }
            return RedirectToAction("Thumbnail", new { ThreadId = model.ThreadId });
        }


        [HttpGet, Route("/manage/threads/update-content/{threadId}")]
        public IActionResult UpdateContent(Guid? threadId)
        {
            var thread = this._context.Threads.FirstOrDefault(t => t.Id == threadId);
            if (thread != null)
            {
                return View(new UpdateContentViewModel()
                {
                     ThreadId = thread.Id,
                    Title = thread.Title,
                    Content = thread.Content
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/threads/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var thread = this._context.Threads.FirstOrDefault(t => t.Id == model.ThreadId);
            if (thread != null)
            {
                thread.Content = model.Content;
                thread.Timestamp = DateTime.UtcNow;
                this._context.Threads.Update(thread);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/threads/attach-image")]
        public async Task<string> AttachImage(AttachImageViewModel model)
        {
            var fileSize = model.Image.Length;
            if ((fileSize / 1048576.0) > 5)
            {
                return "Error:The file you uploaded is too large. Filesize limit is 5mb.";
            }
            if (model.Image.ContentType != "image/jpeg" && model.Image.ContentType != "image/png")
            {
                return "Error:Please upload a jpeg or png file for the attachment.";
            }
            var dirPath = _env.WebRootPath + "/threads/" + model.ThreadId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var imgUrl = "/content_" + Guid.NewGuid().ToString() + ".png";
            var filePath = dirPath + imgUrl;
            if (model.Image.Length > 0)
            {
                byte[] bytes = await FileBytes(model.Image.OpenReadStream());
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    //if image wider than 800 px scale to its aspect ratio
                    if (image.Width > 800)
                    {
                        var ratio = 800 / image.Width;
                        image.Mutate(x => x.Resize(800, Convert.ToInt32(image.Height * ratio)));
                    }
                    image.Save(filePath);
                }
            }
            return "OK:/threads/" + model.ThreadId.ToString() + "/" + imgUrl;
        }

        [HttpGet, Route("manage/threads/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/threads/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Thread thread = new Thread()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                UpdatedAt = model.UpdatedAt,
                IsPublished = true,
                TemplateName = "thread1"




            };
            this._context.Threads.Add(thread);
            this._context.SaveChanges();
            return View();
        }

        [HttpPost, Route("manage/threads/unpublish")]
        public IActionResult Unpublish(ThreadIdViewModels model)
        {
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == model.Id);
            if (thread != null)
            {
                thread.IsPublished = false;
                this._context.Threads.Update(thread);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/threads/publish")]
        public IActionResult publish(ThreadIdViewModels model)
        {
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == model.Id);

            if (thread != null)
            {
                thread.IsPublished = true;
                this._context.Threads.Update(thread);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpGet, Route("/manage/threads/update-title/{threadId}")]
        public IActionResult UpdateTitle(Guid? threadId)
        {
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == threadId);
            if (thread != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = thread.Id,
                    Description = thread.Description,
                    Title = thread.Title,
                    UpdatedAt = thread.UpdatedAt,
                    TemplateName = thread.TemplateName
                   
                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/threads/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var thread = this._context.Threads.FirstOrDefault(p => p.Id == model.Id);

            if (thread != null)
            {
                thread.Title = model.Title;
                thread.Description = model.Description;
                thread.UpdatedAt = model.UpdatedAt;
                thread.TemplateName = model.TemplateName;

                this._context.Threads.Update(thread);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}