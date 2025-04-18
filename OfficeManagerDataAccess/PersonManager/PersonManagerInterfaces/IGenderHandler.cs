namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IGenderHandler
{
    Task<GenderModel> GetGenderAsync(int genderId);

    Task<List<GenderModel>> GetGendersAsync();

    Task CreateGenderAsync(GenderModel genderModel);

    Task UpdateGenderAsync(GenderModel genderModel);

    Task DeleteGenderAsync(int genderId);
}
