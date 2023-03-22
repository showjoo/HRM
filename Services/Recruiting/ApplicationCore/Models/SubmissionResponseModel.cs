using ApplicationCore.Entities;

namespace ApplicationCore.Models;

public class SubmissionResponseModel
{
    public int Id { get; set; }

    public int JobId { get; set; }
    public int CandidateId { get; set; }
    
    public Candidate Candidate { get; set; }
}