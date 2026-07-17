namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IRelationshipHandler
{
    Task<RelationshipModel> GetRelationshipByIdAsync(int relationshipId);

    Task<List<RelationshipModel>> GetAllRelationshipsAsync();

    Task CreateRelationshipAsync(RelationshipModel  relationshipModel);

    Task UpdateRelationshipAsync(RelationshipModel relationship);

    Task DeleteRelationshipAsync(int relationshipId);
}