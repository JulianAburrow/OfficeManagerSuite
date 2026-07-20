namespace OfficeManagerUI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlConnections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<PersonManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PersonManagerConnection")));
        services.AddDbContextFactory<VehicleManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("VehicleManagerConnection")));
    }

    public static void AddPersonManagerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IAddressHandler, AddressHandler>();
        services.AddTransient<IAddressTypeHandler, AddressTypeHandler>();
        services.AddTransient<IEmergencyContactHandler, EmergencyContactHandler>();
        services.AddTransient<IEmploymentStatusHandler, EmploymentStatusHandler>();
        services.AddTransient<IGenderHandler, GenderHandler>();
        services.AddHttpClient<LocationIQGeocodingService>();
        services.AddHttpClient<OpenCageGeocodingService>();
        services.AddHttpClient<OSPlacesGeocodingService>();
        var value = configuration.GetValue<string>("Geocoding:Provider");
        if (!Enum.TryParse<GeocodingProvider>(value, ignoreCase: true, out var provider))
            throw new InvalidOperationException($"Invalid geocoding provider: {value}");
        switch (provider)
        {
            case GeocodingProvider.LocationIQ:
                services.AddScoped<IGeocodingService, LocationIQGeocodingService>();
                break;
            case GeocodingProvider.OpenCage:
                services.AddScoped<IGeocodingService, OpenCageGeocodingService>();
                break;
            case GeocodingProvider.OSPlaces:
                services.AddScoped<IGeocodingService, OSPlacesGeocodingService>();
                break;
            default:
                services.AddScoped<IGeocodingService, LocationIQGeocodingService>();
                break;
        }
        services.AddTransient<IPersonalPronounsHandler, PersonalPronounsHandler>();
        services.AddTransient<IPersonHandler, PersonHandler>();
        services.AddTransient<IRelationshipHandler, RelationshipHandler>();
    }

    public static void AddVehicleManagerDependencies(this IServiceCollection services)
    {
        services.AddTransient<IColourHandler, ColourHandler>();
        services.AddTransient<IManufacturerHandler, ManufacturerHandler>();
        services.AddTransient<IModelHandler, ModelHandler>();
        services.AddTransient<IVehicleHandler, VehicleHandler>();
    }
}
