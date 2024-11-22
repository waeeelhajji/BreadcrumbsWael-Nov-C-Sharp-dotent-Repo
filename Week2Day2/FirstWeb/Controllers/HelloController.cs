using Microsoft.AspNetCore.Mvc; //? this is a service that brings in our MVC Functionality
namespace FirstWeb.Controllers; //? be sure to use your own project's namesapace!

public class HelloController : Controller //? remember inheritance
{
    //! Routing
    //?this tells our controller we have a web page we want to see (or GET)
    [HttpGet]
    //~ What is the url ?
    //~ this goes to localhost:5XXX/
    [Route("")]
    //~EndPoint
    public string Index()
    {
        return " Hello from the Controller";
    }

    [HttpGet("user/more")]
    public string AUser()
    {
        return "More info about a user";
    }

    [HttpGet("user/{id}")]
    public string oneUser(int id)
    {
        return $"this is user with the number {id}";
    }

    [HttpGet("userView")]
    public ViewResult Product()
    {
        ViewBag.Name = "Jayda";
        return View("Index");
    }




}

