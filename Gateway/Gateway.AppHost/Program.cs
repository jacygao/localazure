var builder = DistributedApplication.CreateBuilder(args);

// Run CosmsoDB Emulator
builder.AddAzureCosmosDB("CosmosDB")
    .RunAsEmulator()
    .WithHttpsEndpoint(8081, 8081);

// Run Azure Storage Emulator
builder.AddAzureStorage("Storage")
    .RunAsEmulator()
    .WithHttpsEndpoint(10000, 10000);

//Run EventHub Emulator
builder.AddAzureEventHubs("EventHub")
    .RunAsEmulator()
    .WithHttpsEndpoint(5672,5672)
    .AddEventHub("testHub");

builder.Build().Run();
