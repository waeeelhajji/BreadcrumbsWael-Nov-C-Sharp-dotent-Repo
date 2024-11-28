using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("MyNum", 56);
        return View();
    }

    [HttpPost("Login")]
    public IActionResult Login(string PassCode)
    {
        HttpContext.Session.SetString("UserName", PassCode);
        return RedirectToAction("Privacy");
    }

    public IActionResult Privacy()
    {
        if(HttpContext.Session.GetString("UserName") == null)
        {
            return Redirect("Index");
        }
        HttpContext.Session.GetInt32("MyNum");
        return View();
    }
    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
