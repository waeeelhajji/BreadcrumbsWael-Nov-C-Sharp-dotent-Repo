using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinQLecture.Models;

namespace LinQLecture.Controllers;

public class HomeController : Controller
{
    public static Game[] AllGames = new Game[] {
        new Game {Title="Elden Ring", Price=59.99, Genre="Action RPG", Rating="M", Platform="PC"},
        new Game {Title="League of Legends", Price=0.00, Genre="MOBA", Rating="T", Platform="PC"},
        new Game {Title="World of Warcraft", Price=39.99, Genre="MMORPG", Rating="T", Platform="PC"},
        new Game {Title="Elder Scrolls Online", Price=14.99, Genre="Action RPG", Rating="M", Platform="PC"},
        new Game {Title="Smite", Price=0.00, Genre="MOBA", Rating="T", Platform="All"},
        new Game {Title="Overwatch", Price=39.00, Genre="First-person Shooter", Rating="T", Platform="PC"},
        new Game {Title="Scarlet Nexus", Price=59.99, Genre="Action JRPG", Rating="T", Platform="All"},
        new Game {Title="Wonderlands", Price=59.99, Genre="RPG FPS", Rating="M", Platform="All"},
        new Game {Title="Rocket League", Price=0.00, Genre="Sports", Rating="E", Platform="All"},
        new Game {Title="StarCraft", Price=0.00, Genre="RTS", Rating="T", Platform="PC"},
        new Game {Title="God of War", Price=29.99, Genre="Action-adventure ", Rating="M", Platform="PC"},
        new Game{Title="Doki Doki Literature Club Plus!", Price=10.00, Genre="Casual", Rating="E", Platform="PC"},
        new Game {Title="Red Dead Redemption", Price=40.00, Genre="Action adventure", Rating="M", Platform="All"},
        new Game {Title="Zy Little Pony A Maretime Bay Adventure", Price=39.99, Genre="Adventure", Rating="E",Platform="All"},
        new Game {Title="Fallout New Vegas", Price=10.00, Genre="Open World RPG", Rating="M", Platform="PC"}
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // this get all the data from the database
        List<Game> allGamesFromData = AllGames.ToList();
        ViewBag.allGames = allGamesFromData;
        // Get All games on all platforms
        List<Game> allPlatforms = AllGames.Where(f => f.Platform == "All").ToList();
        ViewBag.PlatformsGames = allPlatforms;

        // Get All Games that the Rating is M with the order prices
        List<Game> topGames = AllGames.Where(g => g.Rating == "M").OrderBy(s => s.Price).ToList();
        ViewBag.TopGames = topGames;

        // Get all the data Order by they Title
        List<Game> titleGames = AllGames.OrderBy(s => s.Title).ToList();
        ViewBag.titleGames = titleGames;
         // Get all the data Order by they descending Title
        List<Game> titleGamesd = AllGames.OrderByDescending(s => s.Title).ToList();
        ViewBag.titleGamesd = titleGamesd;

        // All Top 3 Games that has the most expensive Prices
        List<Game> Top3Games = AllGames.OrderBy(a => a.Price).Take(3).ToList();
        ViewBag.Top3Games = Top3Games;

    //All platforms Games with Rating E
        List<Game> AllPlatformGWithRatingE = AllGames.Where(f => f.Platform == "All" && f.Rating == "E").ToList();
        ViewBag.AllPlatformGWithRatingE = AllPlatformGWithRatingE;

        Game singleGame = AllGames.FirstOrDefault(d => d.Title == "God of War");
        ViewBag.singleGame = singleGame;


        return View();
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
