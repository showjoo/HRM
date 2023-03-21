using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class SubmissionService : ISubmissionService
{
    public Task<SubmissionResponseModel> GetSubmissionById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddSubmission(SubmissionRequestModel model)
    {
        throw new NotImplementedException();
    }
}