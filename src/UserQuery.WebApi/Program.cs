using UserQuery.Authentication.Option;
using UserQuery.WebApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Configurar Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// El resto de la configuración

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    }
    );
});

builder.AddRedisDistributedCache("redis");

builder.Services.AddCoreServices(option =>
{
    builder
    .Configuration
    .GetRequiredSection(UsersOptions.SectionKey)
    .Bind(option);
});

builder.Services.AddRepositoriesServices(option =>
{
    builder
    .Configuration
    .GetRequiredSection(DBOptions.SectionKey)
    .Bind(option);
});

builder.Services.AddJwtTokenServices(option =>
{
    builder
    .Configuration
    .GetRequiredSection(AuthenticationOption.SectionKey)
    .Bind(option);
});

builder.Services.AddControllers(); 
builder.Services.AddAuthorization();


var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("")
   .WithTags("Login endpoints")
   .MapUsersEndPoint();

app.MapGroup("")
   .WithTags("Login endpoints")
   .MapLoginEndPoint();

app.InitializeDB();

app.Run();
