using Go2Climb.API.Agencies.Domain.Repositories;
using Go2Climb.API.Agencies.Domain.Services;
using Go2Climb.API.Agencies.Persistence.Repositories;
using Go2Climb.API.Agencies.Services;
using Go2Climb.API.Customers.Domain.Repositories;
using Go2Climb.API.Customers.Domain.Services;
using Go2Climb.API.Customers.Persistence.Repositories;
using Go2Climb.API.Customers.Services;
using Go2Climb.API.Mapping;
using Go2Climb.API.Persistence.Contexts;
using Go2Climb.API.Shared.Domain.Repositories;
using Go2Climb.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using safeclimb_security.Security.Security.Authorization.Handlers.Implementations;
using safeclimb_security.Security.Security.Authorization.Handlers.Interfaces;
using safeclimb_security.Security.Security.Authorization.Middleware;
using safeclimb_security.Security.Security.Authorization.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(options => 
{
    // Add API Documentation Information
        
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Profile Context - SafeClimb API",
        Description = "Profile Context - RESTful API",
        TermsOfService = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/"),
        Contact = new OpenApiContact
        {
            Name = "Safeclimb.studio",
            Url = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/")
        },
        License = new OpenApiLicense
        {
            Name = "Safeclimb Resources License",
            Url = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/")
        }
    });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IAgencyService, AgencyService>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));


var app = builder.Build();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling Middleware

app.UseMiddleware<JwtMiddleware>();
// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();