﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }
        //CONTENT ADMIN PAGES

        public ActionResult ContentIndex()
        {
            //Get a list of content to populate a drop down list.
            LLDbContext context = new LLDbContext();
            ContentRepository repo = new ContentRepository();
            ContentViewModel contentList = new ContentViewModel() { ContentList = repo.Content.ToList<Content>() };
            return View(contentList);
        }

        [HttpPost]
        public ActionResult ContentIndex(ContentViewModel content)
        {
            //After user selects an item from the drop down list, grab its info from the database.
            ContentRepository repo = new ContentRepository();
            Content selectedContent = (from c in repo.Content
                                       where content.ContentID == c.ContentID
                                       select c).FirstOrDefault<Content>();
            selectedContent.ContentID = content.ContentID;
            //Then pass it to the form to be edited.
            return View("ContentEditForm", selectedContent);
        }

        public ViewResult ContentEditForm(Content formContent)
        {
            return View(formContent);
        }

        [HttpPost]
        public ViewResult ContentInfo(Content formContent)
        {
            ContentRepository repo = new ContentRepository();
            //After we get the information back from the form...
            if (ModelState.IsValid)
            {
                //formContent.NewText = formContent.CurrentText;
                //...update the database with it.
                formContent.UpdateSection();
            }
            //And then in this case, display a page showing the new changes.  This
            //returns the object from the database that was passed in as a parameter.
            return View((from c in repo.Content
                         where c.ContentID == formContent.ContentID
                         select c).FirstOrDefault<Content>());
        }

        //END CONTENT PAGES

        //START MEMBER PAGES

        public ActionResult MemberIndex()
        {
            //Get a list of content to populate a drop down list.
            MemberRepository repo = new MemberRepository();
            MemberViewModel memberList = new MemberViewModel() { MemberList = repo.GetMembers.ToList<Member>() };
            return View(memberList);
        }

        [HttpPost]
        public ActionResult MemberIndex(MemberViewModel member)
        {
            //After user selects an item from the drop down list, grab its info from the database.
            MemberRepository repo = new MemberRepository();
            Member selectedMember = (from m in repo.GetMembers
                                     where member.MemberID == m.MemberId
                                     select m).FirstOrDefault<Member>();
            selectedMember.MemberId = member.MemberID;
            //Then pass it to the form to be edited.
            return View("MemberEditForm", selectedMember);
        }

        public ViewResult MemberEditForm(Member formMember)
        {
            return View(formMember);
        }

        [HttpPost]
        public ViewResult MemberInfo(Member formMember)
        {
            MemberRepository repo = new MemberRepository();
            LLDbContext memberDB = new LLDbContext();
            //After we get the information back from the form...
            if (ModelState.IsValid)
            {
                //...update the database with it.

                Member memberToUpdate = memberDB.Members.Find(formMember.MemberId);
                if (memberToUpdate != null)
                {
                    memberToUpdate.LoginName = formMember.LoginName;
                    memberToUpdate.FirstName = formMember.FirstName;
                    memberToUpdate.LastName = formMember.LastName;
                    memberToUpdate.Password = formMember.Password;
                    memberToUpdate.Email = formMember.Email;
                    memberToUpdate.StreetAddress1 = formMember.StreetAddress1;
                    memberToUpdate.StreetAddress2 = formMember.StreetAddress2;
                    memberToUpdate.City = formMember.City;
                    memberToUpdate.State = formMember.State;
                    memberToUpdate.Zip = formMember.Zip;
                    memberToUpdate.IsAdmin = formMember.IsAdmin;
                    
                }
                memberDB.SaveChanges();
            }
            //And then in this case, display a page showing the new changes.  This
            //returns the object from the database that was passed in as a parameter.
            return View((from m in repo.GetMembers
                         where m.MemberId == formMember.MemberId
                         select m).FirstOrDefault<Member>());
        }

        public ViewResult MemberDelete(Member memberToBeDeleted)
        {
            return View(memberToBeDeleted);
        }

        public ActionResult MemberDeleteConfirmed(Member memberToBeDeleted)
        {
            MemberRepository repo = new MemberRepository();
            //First check that the
            repo.DeleteMember(memberToBeDeleted.MemberId);
            return View(memberToBeDeleted);
        }

        //END MEMBER PAGES

        //START PRODUCT PAGES

        public ActionResult ProductIndex()
        {
            //Get a list of content to populate a drop down list.
            ProductRepository repo = new ProductRepository();
            ProductViewModel productList = new ProductViewModel() { ProductList = repo.GetProducts.ToList<Product>() };
            return View(productList);
        }

        [HttpPost]
        public ActionResult ProductIndex(ProductViewModel product)
        {
            //After user selects an item from the drop down list, grab its info from the database.
            ProductRepository repo = new ProductRepository();
            Product selectedProduct = (from p in repo.GetProducts
                                       where product.ProductID == p.ProductID
                                       select p).FirstOrDefault<Product>();
            selectedProduct.ProductID = product.ProductID;
            //Then pass it to the form to be edited.
            return View("ProductEditForm", selectedProduct);
        }

        public ViewResult ProductEditForm(Product formProduct)
        {
            return View(formProduct);
        }

        [HttpPost]
        public ViewResult ProductInfo(Product formProduct)
        {
            ProductRepository repo = new ProductRepository();
            //After we get the information back from the form...
            if (ModelState.IsValid)
            {
                //...update the database with it.
                LLDbContext productDB = new LLDbContext();
                Product productToUpdate = productDB.Products.Find(formProduct.ProductID);
                if (productToUpdate != null)
                {
                    productToUpdate.Description = formProduct.Description;
                    productToUpdate.Category = formProduct.Category;
                    productToUpdate.InStock = formProduct.InStock;
                    productToUpdate.Price = formProduct.Price;
                    productToUpdate.ProductName = formProduct.ProductName;
                    productToUpdate.Shipping = formProduct.Shipping;
                }
                productDB.SaveChanges();
            }
            //And then in this case, display a page showing the new changes.  This
            //returns the object from the database that was passed in as a parameter.
            return View((from p in repo.Products
                         where p.ProductID == formProduct.ProductID
                         select p).FirstOrDefault<Product>());
        }

        //END PRODUCT PAGES

    }
}
