using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }
    public async Task<List<SubmissionResponseModel>> GetSubmissionByJobId(int id)
    {
        var submissions = await _submissionRepository.GetSubmissionByJobId(id);
        var submissionResponseModel = new List<SubmissionResponseModel>();

        foreach (var s in submissions)
            submissionResponseModel.Add(new SubmissionResponseModel()
            {
                Id = s.Id, JobId = s.JobId, CandidateId = s.CandidateId, Candidate = s.Candidate
            });

        return submissionResponseModel;
    }

    public async Task<SubmissionResponseModel> GetSubmissionById(int id)
    {
        var submission = await _submissionRepository.GetSubmissionById(id);
        if (submission == null)
        {
            return null;
        }
        var submissionResponseModel = new SubmissionResponseModel(){
        Id = submission.Id, JobId = submission.JobId, CandidateId = submission.CandidateId, Candidate = submission.Candidate
        };

        return submissionResponseModel;
    }

    public async Task<List<SubmissionResponseModel>> GetAllSubmission()
    {
        var submissions = await _submissionRepository.GetAllSubmission();
        var submissionResponseModel = new List<SubmissionResponseModel>();

        foreach (var s in submissions)
            submissionResponseModel.Add(new SubmissionResponseModel()
            {
                Id = s.Id, JobId = s.JobId, CandidateId = s.CandidateId, Candidate = s.Candidate
            });

        return submissionResponseModel;
    }

    public async Task<int> AddSubmission(SubmissionRequestModel model)
    {
        var SubmissionEntity = new Submission
        {
            JobId = model.JobId,CandidateId = 1,RejectedReason = ""
        };

        var submission = await _submissionRepository.AddAsync(SubmissionEntity);
        return submission.Id;
    }
}