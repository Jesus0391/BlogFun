using Blog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private List<History> _histories;
        public HomeController()
        {
                        
        }
        //Show all Histories like Short Cards
        public ActionResult Index()
        {
            LoadHistories();
            return View(_histories);
        }

        public ActionResult Details(string id)
        {
            LoadHistories();
            var history = _histories.Where(h => h.Id == id).FirstOrDefault();
            
            return View(history);
        }
        public ActionResult PostsList(string id)
        {
            LoadHistories();
            var posts = _histories.Where(h => h.Id == id).FirstOrDefault().Posts;
            return PartialView(posts);
        }
        public ActionResult List()
        {
            LoadHistories();
            return PartialView(_histories);
        }

        //Show Forms for History and Posts
        private void LoadHistories()
        {
            try
            {
                _histories = JsonConvert.DeserializeObject<List<History>>(
                    (System.IO.File.ReadAllText(Server.MapPath("/json/db.json"))));
                if (_histories == null)
                {
                    _histories = new List<History>();
                }
            }
            catch (Exception ex)
            {
                _histories = new List<History>();
            }
        }
        private void SaveHistories()
        {
            System.IO.File.WriteAllText(Server.MapPath("/json/db.json"),
                JsonConvert.SerializeObject(_histories, Formatting.Indented));

        }
        //Create History
        [HttpPost]
        public JsonResult Create(History history)
        {
            history.CreatedBy = "Jesús";
            history.CreatedOn = DateTime.Now;
            history.Id = Guid.NewGuid().ToString();
            if (history.ImagesUrls == null)
            {
                history.ImagesUrls = new List<string>()
                {

                    "http://lorempixel.com/400/200/city"
                };
            }
            LoadHistories();
            _histories.Add(history);
            SaveHistories();
            return Json(new { message = "Historia creada", success = true }, 
                JsonRequestBehavior.AllowGet);
        }
        //Save Post
        [HttpPost]
        public JsonResult CreatePost(Post post)
        {
            post.Created = DateTime.Now;
            LoadHistories();
            var history = _histories.Where(h => h.Id == post.HistoryId).FirstOrDefault();
            if (history.Posts == null)
            {
                history.Posts = new List<Post>();
            }
            history.Posts.Add(post);
            //_histories.Where(h => h.Id == post.HistoryId).FirstOrDefault().;
            SaveHistories();

            return Json(new { message = "Post creado", success = true },
                JsonRequestBehavior.AllowGet);
        }
        //Show all Posts like a micro-bloggings
        public JsonResult GetPosts()
        {
            LoadHistories();
            return Json(_histories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}