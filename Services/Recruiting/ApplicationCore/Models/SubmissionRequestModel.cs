using System.ComponentModel.DataAnnotations;
namespace ApplicationCore.Models;

public class SubmissionRequestModel
{
    public int JobId { get; set; }
    [Required(ErrorMessage = "Please enter your first name")]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Please enter your Last name")]
    [StringLength(50)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Please enter your Email")]
    [StringLength(512)]
    public string Email { get; set; }
}