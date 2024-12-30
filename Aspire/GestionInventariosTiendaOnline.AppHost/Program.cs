const string webbappclienteservice = nameof(webbappclienteservice);
const string appuserquery = nameof(appuserquery);
const string appproductsquery = nameof(appproductsquery);
const string appproductscommand = nameof(appproductscommand);
const string appusercommand = nameof(appusercommand);
const string redis = nameof(redis);

var builder = 
    DistributedApplication
    .CreateBuilder(args);

var redisResources =
    builder
    .AddRedis(redis);

var userQueryService = 
    builder
    .AddProject<Projects.UserQuery_WebApi>(appuserquery)
    .WithReference(redisResources);

var productQueryService =
    builder
    .AddProject<Projects.ProductsQuery_WebApi>(appproductsquery)
    .WithReference(redisResources);

var productCommandService =
builder
    .AddProject<Projects.ProductsCommand_WebApi>(appproductscommand);

var userCommandService =
builder
    .AddProject<Projects.UserCommand_WebApi>(appusercommand);
var client =
    builder.AddNpmApp("angularGestionTienda", "../../FrontEnd/GestionInventariosTiendaOnline.Cliente")
    .WithReference(productQueryService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();
    //.WithReference(productQueryService)
    //.WithHttpEndpoint(env: "PORT")
    //.WithExternalHttpEndpoints()
    //.WithReference(productCommandService)
    //.WithHttpEndpoint(env: "PORT")
    //.WithExternalHttpEndpoints()
    //.WithReference(userCommandService)
    //.WithHttpEndpoint(env: "PORT")
    //.WithExternalHttpEndpoints();

builder
    .Build()
    .Run();
