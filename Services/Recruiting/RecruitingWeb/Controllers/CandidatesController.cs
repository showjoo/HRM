using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class CandidatesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}