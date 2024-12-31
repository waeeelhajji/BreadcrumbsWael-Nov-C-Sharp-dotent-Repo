using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using databaseLecture.Models;

namespace databaseLecture.Controllers;

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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("songs/create")]
    public IActionResult CreateSong(Song newSong)
    {
        if(ModelState.IsValid)
        {

            //~ _context.Songs.Add(newSong);
            _context.Add(newSong);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }else {
            return View("Index");
        }
    }
    [HttpGet("songs")]
    public IActionResult AllSongs()
    {
        List<Song> AllSongs = _context.Songs.ToList();

        return View("AllSongs",AllSongs);
    }
    [HttpPost("songs/{songId}/destroy")]
    public IActionResult DestroySong(int SongId)
    {
        Song? SongToDestroy = _context.Songs.SingleOrDefault(a => a.SongId == SongId);
        _context.Songs.Remove(SongToDestroy);
        _context.SaveChanges();
        return RedirectToAction("AllSongs");
    }

    [HttpPost("songs/{songId}/update")]
    public IActionResult UpdateSong(int songId,Song UpdatedSong)
    {
        Song? SongToUpdate = _context.Songs.FirstOrDefault(a => a.SongId==songId);
        if(SongToUpdate == null)
        {
            return RedirectToAction("Index");
        }
        if(ModelState.IsValid)
        {
            SongToUpdate.Title = UpdatedSong.Title;
            SongToUpdate.Year = UpdatedSong.Year;
            SongToUpdate.Genre = UpdatedSong.Genre;
            SongToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("AllSongs");
        }else{
            return View("EditSong",SongToUpdate);
        }
    }
    [HttpGet("songs/{songId}/edit")]
    public IActionResult EditSong(int songId)
    {
        Song? SongToUpdate = _context.Songs.FirstOrDefault(a => a.SongId==songId);
        return View("EditSong",SongToUpdate);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
