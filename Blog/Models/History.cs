using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class History
    {
        public string Id {get;set;} //Generate Guid
        public string Title { get; set; }
        public string TitleUrl { get; set; } //Titulo del Quest o del Post (Separate por - para url)
        public List<string> ImagesUrls { get; set; } //Imagen que se puede mostrar como slider o sencillamente no.
        public DateTime CreatedOn { get; set; }
        public String CreatedBy { get; set; }
        public String Location { get; set; } //Maybe
        public List<Post> Posts { get; set; }
    }
}