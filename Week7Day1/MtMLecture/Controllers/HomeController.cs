using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtMLecture.Models;

namespace MtMLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllActors = _context.Actors.Include(s =>s.MyMovies).ThenInclude(s => s.Movie).ToList();
        return View();
    }

    [HttpPost("/add/actor")]
    public IActionResult CreateActor(Actor newActor)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newActor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index");
    }
    [HttpGet("Movies")]
    public IActionResult Movies()
    {
        ViewBag.AllMovies = _context.Movies.Include(a=>a.MyActors).ThenInclude(q=> q.Actor).ToList();
        return View();
    }
    [HttpPost("add/movie")]
    public IActionResult CreateMovie(Movie newMovie)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMovie);
            _context.SaveChanges();
            return RedirectToAction("Movies");
        }
        return View("Movies");
    }
    [HttpGet("association")]
    public IActionResult Association()
    {
        ViewBag.AllMovies = _context.Movies.ToList();
        ViewBag.AllActors = _context.Actors.ToList();
        return View();
    }
    [HttpPost("association/add")]
    public IActionResult CreateAssociation(Association newAssociation)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.AllMovies = _context.Movies.ToList();
        ViewBag.AllActors = _context.Actors.ToList();
        return View("Association");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
