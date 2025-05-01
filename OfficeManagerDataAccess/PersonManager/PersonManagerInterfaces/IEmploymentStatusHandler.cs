namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IEmploymentStatusHandler
{
    Task<List<EmploymentStatusModel>> GetAllEmploymentStatusesAsync();

    Task<EmploymentStatusModel> GetEmploymentStatusByIdAsync(int employmentStatusId);

    Task CreateEmploymentStatusAsync(EmploymentStatusModel employmentStatus);

    Task UpdateEmploymentStatusAsync(EmploymentStatusModel employmentStatus);

    Task DeleteEmploymentStatusAsync(int employmentStatusId);
}
