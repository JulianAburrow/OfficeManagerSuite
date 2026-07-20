namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class AddressTypeHandler(IDbContextFactory<PersonManagerDbContext> factory) : IAddressTypeHandler
{
    public async Task CreateAddressTypeAsync(AddressTypeModel addressType)
    {
        await using var context = factory.CreateDbContext();
        context.AddressTypes.Add(addressType);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAddressTypeAsync(int addressTypeId)
    {
        await using var context = factory.CreateDbContext();
        var addressTypeToDelete = await context.AddressTypes.FindAsync(addressTypeId);

        if (addressTypeToDelete is null)
        {
            return;
        }
        
        context.AddressTypes.Remove(addressTypeToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<AddressTypeModel> GetAddressTypeByIdAsync(int addressTypeId)
    {
        await using var context = factory.CreateDbContext();
        var addressType = await context.AddressTypes
            .Include(a => a.Addresses)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AddressTypeId == addressTypeId);

        return addressType ?? new AddressTypeModel();
    }
        

    public async Task<List<AddressTypeModel>> GetAllAddressTypesAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.AddressTypes
                .Include(a => a.Addresses)
                .AsNoTracking()
                .OrderBy(a => a.TypeName)
                .ToListAsync();
    }
        

    public async Task UpdateAddressTypeAsync(AddressTypeModel addressType)
    {
        await using var context = factory.CreateDbContext();
        var addressTypeToUpdate = await context.AddressTypes.FindAsync(addressType.AddressTypeId);

        if (addressTypeToUpdate is null)
        {
            return;
        }

        addressTypeToUpdate.TypeName = addressType.TypeName;

        await context.SaveChangesAsync();
    }
}
