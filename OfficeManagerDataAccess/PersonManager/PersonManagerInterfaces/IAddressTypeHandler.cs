namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IAddressTypeHandler
{

    Task<AddressTypeModel> GetAddressTypeByIdAsync(int addressTypeId);

    Task<List<AddressTypeModel>> GetAllAddressTypesAsync();

    Task CreateAddressTypeAsync(AddressTypeModel addressType);

    Task UpdateAddressTypeAsync(AddressTypeModel addressType);

    Task DeleteAddressTypeAsync(int addressTypeId);
}
