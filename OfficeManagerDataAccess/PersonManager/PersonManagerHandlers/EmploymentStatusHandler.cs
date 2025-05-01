namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class EmploymentStatusHandler(PersonManagerDbContext context) : IEmploymentStatusHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreateEmploymentStatusAsync(EmploymentStatusModel employmentStatus)
    {
        _context.EmploymentStatuses.Add(employmentStatus);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmploymentStatusAsync(int employmentStatusId)
    {
        var employmentStatusToDelete = await _context.EmploymentStatuses.FindAsync(employmentStatusId)
            ?? throw new ArgumentNullException(nameof(employmentStatusId), "Employment status not found");

        _context.EmploymentStatuses.Remove(employmentStatusToDelete);
        await _context.SaveChangesAsync();
    }

    public Task<EmploymentStatusModel> GetEmploymentStatusByIdAsync(int employmentStatusId) =>
        _context.EmploymentStatuses
            .Include(e => e.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmploymentStatusId == employmentStatusId);

    public Task<List<EmploymentStatusModel>> GetAllEmploymentStatusesAsync() =>
        _context.EmploymentStatuses
            .Include(e => e.Persons)
            .AsNoTracking()
            .OrderBy(e => e.StatusName)
            .ToListAsync();

    public async Task UpdateEmploymentStatusAsync(EmploymentStatusModel employmentStatus)
    {
        var employmentStatusToUpdate = await _context.EmploymentStatuses.FindAsync(employmentStatus.EmploymentStatusId)
            ?? throw new ArgumentNullException(nameof(employmentStatus.EmploymentStatusId), "Employment status not found");

        employmentStatusToUpdate.StatusName = employmentStatus.StatusName;
        await _context.SaveChangesAsync();
    }
}
