using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services;

public interface IJobService
{
    List<JobResponseModel> GetAllJobs();
    JobResponseModel GetJobById(int id);
}