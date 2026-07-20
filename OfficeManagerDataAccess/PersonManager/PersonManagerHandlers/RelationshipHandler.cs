namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class RelationshipHandler(IDbContextFactory<PersonManagerDbContext> factory) : IRelationshipHandler
{
    public async Task CreateRelationshipAsync(RelationshipModel relationshipModel)
    {
        await using var context = factory.CreateDbContext();
        context.Relationships.Add(relationshipModel);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRelationshipAsync(int relationshipId)
    {
        await using var context = factory.CreateDbContext();
        var relationshipToDelete = await context.Relationships.FindAsync(relationshipId);

        if (relationshipToDelete is null)
        {
            return;
        }

        context.Relationships.Remove(relationshipToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<List<RelationshipModel>> GetAllRelationshipsAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.Relationships
            .Include(r => r.EmergencyContacts)
            .AsNoTracking()
            .OrderBy(r => r.RelationshipName)
            .ToListAsync();
    }
        

    public async Task<RelationshipModel> GetRelationshipByIdAsync(int relationshipId)
    {
        await using var context = factory.CreateDbContext();
        var relationship = await context.Relationships
            .Include(r => r.EmergencyContacts)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.RelationshipId == relationshipId);

        return relationship ?? new RelationshipModel();
    }
        

    public async Task UpdateRelationshipAsync(RelationshipModel relationshipModel)
    {
        await using var context = factory.CreateDbContext();
        var relationshipToUpdate = await context.Relationships.FindAsync(relationshipModel.RelationshipId);

        if (relationshipToUpdate is null)
        {
            return;
        }

        relationshipToUpdate.RelationshipName = relationshipModel.RelationshipName;
        await context.SaveChangesAsync();
    }
}
