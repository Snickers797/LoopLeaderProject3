using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Concrete;
using System.Web.Security;

namespace LoopLeader.Controllers
{
    public class AccountController : Controller
    {
        IMember memberRepo;

        public AccountController()
        {
            memberRepo = new MemberRepository();
        }

        public AccountController(IMember repo)
        {
            memberRepo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
