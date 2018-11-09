﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WendhelAton.FAQ.Web.Infrastructure.Data.Helpers;
using WendhelAton.FAQ.Web.ViewModels;
using CodeKicker.BBCode;

namespace WendhelAton.FAQ.Web.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly DefaultDbContext _context;

        public ThreadsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("threads")]
        [HttpGet, Route("threads/index")]
        public IActionResult Index()
        {

            return View(new IndexViewModel()
            {
                Threads = this._context.Threads.ToList()
            });
        }

        [HttpGet, Route("threads/{threadId}")]
        public IActionResult Thread(Guid? threadId)
        {
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == threadId);
            if (thread != null)
            {
                return View(new ThreadViewModel()
                {
                    ThreadId = thread.Id,
                    Title = thread.Title,
                    Content = ParseBBCode(thread.Content)
                });
            }
            return StatusCode(404);
        }
        public string ParseBBCode(string bbcode)
        {
            var parser = new BBCodeParser(new[]
                {
                    new BBTag("img", "<img src=\"${content}\" />", "", false, true),
                    new BBTag("b", "<strong>", "</strong>"),
                    new BBTag("color","<font  color=\"${color}\">","</font >", new BBAttribute("color", ""), new BBAttribute("color", "color")),
                    new BBTag("i", "<span style=\"font-style:italic;\">", "</span>"),
                    new BBTag("u", "<span style=\"text-decoration:underline;\">", "</span>"),
                    new BBTag("code", "<pre class=\"prettyprint\">", "</pre>"),
                    new BBTag("quote", "<blockquote>", "</blockquote>"),
                    new BBTag("list", "<ul>", "</ul>"),
                    new BBTag("*", "<li>", "</li>", true, false),
                    new BBTag("url", "<a href=\"${href}\">", "</a>", new BBAttribute("href", ""), new BBAttribute("href", "href")),
                    new BBTag("youtube", "<div class='video'><iframe width='550px' height='309px' src='//www.youtube.com/embed/${content}' allowFullScreen></iframe></div>","", false, true),
                });
            return parser.ToHtml(bbcode);
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