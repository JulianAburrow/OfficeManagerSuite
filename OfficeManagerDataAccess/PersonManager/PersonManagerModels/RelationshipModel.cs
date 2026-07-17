namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class RelationshipModel
{
    public int RelationshipId { get; set; }

    public string RelationshipName { get; set; } = string.Empty;

    public ICollection<EmergencyContactModel> EmergencyContacts { get; set; } = [];
}
