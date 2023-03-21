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

    public async Task<List<Submission>> GetSubmissionById(int id)
    {
        var submission = await _dbContext.Submissions.Where(s => s.Id == id).ToListAsync();
        return submission;
    }
}