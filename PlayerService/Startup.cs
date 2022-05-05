using Microsoft.AspNetCore.Authentication.JwtBearer;
using PlayerService.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

public class Startup
{
    public IConfiguration Configuration { get; }
    private readonly IWebHostEnvironment _env;
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        if (_env.IsProduction())
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("PlayerConnect"))
            );
        }
        else
        {
            Console.WriteLine("Using InMem DbContext");
            services.AddDbContext<AppDbContext>(opt =>
                 opt.UseInMemoryDatabase("InMem"));
        }
        // Interface > Concrete Class pattern
        services.AddScoped<IPlayerRepo, PlayerRepo>();
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer();

        services.AddAuthorization();
        services.AddControllers();
        // Swagger/OpenAPI https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
    //Request Pipeline. This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapGet("/dashboard", () =>
        {
            return "yo";
        }).RequireAuthorization();
        Seed.SeedPlayer0(app);
        app.Run();
    }
}
