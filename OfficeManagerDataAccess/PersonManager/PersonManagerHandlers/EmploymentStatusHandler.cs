namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class EmploymentStatusHandler(IDbContextFactory<PersonManagerDbContext> factory) : IEmploymentStatusHandler
{
    public async Task CreateEmploymentStatusAsync(EmploymentStatusModel employmentStatus)
    {
        await using var context = factory.CreateDbContext();
        context.EmploymentStatuses.Add(employmentStatus);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEmploymentStatusAsync(int employmentStatusId)
    {
        await using var context = factory.CreateDbContext();
        var employmentStatusToDelete = await context.EmploymentStatuses.FindAsync(employmentStatusId);

        if (employmentStatusToDelete is null)
        {
            return;
        }

        context.EmploymentStatuses.Remove(employmentStatusToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<EmploymentStatusModel> GetEmploymentStatusByIdAsync(int employmentStatusId)
    {
        await using var context = factory.CreateDbContext();
        var employmentStatus = await context.EmploymentStatuses
            .Include(e => e.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmploymentStatusId == employmentStatusId);

        return employmentStatus ?? new EmploymentStatusModel();
    }
        

    public async Task<List<EmploymentStatusModel>> GetAllEmploymentStatusesAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.EmploymentStatuses
            .Include(e => e.Persons)
            .AsNoTracking()
            .OrderBy(e => e.StatusName)
            .ToListAsync();
    }
        

    public async Task UpdateEmploymentStatusAsync(EmploymentStatusModel employmentStatus)
    {
        await using var context = factory.CreateDbContext();
        var employmentStatusToUpdate = await context.EmploymentStatuses.FindAsync(employmentStatus.EmploymentStatusId);

        if (employmentStatusToUpdate is null)
        {
            return;
        }

        employmentStatusToUpdate.StatusName = employmentStatus.StatusName;
        await context.SaveChangesAsync();
    }
}
