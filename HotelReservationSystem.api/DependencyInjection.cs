using HotelReservationSystem.api.Services.FacilitiesService;
using HotelReservationSystem.api.Services.RoomsService;
using HotelReservationSystem.api.Services.RoomTypeServices;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace HotelReservationSystem.api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // This line is the fix. It tells the API to serialize/deserialize enums as strings.
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }); ;

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services
                .AddDbContextConfig(configuration)
                .AddMapsterConfig()
                .AddFluentValidationConfig()
                .AddAuthConfig(configuration);

            //<> syntax denotes an "open generic type."
            services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));

            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IRoomService, RoomService>();

            return services;
        }

        private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddSingleton<IJwtProvider, JwtProvider>();

            var jwtSetting = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting?.Key!)),
                        ValidIssuer = jwtSetting?.Issuer,
                        ValidAudience = jwtSetting?.Audience
                    };
                });

            services.AddOptions<JwtOptions>()
                .BindConfiguration(JwtOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            });

            return services;
        }

        private static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("connectionString name DefaultConnection is not found");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }

        private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {
            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton<IMapper>(new Mapper(mappingConfig));

            return services;
        }

        private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
