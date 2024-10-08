# localazure

Run azure stack locally for rapid local development and debugging.

Status: Under Development

The initial version of localazure will combine a list of available docker images of azure local emulators in a docker compose file.
For long term I plan to create local implementations of a wide range of azure service, similar to [localstack for AWS](https://docs.localstack.cloud/overview/).

Please star/watch this repo if you are interested in this project. And please feel free to reach out if you would like to be a contributor.

>[!CAUTION]
>localazure is intended solely for development and testing scenarios. Any kind of Production use is strictly discouraged. There is no official support provided for localazure.

Supported Azure Services for v1

- CosmosDB
- Event Hub
- Storage Account
- Service Bus
- Event Grid
- Key Vault
- Azure Cache for Redis
- Azure Data Explorer (Kusto)

## Getting Started

### Prerequisite
- Docker
    - For Window users, get [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/#:~:text=Install%20Docker%20Desktop%20on%20Windows%201%20Download%20the,on%20your%20choice%20of%20backend.%20...%20More%20items) 
- Minimum hardware Requirements:
    - 2 GB RAM
    - 5 GB of Disk space

>[!NOTE]
>Before you continue with the subsequent steps, make sure Docker Engine is operational in the background.

### Running localazure
```bash
docker compose up
```

### Configuration
Please refer to the respective documentation for local configuration guide.

| Service    | Documentation
| ------- | ------------ |
| Cosmos DB | [Link](./Docs/CosmosDb.md)
| Event Hub | [Link](./Docs/EventHub.md)
| Azure Data Exploror (Kusto) | [Link](./Docs/Kusto.md)
| Azure Cache for Redis | [Link](./Docs/Redis.md)
| Storage Account | [Link](./Docs/StorageAccount.md)