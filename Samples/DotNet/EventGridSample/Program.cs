using Azure.Messaging.EventGrid;
using Azure;
using Azure.Core.Serialization;
using System.Text.Json;

internal class Program
{
    private static readonly string topicEndpoint = "";
    private static readonly string topicAccessKey = "";

    public static async Task Main(string[] args)
    {
        await Send();
    }

    private static async Task Send()
    {
        EventGridPublisherClient client = new EventGridPublisherClient(
            new Uri(topicEndpoint),
            new AzureKeyCredential(topicAccessKey));

        // Example of a custom ObjectSerializer used to serialize the event payload to JSON
        var myCustomDataSerializer = new JsonObjectSerializer(
            new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        // Add EventGridEvents to a list to publish to the topic
        List<EventGridEvent> eventsList = new List<EventGridEvent>
        { 
            // EventGridEvent with custom model serialized to JSON
            new EventGridEvent(
                "ExampleEventSubject",
                "Example.EventType",
                "1.0",
                new CustomModel() { A = 5, B = true }),

            // EventGridEvent with custom model serialized to JSON using a custom serializer
            new EventGridEvent(
                "ExampleEventSubject",
                "Example.EventType",
                "1.0",
                myCustomDataSerializer.Serialize(new CustomModel() { A = 5, B = true })),
        };

        // Send the events
        await client.SendEventsAsync(eventsList);
    }
}

internal class CustomModel
{
    public int A { get; set; }
    public bool B { get; set; }
}