namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IGenderHandler
{
    Task<GenderModel> GetGenderByIdAsync(int genderId);

    Task<List<GenderModel>> GetAllGendersAsync();

    Task CreateGenderAsync(GenderModel genderModel);

    Task UpdateGenderAsync(GenderModel genderModel);

    Task DeleteGenderAsync(int genderId);
}
