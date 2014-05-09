using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Concrete;
using LoopLeader.Models;

namespace LoopLeader.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            ContentRepository repo = new ContentRepository();
            ContentViewModel contentList = new ContentViewModel() { ContentList = repo.Content.ToList<Content>() };
            return View(contentList);
        }

        [HttpPost]
        public ActionResult Index(ContentViewModel content)
        {
            ContentRepository repo = new ContentRepository();
            Content selectedContent = (from c in repo.Content
                                       where content.ContentID == c.ContentID
                                       select c).FirstOrDefault<Content>();
            selectedContent.ContentID = content.ContentID;
            return View("ContentEditForm", selectedContent);
        }


        public ViewResult ContentEditForm(Content formContent)
        {
            return View(formContent);
        }

        [HttpPost]
        public ViewResult ContentInfo(Content formContent)
        {
            if (ModelState.IsValid)
            {
                formContent.NewText = formContent.CurrentText;
                formContent.UpdateSection();
            }
            return View(formContent);
        }


    }
}
