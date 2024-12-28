using UserQuery.Authentication.Option;
using UserQuery.WebApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

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

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGroup("")
   .WithTags("Products endpoints")
   .MapProductskEndPoint();

app.InitializeDB();

app.Run();
