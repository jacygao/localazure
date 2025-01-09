using System.CommandLine;

namespace localazure;

class Program
{
    static int Main(string[] args)
    {
        // Options
        var serviceOption = new Option<string>(
            name: "--service",
            description: "choose from one of the supported the services");

        var portOption = new Option<int>(
            name: "--port",
            description: "choose the port to start the service on");

        // Commands
        var rootCommand = new RootCommand("LocalAzure Command Line Interface");

        var startCommand = new Command("start", "start a service on a given port")
        {
            serviceOption,
            portOption,
        };

        rootCommand.AddCommand(startCommand);

        startCommand.SetHandler(async (service, port) =>
        {
            await StartService(service, port);
        }, serviceOption, portOption);

        return rootCommand.InvokeAsync(args).Result;
    }

    static async Task StartService(string service, int port)
    {
        if (string.IsNullOrEmpty(service))
        {
            Console.WriteLine("Please specify a service to start.");
            return;
        }

        Console.WriteLine($"Starting {service} on port {port}...");

        // Here you can implement the logic to start the service
        // For demonstration, we'll just simulate it with a delay
        await Task.Delay(1000);

        Console.WriteLine($"{service} started on port {port}.");
    }
}
