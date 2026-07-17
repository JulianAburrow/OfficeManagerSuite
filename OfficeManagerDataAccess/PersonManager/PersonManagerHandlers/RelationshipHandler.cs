namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class RelationshipHandler(PersonManagerDbContext context) : IRelationshipHandler
{
    private readonly PersonManagerDbContext _context = context;
    public async Task CreateRelationshipAsync(RelationshipModel relationshipModel)
    {
        _context.Relationships.Add(relationshipModel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRelationshipAsync(int relationshipId)
    {
        var relationshipToDelete = await _context.Relationships.FindAsync(relationshipId)
            ?? throw new ArgumentException(nameof(relationshipId), "Relationship not found");

        _context.Relationships.Remove(relationshipToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<List<RelationshipModel>> GetAllRelationshipsAsync() =>
        await _context.Relationships
            .Include(r => r.EmergencyContacts)
            .AsNoTracking()
            .OrderBy(r => r.RelationshipName)
            .ToListAsync();

    public async Task<RelationshipModel> GetRelationshipByIdAsync(int relationshipId) =>
        await _context.Relationships
        .Include(r => r.EmergencyContacts)
        .AsNoTracking()
        .FirstOrDefaultAsync(r => r.RelationshipId == relationshipId)
        ?? throw new ArgumentNullException(nameof(relationshipId), "Relationship not found");

    public async Task UpdateRelationshipAsync(RelationshipModel relationshipModel)
    {
        var relationshipToUpdate = await _context.Relationships.FindAsync(relationshipModel.RelationshipId)
            ?? throw new ArgumentNullException(nameof(relationshipModel.RelationshipId), "Relationship not found");

        relationshipToUpdate.RelationshipName = relationshipModel.RelationshipName;
        await _context.SaveChangesAsync();
    }
}
