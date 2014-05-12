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

        const string MEMBER = "Member";

        public ViewResult DisplayMember()
        {
            Member member = memberRepo.GetMembers.FirstOrDefault();
            return View(member);
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddMember(Member member)
        {
            if (ModelState.IsValid)
            {
                memberRepo.AddMember(member);
                return View("DisplayMember", member);
            }
            return View("AddMember", member);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Login(Member member)
        {

            return View("Login", member);
        }
    }
}
