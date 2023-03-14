using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class SubmissionsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}