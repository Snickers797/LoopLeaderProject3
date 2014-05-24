using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Concrete;
using LoopLeader.Models;

namespace LoopLeader.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ContentRepository repo = new ContentRepository();
            Content homeContent = (from hc in repo.Content
                                   where hc.ContentID == "Home"
                                   select hc).FirstOrDefault<Content>();
            return View(homeContent);
        }

        




    }
}
