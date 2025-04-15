namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IAddressTypeHandler
{

    Task<AddressTypeModel> GetAddressTypeAsync(int addressTypeId);

    Task<List<AddressTypeModel>> GetAddressTypesAsync();

    Task CreateAddressTypeAsync(AddressTypeModel addressType);

    Task UpdateAddressTypeAsync(AddressTypeModel addressType);

    Task DeleteAddressTypeAsync(int addressTypeId);
}
