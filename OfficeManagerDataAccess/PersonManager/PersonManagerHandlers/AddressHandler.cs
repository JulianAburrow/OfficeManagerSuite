namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class AddressHandler(IDbContextFactory<PersonManagerDbContext> factory) : IAddressHandler
{
    public async Task CreateAddressAsync(AddressModel address)
    {
        await using var context = factory.CreateDbContext();
        context.Addresses.Add(address);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAddressAsync(int addressId)
    {
        await using var context = factory.CreateDbContext();
        var addressToDelete = await context.Addresses.FindAsync(addressId);
            
        if (addressToDelete is null)
        {
            return;
        }

        context.Addresses.Remove(addressToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<AddressModel> GetAddressByIdAsync(int addressId)
    {
        await using var context = factory.CreateDbContext();
        var address = await context.Addresses
            .Include(a => a.Person)
            .Include(a => a.AddressType)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AddressId == addressId);

        return address ?? new AddressModel();
    }
        

    public async Task<List<AddressModel>> GetAllAddressesAsync(int personId)
    {
        await using var context = factory.CreateDbContext();
        return await context.Addresses
            .Include(a => a.Person)
            .Include(a => a.AddressType)
            .AsNoTracking() 
            .Where(a => a.PersonId == personId)
            .ToListAsync();
    }
        

    public async Task UpdateAddressAsync(AddressModel address)
    {
        await using var context = factory.CreateDbContext();
        var addressToUpdate = await context.Addresses.FindAsync(address.AddressId);
        if (addressToUpdate is null)
        {
            return;
        }

        addressToUpdate.AddressLine1 = address.AddressLine1;
        addressToUpdate.AddressLine2 = address.AddressLine2;
        addressToUpdate.City = address.City;
        addressToUpdate.Postcode = address.Postcode;
        addressToUpdate.AddressTypeId = address.AddressTypeId;
        addressToUpdate.Latitude = address.Latitude;
        addressToUpdate.Longitude = address.Longitude;

        await context.SaveChangesAsync();
    }
}
