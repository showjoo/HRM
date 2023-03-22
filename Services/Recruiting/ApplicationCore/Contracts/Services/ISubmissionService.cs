using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    Task<List<SubmissionResponseModel>> GetSubmissionByJobId(int id);
    Task<SubmissionResponseModel> GetSubmissionById(int id);
    Task<List<SubmissionResponseModel>> GetAllSubmission();
    Task<int> AddSubmission(SubmissionRequestModel model);
}