namespace OfficeManagerUI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlConnections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PersonManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PersonManagerConnection")));
    }

    public static void AddPersonManagerDependencies(this IServiceCollection services)
    {
        services.AddTransient<IAddressHandler, AddressHandler>();
        services.AddTransient<IAddressTypeHandler, AddressTypeHandler>();
        services.AddTransient<IEmergencyContactHandler, EmergencyContactHandler>();
        services.AddTransient<IEmploymentStatusHandler, EmploymentStatusHandler>();
        services.AddTransient<IPersonalPronounsHandler, PersonalPronounsHandler>();
        services.AddTransient<IPersonHandler, PersonHandler>();
    }
}
