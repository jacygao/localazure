# localazure

Run azure stack locally for rapid local development and debugging.

Status: Under Development

localazure runs azure services locally via docker containers that are either published by the Azure teams or created by the community. 

The following services are currently available as local emulators:
- CosmosDB
- Event Hub
- Storage Account
- Azure PosgreSQL
- Azure Cache for Redis

The following services are planned to be included in v1
- Azure Data Explorer
- Azure Service Bus
- Azure Event Grid
- Azure KeyVault

>[!CAUTION]
>localazure is intended solely for development and testing scenarios. Any kind of Production use is strictly discouraged. There is no official support provided for localazure.

## Getting Started

>[!NOTE]
>localazure only supports Windows users at this time.

### Prerequisite
- Docker Engine
    - For Window users, get [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/#:~:text=Install%20Docker%20Desktop%20on%20Windows%201%20Download%20the,on%20your%20choice%20of%20backend.%20...%20More%20items)
    - For Mac or Linux, please download the respective Client from [the Docker Desktop download page](https://docs.docker.com/desktop/). 

>[!NOTE]
>Before you continue with the subsequent steps, make sure Docker Engine is operational in the background.

### Start localazure

#### Start localazure on Windows
Start localazure by running:
```powershell
./Start.ps1
```
If you are running localazure for the first time, it will take some time to pull and install all the images. This will only happen for the first time. 

You may need to run following command to set the execution policy for the current PowerShell session to "Bypass," allowing script to run without any restrictions. 
```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```
This change is not persistent; it only applies to the current session and does not affect other PowerShell sessions.

### Configuration
Please refer to the respective documentation for local configuration guide.

| Service    | Documentation
| ------- | ------------ |
| Cosmos DB | [Link](./Docs/CosmosDb.md)
| Event Hub | [Link](./Docs/EventHub.md)
| Azure Data Exploror (Kusto) | [Link](./Docs/Kusto.md)
| Azure Cache for Redis | [Link](./Docs/Redis.md)
| Storage Account | [Link](./Docs/StorageAccount.md)