using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    public List<JobResponseModel> GetAllJobs()
    {
        // have some dummy data
        // get the data from repositories and send he model info to controllers
        var jobs = new List<JobResponseModel>
        {
            new() { Id = 1, Title = ".NET Developer", Description = "Need to be good with C# and EF Core and .NET" },
            new()
            {
                Id = 2, Title = "Full Stack .NET Developer",
                Description = "Need to be good with Typescript, C# and EF Core and .NET"
            },
            new() { Id = 3, Title = "Java Developer", Description = "Need to be good with Java" },
            new() { Id = 4, Title = "JavaScript Developer", Description = "Need to be good JavaScript" }
        };

        return jobs;
    }

    public JobResponseModel GetJobById(int id)
    {
        return new JobResponseModel
            { Id = 4, Title = "JavaScript Developer", Description = "Need to be good JavaScript" };
    }
}