using Identity;
using Identity.Services;
using Refit;
using Identity.Factory;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    // Controller support
    services.AddControllers();
    services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    
    //Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        // Add header documentation in Swagger
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Identity API",
            Description = "This is the best API for Identity",
            Contact = new OpenApiContact
            {
                Name = "Group 5",
                Url = new Uri("https://www.facebook.com/jca.kt")
            }
        });
        // Feed generated xml api docs to Swagger
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    //Refit
    services.AddRefitClient<IAgifyClient>()
        .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.agify.io/"));
    services.AddRefitClient<IGenderClient>()
        .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.genderize.io/"));
    services.AddRefitClient<INationalizeClient>()
        .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.nationalize.io/"));

    //Services and Factory to inject
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<IAgeBracketFactory, AgeBracketFactory>();
}