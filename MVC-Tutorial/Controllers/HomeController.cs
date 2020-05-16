using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MVCTutorial.Models;

namespace MVCTutorial.Controllers
{
    public class HomeController : Controller
    {
        
        // We'll be using the TypeCast called "[Route("your/route")]
        // Route Constraints in #Route can be used here as well.
        // Example: [Route("users/edit/{id:int}")]
        
        // As for Action & Return Types
        /*
         * ActionResult - This is mostly used every time, this is a very powerful cast where you can return anything.
         * ViewResult - Only can return View()
         * ContentResult - Only can return Content(); This means only plain text can be returned on the View.
         * EmptyResult - Returns empty result, mostly empty page unless handled.
         * JsonResult - Returns Json() object
         * RedirectResult - Redirects to a Controller or Page
         * FileStreamResult - Returns a FileStream for CRUD with a File.
         * Example: public ViewResult MethodName() { }
         */
        
        
        // This means https://domain.com/ aka GET /
        // The main landing route for ANY Site. It always starts from '/'
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        // ContentResult Route
        [Route("users")]
        public ContentResult Users()
        {
            return Content("I am users");
        }
        
        // Passing a Model into the View with Data. This is super convenient
        [Route("users/return/one")]
        public ViewResult ReturnUser()
        {
            // Initialize a User Model first with Data as below
            var user = new User() {Id = 1, username = "InspectorGadget"};
            
            // Now, just pass this bad boy into the View
            return View(user);
        }
        
        // Passing a Model <List> into the View with Data. This is super convenient
        [Route("users/return/many")]
        public ViewResult ReturnUsers()
        {
            // Multiple Objects <List>
            var users = new UsersViewModel
            {
                Users = new List<User>
                {
                    new User
                    {
                        Id = 1,
                        username = "InspectorGadget"
                    },
                    new User
                    {
                        Id = 2,
                        username = "RTG"
                    }
                }
            };

            return View(users);
        }
        
        // Route with Parameters
        // Type Casting means it only will accept int
        [Route("users/edit/{id:int}")]
        public ContentResult Edit(int id)
        {
            return Content($"User ID: {id}");
        }

        // Passing Parameters to View using ViewBag
        [Route("page/{name?}")]
        public ViewResult Page(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Hello World";
            }
            
            ViewBag.Title = name;
            return View();
        }
    }
}
