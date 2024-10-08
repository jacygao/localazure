# Event Hub

Event Hub Local Simulation leverages the [Event Hub Emulator](https://github.com/MicrosoftDocs/azure-docs/blob/main/articles/event-hubs/test-locally-with-event-hub-emulator.md) pubished by Microsoft and runs it in a Docker Container.

## Start Cosmos DB Emulator in Docker

>[!NOTE]
>Event Hub Emulator depends on Azurite. Please ensure Azurite is not disabled in the docker-compose.yaml

Under application root directory, run
```
docker compose up
```

Event Hub is fully up and running when you see following output:

```
azurite    | 192.168.16.3 - - [08/Oct/2024:11:47:53 +0000] "GET /devstoreaccount1/EventHub?$filter=%28%28%28%28PartitionKey%20eq%20%270%27%20%28%28PartitionKey%20eq%20%270%27%29%20and%20%28RowKey%20eq%20%273_EMULATORNS1%3AEVENTHUB%3AEH1~32766%7C%24DEFAULT%27%29%29%29%20or%20%28766%7C%24DEFAULT%27%29%29%29%20or%20%28%28PartitionKey%20eq%20%270%27%29%20and%20%28RowKey%20eq%20%270_EMULATORNS1%3AEVENTHUB%3AEH1~32766%7
azurite    | 192.168.16.3 - - [08/Oct/2024:11:47:53 +0000] "GET /devstoreaccount1/EventHub?$filter=%28PartitionKey%20eq%20%270%27%29%20and%
eventhubs  | info: a.a.aap[0]
eventhubs  |       Emulator Service is Successfully Up! ; Use connection string : "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;"
```

## Configure Event Hub

You can manage the number of event hubs, partitions, and other entities by using the JSON supplied configuration.

Update the [EventHubConfig.json](../EventHubConfig.json) file according to your local Event Hub configuration.

### Quota

Like the Event Hubs cloud service, the emulator provides the following quotas for usage:

| Property| Value| User configurable within limits
| ----|----|----
| Number of supported namespaces| 1 |No
| Maximum number of event hubs in a namespace| 10| Yes
| Maximum number of consumer groups in an event hub| 20 |Yes
| Maximum number of partitions in an event hub |32 |Yes
| Maximum size of an event being published to an event hub (batch/nonbatch) |1 MB |No
| Minimum event retention time | 1 h | No

## Create local Event Hub Client
```
private static readonly string connectionString = "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";

private static readonly string hubName = "eh1";

EventHubProducerClient producerClient = new EventHubProducerClient(connectionString, hubName);
```

You can find more examples [here](../Samples/DotNet/EventHubSample/EventHubSample/Program.cs)

### Limitation

The current version of the emulator has the following limitations:

- It can't stream messages by using the Kafka protocol.  
- It doesn't support on-the-fly management operations through a client-side SDK.

> [!NOTE]
> After a container restart, data and entities don't persist in the emulator.

