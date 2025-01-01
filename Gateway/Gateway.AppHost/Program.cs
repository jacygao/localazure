var builder = DistributedApplication.CreateBuilder(args);

// Run CosmsoDB Emulator
builder.AddAzureCosmosDB("CosmosDB")
    .RunAsEmulator()
    .WithHttpsEndpoint(8081, 8081);
    
// Run EventHub Emulator
builder.AddAzureEventHubs("EventHub")
    .RunAsEmulator()
    .AddEventHub("testHub");

builder.Build().Run();
