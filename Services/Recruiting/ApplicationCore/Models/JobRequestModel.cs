using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter title of the job")]
    [StringLength(256)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter Job Description")]
    [StringLength(5000)]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Plase enter Job Start Date")]
    // start date cannot be in the cast
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Please enter number")]
    public int NumberOfPositions { get; set; }

    [Required(ErrorMessage = "Please select 1 JobStatus")]
    public int JobStatus { get; set; }
}