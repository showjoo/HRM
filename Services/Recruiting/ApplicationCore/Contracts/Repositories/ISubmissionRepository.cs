using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository : IRepository<Submission>
{
    public Task<List<Submission>> GetSubmissionByJobId(int id);
    Task<Submission> GetSubmissionById(int id);
    Task<List<Submission>> GetAllSubmission();
}