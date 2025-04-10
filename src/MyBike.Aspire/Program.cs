using Projects;

var builder = DistributedApplication.CreateBuilder(args);
var api = builder.AddProject<MyBike_API>("MyBikeAPI");

var ui = builder
    .AddNpmApp("MyBikeUI", "../MyBike.UI")
    .WithReference(api)
    .WaitFor(api)
    .WithHttpEndpoint(env: "PORT", port: 4201)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();