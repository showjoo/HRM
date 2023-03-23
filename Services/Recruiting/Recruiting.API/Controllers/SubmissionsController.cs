using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _SubmissionService;
        public SubmissionsController(ISubmissionService submissionService)
        {
            _SubmissionService = submissionService;
        }
        
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllSubmission()
        {
            var submissions = await _SubmissionService.GetAllSubmission();

            if (!submissions.Any())
            {
                // no jobs exists, then 404
                return NotFound(new { error ="No open submissions found, please try later" });
            }
            // return Json data, and also HTTP status codes
            // serialization C# objects into Json Objects using System.Text.Json
            return Ok(submissions);
        }

        [HttpGet]
        [Route("/JobId={id:int}",Name="GetSubmissionByJobId")]
        public async Task<IActionResult> GetSubmissionByJobId(int id)
        {
            var submissions = await _SubmissionService.GetSubmissionByJobId(id);
            if (!submissions.Any())
            {
                // no jobs exists, then 404
                return NotFound(new { error ="No open submissions found for this job id, please try later" });
            }

            return Ok(submissions);
        }
        
        [HttpGet]
        [Route("/{id:int}",Name="GetSubmissionById")]
        public async Task<IActionResult> GetSubmissionById(int id)
        {
            var submissions = await _SubmissionService.GetSubmissionById(id);
            if (submissions == null)
            {
                return NotFound(new { errorMessage = "No submission found for this id " });
            }

            return Ok(submissions);
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (!ModelState.IsValid)
                // 400 status code
                return BadRequest();

            var submission = await _SubmissionService.AddSubmission(model);
            return CreatedAtAction
                ("GetSubmissionById", new { controller = "Submissions", id = submission }, "Job Created");
        }
    }
}
