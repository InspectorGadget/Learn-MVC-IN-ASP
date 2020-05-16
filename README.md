# A comprehensive basic (Beginner) tutorial on ASP.NET

-  <b>MVC Flavored</b>. Some methods can been applied for Non-MVC.

Thanks for reading and good luck for whichever platform or Web App you're wanting to use ASP.NET for. 

You may contact me over Email `igadget28@gmail.com`. People who knows me IRL/Personal, can contact me over the Medium that is suitable. 

Alternatively, I can be contacted on Discord with this handle: `𝑰𝑮#1337`.

The source code the Web App is available in this Repo, just check it out. Everything explained in this README File is everything inside the Source Code. 

---
## What is covered?

-  <b>Basics of ASP (.NET)</b>
	- [Folder Structure (What are these folders?)](#folder-structure)

-  <b>Models</b>
	- [Getters & Setters](#models)
	
-  <b>Route</b>
	- [Basic Route Format `RouteConfig` File.](#route)
	- [Basic Routing](#basic-routing)
	- [Basic Routing with Route Constraints](#basic-routing-with-route-constraints)
	- [Advanced Routing](#advanced-routing)

-  <b>Controllers</b>
	- [Basic Controller Format](#controllers)
	- [Actions & Results](#actions--results)
	- [Basic Route Mapping](#basic-route-mapping)
	- [Advanced Route Mapping](#advanced-route-mapping)
	- [Passing Data to view using ViewBag](#passing-data-to-view-using-viewbag)
	- [Passing Data to View from Controller (Modal)](#passing-data-to-view-from-controller-modal)
	- [Passing List/Multiple Data to View from Controller (Modal)](#passing-listmultiple-data-to-view-from-controller-modal)
	
-  <b>Views</b>
	- [Layout / Templating](#layout--templating)
	- [YEETME before extending](#yeetme-before-extending)
	- [Example of extending the Layout Template.](#example-of-extending-the-layout-template)
	- [Example of extending Layout AND ViewBag](#example-of-extending-layout-and-viewbag)
	- [Call a Model and return the Data passed from the Controller.](#call-a-model-and-return-the-data-passed-from-the-controller)

-  <b>Database [ SOON ]</b>
	- Connect to MS SQL/Oracle DB/MySQL Database

  

---

# Basics of ASP?

- ASP is a Web Framework which extends MVC (Modal View Controller) of a web stack or web application. Hence, this means we can extend the usability of Bootstrap/JavaScript/Models/Controllers and more.

### Folder Structure
- App Start
	- This Folder contains the most important config file  known as RouteConfig. 
- Controllers
	- This Folder contains the Controllers which makes this ASP.NET Web App work. Controllers are the brain of your Web App.
- Models
	- This Folder contains the juiciest part of a MVC, which is the Models. The Model allows you seamlessly Add/Remove/Edit/Truncate a Data Structure, let alone Database Eloquent. 
- Scripts
	- This Folder will contain your JavaScript Libraries/Files. Usually, this is empty.
- Views
	- This Folder will contain your HTML or Templating Files in the format of `.cshtml` - CSharpHTML. There will be a default folder called "Shared". This is the folder which contains your Templating File/Layout Master File, as well as your Error File. 

---
# Models
- Getters and Setters slapped together in this Code Snippet. 
```cs
namespace MVCTutorial.Models
{
    public class User
    {
        /*
         * Getter and Setter
         * Usually handled by the Model and Controller for Parameter binding
         * -----
         * get - Allows you to get this parameter anywhere
         * set - Allows the auto-binding to happen when the parameter injected matches the requirement
         * -----
         * However, this Model is usually referred to an Object. An Object is a "package" or "stack" of list (imagine)
         * which contains the data that you need. Let alone if it's extracted from a SQL Database (MS SQL, MS Access, SQL Server, etc)
         * A Model doesn't ONLY Store data, but it also notifies any new changes to the Controller or View. Thus, that's the point of "Notifier".
         *
         * --- DIVING INTO MODEL ---
         * public "int" Id
         *
         * The Type Casting of "int" can be replaced with other Type Castings as well.
         * Example:
         * public string {}
         * public bool {}
         * public char {}
         * public dynamic {}
         * public double {}
         * public enum {}
         * public float {}
         *
         * ----
         * LONG STORY CUT SHORT
         * A Model represents your data structures. Typically your model classes with contain functions that help you create, read, update, delete (CRUD) information in your Database.
         */
        
        public int Id { get; set; }
        public string username { get; set; }
    }
}
```

---
# Route
- Basic Route Format `RouteConfig` File. 
```cs
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTutorial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This means to ignore weird routes which "may" expose the Web App.
            // REGEX is enforced
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
```

### Basic Routing
```cs
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTutorial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This means to ignore weird routes which "may" expose the Web App.
            // REGEX is enforced
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default Fallback Route (Basic Routing)
            // Parameters:
            //     name: - This means the name of the Route, HAS TO BE UNIQUE. "Default" will be used on Error.
            //     url: - The URL that it needs to be mapped and matched, ALL URL will pass this. {id} means a basic 1 param pass, we'll go through this in Controller section.
            //     defaults - The controller for the Route (An explicit object has to be passed.) 
            //              - UrlParameter.Optional means "If the Controller wants this ID, it can take it. Otherwise, it's okay"
            // ----------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            // ----------
        }
    }
}
```

### Basic Routing with Route Constraints
```cs
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTutorial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This means to ignore weird routes which "may" expose the Web App.
            // REGEX is enforced
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default Fallback Route (Basic Routing with Route Constraints)
            // Route constraints mean Type Casting and filtering a URL with specific type of input you want with REGEX.
            // NOTE: If you add ? behind your constraint, it means the valid can be there or not be there. Tentative param.
            // "\\d{2}" means I only want 2 numbers or characters for the ID. "\\d" is just a convention for REGEX.
            // You can view all of them here: https://www.tektutorialshub.com/asp-net-core/asp-net-core-route-constraints/
            // ----------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id:int?}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = "\\d{2}"}
            );
            // ----------
        }
    }
}
```

### Advanced Routing
```cs
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTutorial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Advanced Routing
            // With only this line, it gets the [Route()] typecasting and uses that as the Route. This is the power of a MVC.
            routes.MapMvcAttributeRoutes();
        }
    }
}

```

---
# Controllers
- Basic Controller Format. This is the basic start point of ANY Controller. 
```cs
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
        /* Your Methods */ 
    }
}
```

### Actions & Results
```cs
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

        public ViewResult Index()
        {
            return View();
        }

        // ContentResult Route
        public ContentResult Users()
        {
            return Content("I am users");
        }

    }
}
```

### Basic Route Mapping
- NOTE: Please use this method if you are using the Basic Route or Routing with constraints method as above.
```cs
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
       
        // GET /User/1 or GET /User?id=1
        // Routes in this method are Case Sensitive!
        public ContentResult User(int id)
        {
            return Content($"ID: {id}");
        }

    }
}
```

### Advanced Route Mapping
```cs
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
       
        // This means https://domain.com/ aka GET /
        // The main landing route for ANY Site. It always starts from '/'
        [Route("")] // <---- TAKE NOTE!
        public ViewResult Index()
        {
            return View();
        }

        // ContentResult Route
        // GET /users
        [Route("users")]
        public ContentResult Users()
        {
            return Content("I am users");
        }

        // Route with Parameters
        // Type Casting means it only will accept int
        // GET /users/edit/1
        [Route("users/edit/{id:int}")]
        public ContentResult Edit(int id)
        {
            return Content($"User ID: {id}");
        }

    }
}
```

### Passing Data to view using ViewBag
```cs
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
       
        // Passing Parameters to View using ViewBag
        // '?' means tentative variable. Can be NULL or present.
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
```

### Passing Data to View from Controller (Modal)
```cs
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
       
        // Passing a Model into the View with Data. This is super convenient
        // GET /users/return/one
        [Route("users/return/one")]
        public ViewResult ReturnUser()
        {
            // Initialize a User Model first with Data as below
            var user = new User() {Id = 1, username = "InspectorGadget"};
            
            // Now, just pass this bad boy into the View
            return View(user);
        }

    }
}
```

### Passing List/Multiple Data to View from Controller (Modal)
```cs
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
       
        // Passing a Model <List> into the View with Data. This is super convenient
        // GET /users/return/many
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
                        username = "Juice WRLD"
                    }
                }
            };

            return View(users);
        }

    }
}
```

---
# Views
- Views are the basic element to your Site. HTML Files a.k.a Frontend. 
### Layout / Templating
- If you open the file `/Views/Shared/_Layout.cshtml`. Here's an example of it.
- As learned above on how to bind a value to a ViewBag Key.
- `RenderBody()` is where your specific Template File (View) will be rendered into the <body></body> codeblock. 
```html
<!DOCTYPE html>
<html>
<head>
    <!-- 
    This Layout Template has ViewBag where it appends and binds the parameters from the View or Controller. 
    Magic? No, just a convenient way!
    -->
    <title>@ViewBag.Title</title>
    <meta charset="utf-8"/>
</head>
<body>
	@RenderBody()
</body>
</html>

```

### YEETME before extending
```
<!-- 
Any HTML entered here gets auto rendered into the <body></body> of your Layout Template File.
-->

<!--
Have a custom template?
Sure, you can add it as well
-->

@* @{ *@
@*     Layout = "~/Views/Shared/_Layout.cshtml"; *@
@* } *@

<!-- 
Do you want Dynamic Value Binding?
Like page title, etc?
Yes, you can too!

ASP uses @{} syntax, it's exactly like a templating engine. If you are used to Flask's Jinja or Laravel's Blade, they are the same. 
ASP also uses ViewBag, this is used to pass parameters into the View asynchronously without impacting the view's performance.
-->

@{
    ViewBag.Title = "Home";
}

<p>Hello World. This is the main page. Now check the Page Title on the top! Is it the same with ViewBag?</p
```

### Example of extending the Layout Template.
- Please note that it can be anything ~ The Layout File.
```html
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Wazzup!</h2>
```

### Example of extending Layout AND ViewBag
```html
@{
    ViewBag.Title = "Make User";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Me is gae</h2>

```

### Call a Model and return the Data passed from the Controller.
- This View is for the GET /users/return/one route as above.
```html
@model MVCTutorial.Models.User

@{
    ViewBag.Title = "Make User";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>@Model.username with the ID of @Model.Id</h2>
```

---