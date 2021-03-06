﻿using MVCBlogProject.COMMON.Tools;
using MVCBlogProject.MODEL.Entities;
using MVCBlogProject.MVCUI.Filter;
using MVCBlogProject.SERVICE.Option;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlogProject.MVCUI.Areas.Admin.Controllers
{
    [AuthFilter]
    public class ProfileController : Controller
    {
        UserService db = new UserService();
        public ActionResult Index()
        {
            return View(db.GetById(((User)Session["login"]).ID));
        }

        public ActionResult Edit()
        {
            return View(db.GetById(((User)Session["login"]).ID));
        }

        [HttpPost]
        public ActionResult Edit(User model, HttpPostedFileBase ImagePath)
        {
            //todo: kullanıcı adı ve email null geldiği için güncelleme yapılmıyor.
            if (ImagePath == null)
            {
                model.ImagePath = db.GetById(model.ID).ImagePath;
            }
            else
            {
                model.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Users", ImagePath);
            }
            var user = db.GetById(model.ID);
            user.ImagePath = model.ImagePath;
            user.ConfirmPassword = user.Password;
            db.Update(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangePwd(string OldPassword, string Password)
        {
            User user = db.GetById(((User)Session["login"]).ID);

            if (user.Password != OldPassword)
            {
                TempData["ErrPass"] = "Mevcut şifreniz yanlış";
                return RedirectToAction("Edit");
            }

            user.Password = Password;
            user.ConfirmPassword = Password;
            db.Update(user);

            return RedirectToAction("Index");
        }
    }
}