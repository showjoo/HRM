using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobsController : Controller
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        var jobs = _jobService.GetAllJobs();
        return View();
    }
    // GET
    [HttpGet]
    public IActionResult Details(int id)
    {
        var jobs = _jobService.GetJobById(3);
        return View();
    }
}