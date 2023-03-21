using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
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
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(JobRequestModel model)
    {
        // check if the model is valid, on the server
        if (!ModelState.IsValid)
        {
            return View();
        }
        // save the data in database
        // return to the index view
        await _jobService.AddJob(model);
        return RedirectToAction("Index");
    }
}