﻿namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IAddressHandler
{
    Task<AddressModel> GetAddressByIdAsync(int addressId);

    Task<List<AddressModel>> GetAddressesAsync(int personId);

    Task CreateAddressAsync(AddressModel address);

    Task UpdateAddressAsync(AddressModel address);

    Task DeleteAddressAsync(int addressId);
}
