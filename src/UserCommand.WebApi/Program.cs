var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddCoreServices(option =>
{
    builder.Configuration.GetRequiredSection(UsersOptions.SectionKey)
    .Bind(option);
});

builder.Services.AddRepositoriesServices(option =>
{
    builder.Configuration.GetRequiredSection(DBOptions.SectionKey)
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

app.UseCors();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGroup("")
   .WithTags("Products endpoints")
   .MapUsersEndPoint();

app.InitializeDB();

app.Run();