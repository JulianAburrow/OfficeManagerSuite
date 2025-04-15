
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
        var addressTypeToDelete = await _context.AddressTypes.FindAsync(addressTypeId)
            ?? throw new ArgumentNullException(nameof(addressTypeId), "Address type not found");
        
        _context.AddressTypes.Remove(addressTypeToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<AddressTypeModel> GetAddressTypeAsync(int addressTypeId) =>
        await _context.AddressTypes
            .Include(a => a.Addresses)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AddressTypeId == addressTypeId);

    public async Task<List<AddressTypeModel>> GetAddressTypesAsync() =>
        await _context.AddressTypes
                .Include(a => a.Addresses)
                .AsNoTracking()
                .OrderBy(a => a.TypeName)
                .ToListAsync();

    public async Task UpdateAddressTypeAsync(AddressTypeModel addressType)
    {
        var addressTypeToUpdate = await _context.AddressTypes.FindAsync(addressType.AddressTypeId)
            ?? throw new ArgumentNullException(nameof(addressType.AddressTypeId), "Address type not found");

        addressTypeToUpdate.TypeName = addressType.TypeName;

        await _context.SaveChangesAsync();
    }
}
