using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using loginRegDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace loginRegDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;         

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;   
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            //?Hash our Password
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser,newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId",newUser.UserId);
            return RedirectToAction("Success");
        }
        else {
            return View("Index");
        }
    }

    [HttpPost("User/login")]
    public IActionResult LoginUser(LogUser LoginUser)
    {
        if(ModelState.IsValid)
        {
            // look up our user in the database
            User? userInDB = _context.Users.FirstOrDefault(u => u.Email == LoginUser.LogEmail);
            // we need to verify this is a user who exists
            if(userInDB==null)
            {
                ModelState.AddModelError("LogEmail","Invalid Email/Password");
            }
            //Verify the password matches what is in the database 
            PasswordHasher<LogUser> hasher =  new PasswordHasher<LogUser>();
            var result= hasher.VerifyHashedPassword(LoginUser, userInDB.Password, LoginUser.LogPassword);
            if(result == 0)
            {

                // failure, we did not use the right password
                ModelState.AddModelError("LogEmail","Invalid Email/Password");
                return View("Index");
            }else {
                // Set Session and head tp Success
                HttpContext.Session.SetInt32("UserId",LoginUser.UserId);
                return RedirectToAction("Success");
            }
            
        }else {
            return View("Index");
        }
    }





    [HttpGet("success")]
    [SessionCheck]
    public IActionResult Success()
    {
        
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if(userId==null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}