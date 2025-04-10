using Projects;

var builder = DistributedApplication.CreateBuilder(args);

//var sql = builder.AddSqlServer("MyBikeSQL");

builder.AddProject<MyBike_API>("MyBikeAPI");

builder.Build().Run();