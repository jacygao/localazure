using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using System.Text;

internal class Program
{
    private static readonly string connectionString = "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
    private static readonly string hubName = "eh1";

    public static async Task Main(string[] args)
    {
        //Sends a batch of events to the event hub
        await Send();

        //Receives events from the event hub
        await Recieve();
    }

    private static async Task Send()
    {
        // number of events to be sent to the event hub
        int numOfEvents = 100;

        EventHubProducerClient producerClient = new EventHubProducerClient(connectionString, hubName);

        // Create a batch of events 
        using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

        for (int i = 1; i <= numOfEvents; i++)
        {
            if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event {i}"))))
            {
                // if it is too large for the batch
                throw new Exception($"Event {i} is too large for the batch and cannot be sent.");
            }
        }

        try
        {
            // Use the producer client to send the batch of events to the event hub
            await producerClient.SendAsync(eventBatch);
            Console.WriteLine($"A batch of {numOfEvents} events has been published.");
        }
        finally
        {
            await producerClient.DisposeAsync();
        }
    }

    private static async Task Recieve()
    {
        var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, hubName);

        await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(2) }))
        {
            if (partitionEvent.Data != null)
            {
                string messageBody = Encoding.UTF8.GetString(partitionEvent.Data.Body.ToArray());
                Console.WriteLine($"Message received : '{messageBody}'");
            }
            else
            {
                break;
            }
        }
    }
}

