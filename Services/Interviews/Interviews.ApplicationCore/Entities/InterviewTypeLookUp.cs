namespace Interviews.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class InterviewTypeLookUp
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string InterviewTypeCode { get; set; }

    [MaxLength(256)]
    public string InterviewTypeDescription { get; set; }
}