namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class AddressHandler(PersonManagerDbContext context) : IAddressHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreateAddressAsync(AddressModel address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddressAsync(int addressId)
    {
        var addressToDelete = await _context.Addresses.FindAsync(addressId)
            ?? throw new ArgumentNullException(nameof(addressId), "Address not found");

        _context.Addresses.Remove(addressToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<AddressModel> GetAddressByIdAsync(int addressId) =>
        await _context.Addresses
            .Include(a => a.Person)
            .Include(a => a.AddressType)
            .FirstOrDefaultAsync(a => a.AddressId == addressId);

    public async Task<List<AddressModel>> GetAddressesAsync(int personId) =>
        await _context.Addresses
            .Include(a => a.Person)
            .Include(a => a.AddressType)
            .Where(a => a.PersonId == personId)
            .ToListAsync();

    public async Task UpdateAddressAsync(AddressModel address)
    {
        var addressToUpdate = _context.Addresses.Find(address.AddressId);
        if (addressToUpdate is null)
        {
            throw new ArgumentNullException(nameof(addressToUpdate), "Address not found");
        }

        addressToUpdate.AddressLine1 = address.AddressLine1;
        addressToUpdate.AddressLine2 = address.AddressLine2;
        addressToUpdate.City = address.City;
        addressToUpdate.PostCode = address.PostCode;
        addressToUpdate.AddressTypeId = address.AddressTypeId;

        await _context.SaveChangesAsync();
    }
}
