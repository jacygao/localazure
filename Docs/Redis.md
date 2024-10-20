# Azure for Redis

Azure for Redis Local Simulation uses the [Redis Community Docker Image](https://hub.docker.com/_/redis/) to simulate Redis locally.

## Create local Redis Client

```c#
var redisConnectionString = "localhost:6379";

redis = ConnectionMultiplexer.Connect(redisConnectionString);

db = redis.GetDatabase();

```

You can find more examples [here](../Samples/DotNet/Redis/Program.cs)