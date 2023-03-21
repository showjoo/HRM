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
    public async Task<IActionResult> Index()
    {
        var jobs = await _jobService.GetAllJobs();
        return View(jobs);
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var jobs = await _jobService.GetJobById(3);
        return View(jobs);
    }
    public IActionResult Create()
    {
        return View();
    }
}