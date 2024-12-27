var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddCoreServices(option =>
{
    builder.Configuration.GetRequiredSection(ProductsOptions.SectionKey)
    .Bind(option);
});

builder.Services.AddRepositoriesServices(option =>
{
    builder.Configuration.GetRequiredSection(ProductsDBOptions.SectionKey)
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

app.MapGroup("/api/v1/")
   .WithTags("Products endpoints")
   .MapProductskEndPoint();

app.InitializeDB();

app.Run();