namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class RelationshipBasePageClass : BasePageClass
{
    [Inject] protected IRelationshipHandler RelationshipHandler { get; set; } = null!;

    [Parameter] public int RelationshipId { get; set; }

    protected RelationshipModel RelationshipModel { get; set; } = new();

    protected RelationshipDisplayModel RelationshipDisplayModel { get; set; } = new();

    protected string RelationshipSingular = "Relationship";

    protected string RelationshipPlural = "Relationships";

    protected BreadcrumbItem GetRelationshipHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(RelationshipPlural, "/relationships/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        RelationshipModel.RelationshipId = RelationshipDisplayModel.RelationshipId;
        RelationshipModel.RelationshipName = RelationshipDisplayModel.RelationshipName;
    }
    
    protected void CopyModelToDisplayModel()
    {
        RelationshipDisplayModel.RelationshipId = RelationshipModel.RelationshipId;
        RelationshipDisplayModel.RelationshipName = RelationshipModel.RelationshipName;
        RelationshipDisplayModel.PersonCount = RelationshipModel.EmergencyContacts.Count;
    }
}
