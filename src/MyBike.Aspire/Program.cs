using Projects;

var builder = DistributedApplication.CreateBuilder(args);
var mybikeapi = builder
    .AddProject<MyBike_API>("mybikeapi")
    .WithExternalHttpEndpoints();

var ui = builder
    .AddNpmApp("MyBikeUI", "../MyBike.UI")
    .WithReference(mybikeapi)
    .WaitFor(mybikeapi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();