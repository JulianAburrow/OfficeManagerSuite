
namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class AddressTypeHandler(PersonManagerDbContext context) : IAddressTypeHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreateAddressTypeAsync(AddressTypeModel addressType)
    {
        _context.AddressTypes.Add(addressType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddressTypeAsync(int addressTypeId)
    {
        var addressTypeToDelete = _context.AddressTypes.Find(addressTypeId);

        if (addressTypeToDelete is null)
        {
            throw new ArgumentNullException(nameof(addressTypeToDelete), "Address type not found");
        }

        _context.AddressTypes.Remove(addressTypeToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<AddressTypeModel> GetAddressTypeAsync(int addressTypeId) =>
        await _context.AddressTypes
            .Include(a => a.Addresses)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AddressTypeId == addressTypeId);

    public async Task<List<AddressTypeModel>> GetAddressTypesAsync()
    {
        try
        {
            var addressTypes = await _context.AddressTypes
                .Include(a => a.Addresses)
                .AsNoTracking()
                .ToListAsync();
            return addressTypes;
        }
        catch (Exception ex)
        {
            var foo = "bar";
            return new List<AddressTypeModel>();
        }
    }

    public async Task UpdateAddressTypeAsync(AddressTypeModel addressType)
    {
        var addressTypeToUpdate = await _context.AddressTypes.FindAsync(addressType.AddressTypeId);

        if (addressTypeToUpdate is null)
        {
            throw new ArgumentNullException(nameof(addressTypeToUpdate), "Address type not found");
        }

        addressTypeToUpdate.TypeName = addressType.TypeName;

        await _context.SaveChangesAsync();
    }
}
