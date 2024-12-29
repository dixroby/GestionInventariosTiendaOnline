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

builder
    .AddProject<Projects.UserQuery_WebApi>(appuserquery)
    .WithReference(redisResources);

builder
    .AddProject<Projects.ProductsQuery_WebApi>(appproductsquery)
    .WithReference(redisResources);


builder
    .AddProject<Projects.ProductsCommand_WebApi>(appproductscommand);

builder
    .AddProject<Projects.UserCommand_WebApi>(appusercommand);

builder
    .Build()
    .Run();
