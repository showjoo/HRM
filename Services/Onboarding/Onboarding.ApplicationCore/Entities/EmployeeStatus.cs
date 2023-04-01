namespace Onboarding.ApplicationCore.Entities;
// Hired, Terminated, Pending
public class EmployeeStatus
{
    public int Id { get; set; }
    public string EmployeeStatusCode { get; set; }
    public string EmployeeStatusDescription { get; set; }

}