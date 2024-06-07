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
            if (ModelState.IsValid)
            {
                try
                {
                    using (DbModels dbModel = new DbModels())
                    {
                        // Check if UserModel already exists (for edit scenario)
                        var existingUser = dbModel.Users.Find(userModel.UserID);
                        if (existingUser != null)
                        {
                            // Update existing user
                            dbModel.Entry(existingUser).CurrentValues.SetValues(userModel);
                        }
                        else
                        {
                            // Add new user
                            dbModel.Users.Add(userModel);
                        }

                        dbModel.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Form Submitted Successfully";
                    return RedirectToAction("AddOrEdit");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error occurred while saving the user: " + ex.Message;
                    return View("AddOrEdit", userModel);
                }
            }
            else
            {
                // Model is not valid, return to the form with validation errors
                return View("AddOrEdit", userModel);
            }
        }

    }
}