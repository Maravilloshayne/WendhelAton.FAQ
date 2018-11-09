using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WendhelAton.FAQ.Web.ViewModels
{
    public class ThreadViewModel
    {
        public Guid? ThreadId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}