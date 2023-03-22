using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecruitingWeb.Controllers;

public class SubmissionsController : Controller
{
    
    private readonly ISubmissionService _SubmissionService;
    public SubmissionsController(ISubmissionService submissionService)
    {
        _SubmissionService = submissionService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var submission = await _SubmissionService.GetAllSubmission();
        return View(submission);
    }
    public async Task<IActionResult> Details(int id)
    {
        var submissions = await _SubmissionService.GetSubmissionByJobId(id);
        return View(submissions);
    }
    [HttpGet]
    public IActionResult Create(int Id,Guid JobCode,string Title)
    {
        TempData["id"] = Id.ToString();
        TempData["JobCode"] = JobCode.ToString();
        TempData["JobTitle"] = Title;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubmissionRequestModel model)
    {
        //model.JobId = (int)TempData["id"];
        if (!ModelState.IsValid)
        {
            return View();
        }
        // save the data in database
        // return to the index view
        await _SubmissionService.AddSubmission(model);
        return RedirectToAction("Index");
    }
}