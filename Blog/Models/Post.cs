using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public string HistoryId { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}