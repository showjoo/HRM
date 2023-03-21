using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository : IRepository<Submission>
{
    public Task<List<Submission>> GetSubmissionById(int id);

}