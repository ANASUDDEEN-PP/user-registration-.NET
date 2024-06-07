This is the userController.cs 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationForm.Models;

namespace RegistrationForm.Controllers
{
    public class userController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Form Submited Successfully";
            return View("AddOrEdit",new User());
        }
    }
}
