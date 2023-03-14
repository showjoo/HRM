using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobsController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    // GET
    [HttpGet]
    public IActionResult Details(int id)
    {
        return View();
    }
}