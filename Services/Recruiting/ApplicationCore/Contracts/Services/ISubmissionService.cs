using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    Task<SubmissionResponseModel> GetSubmissionById(int id);
    Task<int> AddSubmission(SubmissionRequestModel model);
}