namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IEmploymentStatusHandler
{
    Task<List<EmploymentStatusModel>> GetEmploymentStatusesAsync();

    Task<EmploymentStatusModel> GetEmploymentStatusAsync(int employmentStatusId);

    Task CreateEmploymentStatusAsync(EmploymentStatusModel employmentStatus);

    Task UpdateEmploymentStatusAsync(EmploymentStatusModel employmentStatus);

    Task DeleteEmploymentStatusAsync(int employmentStatusId);
}
