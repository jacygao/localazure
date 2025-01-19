using Aspire.Hosting;
using Gateway.AppHost.Options;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);


// Run CosmsoDB Emulator
var cosmosdbOptions = new CosmosDbOptions();
builder.Configuration.GetSection(CosmosDbOptions.Position).Bind(cosmosdbOptions);

builder.AddAzureCosmosDB("CosmosDB")
    .RunAsEmulator()
    .WithHttpsEndpoint(cosmosdbOptions.HttpsPort, 8081);

// Run Azure Storage Emulator
var azureStorageOptions = new AzureStorageOptions();
builder.Configuration.GetSection(AzureStorageOptions.Position).Bind(azureStorageOptions);

builder.AddAzureStorage("Storage")
    .RunAsEmulator()
    .WithHttpsEndpoint(azureStorageOptions.HttpsPort, 10000);

// Run Azure EventHub Emulator
var eventHubOptions = new EventHubOptions();
builder.Configuration.GetSection(EventHubOptions.Position).Bind(eventHubOptions);

builder.AddAzureEventHubs("EventHub")
    .RunAsEmulator()
    .WithHttpsEndpoint(eventHubOptions.HttpsPort, 5672)
    .AddEventHub("testHub");

// Run Azure Redis Emulator
var azureRedis = new AzureRedisOptions();
builder.Configuration.GetSection(AzureRedisOptions.Position).Bind(azureRedis);

builder.AddAzureRedis("AzureRedis")
    .RunAsContainer(instance =>
    {
        instance.WithHttpsEndpoint(azureRedis.HttpsPort, 6379);
    });

// Run Azure PostgreSql Emulator
builder.AddAzurePostgresFlexibleServer("PostgreSql")
    .RunAsContainer();

builder.Build().Run();
