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
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact1()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Contact1(EmailResponse emailResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("Thankyou", emailResponse);//Thank you, we will respond asap.
            }
            else
            {
                // there is a validation error
                return View();
            }
        }


    }
}
