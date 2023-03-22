using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubmissionRepository: Repository<Submission>,ISubmissionRepository
{
    private RecruitingDbContext _dbContext;
    public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Submission>> GetSubmissionByJobId(int id)
    {
        var submission = await _dbContext.Submissions.Where(s => s.JobId == id).ToListAsync();
        return submission;
    }

    public async Task<Submission> GetSubmissionById(int id)
    {
        var submission = await _dbContext.Submissions.Where(s => s.Id == id).FirstOrDefaultAsync();
        return submission;
    }

    public async Task<List<Submission>> GetAllSubmission()
    {
        var submission = await _dbContext.Submissions.ToListAsync();
        return submission;
    }
}