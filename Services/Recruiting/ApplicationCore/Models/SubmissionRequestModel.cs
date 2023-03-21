using System.ComponentModel.DataAnnotations;
namespace ApplicationCore.Models;

public class SubmissionRequestModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter title of the job")]
    [StringLength(256)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter Job Description")]
    [StringLength(5000)]
    public string Description { get; set; }
}