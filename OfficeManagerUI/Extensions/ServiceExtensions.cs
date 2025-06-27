namespace OfficeManagerUI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlConnections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PersonManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PersonManagerConnection")));
        services.AddDbContext<VehicleManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("VehicleManagerConnection")));
    }

    public static void AddPersonManagerDependencies(this IServiceCollection services)
    {
        services.AddTransient<IAddressHandler, AddressHandler>();
        services.AddTransient<IAddressTypeHandler, AddressTypeHandler>();
        services.AddTransient<IEmergencyContactHandler, EmergencyContactHandler>();
        services.AddTransient<IEmploymentStatusHandler, EmploymentStatusHandler>();
        services.AddTransient<IGenderHandler, GenderHandler>();
        services.AddTransient<IPersonalPronounsHandler, PersonalPronounsHandler>();
        services.AddTransient<IPersonHandler, PersonHandler>();
    }

    public static void AddVehicleManagerDependencies(this IServiceCollection services)
    {
        services.AddTransient<IColourHandler, ColourHandler>();
        services.AddTransient<IManufacturerHandler, ManufacturerHandler>();
        services.AddTransient<IModelHandler, ModelHandler>();
        services.AddTransient<IVehicleHandler, VehicleHandler>();
    }
}
