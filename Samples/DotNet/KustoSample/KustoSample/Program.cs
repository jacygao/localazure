using System;
using System.Threading.Tasks;
using Kusto.Data;
using Kusto.Data.Common;
using Kusto.Data.Net.Client;
using Kusto.Ingest;

internal class Program
{
    private static readonly string KustoConnectionString = "http://localhost:8080";
    private static readonly string DatabaseName = "SampleDatabase";
    private static readonly string TableName = "SampleTable";

    public static async Task Main(string[] args)
    {
        var kustoConnectionStringBuilder = new KustoConnectionStringBuilder(KustoConnectionString);

        using var queryProvider = KustoClientFactory.CreateCslQueryProvider(kustoConnectionStringBuilder);
        using var adminProvider = KustoClientFactory.CreateCslAdminProvider(kustoConnectionStringBuilder);
        using var ingestClient = KustoIngestFactory.CreateQueuedIngestClient(kustoConnectionStringBuilder);

        try
        {
            await CreateDatabase(adminProvider);
            await CreateTable(adminProvider);
            //await IngestData(ingestClient);
            await QueryData(queryProvider);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static async Task CreateDatabase(ICslAdminProvider adminProvider)
    {
        var command = CslCommandGenerator.GenerateDatabaseCreateCommand(DatabaseName, "", true);
        await adminProvider.ExecuteControlCommandAsync(DatabaseName, command, null);
        Console.WriteLine($"Database '{DatabaseName}' created.");
    }

    private static async Task CreateTable(ICslAdminProvider adminProvider)
    {
        var command = $".create table {TableName} (Column1:string, Column2:int, Column3:datetime)";
        await adminProvider.ExecuteControlCommandAsync(DatabaseName, command, null);
        Console.WriteLine($"Table '{TableName}' created.");
    }

    private static async Task IngestData(IKustoIngestClient ingestClient)
    {
        var data = "Column1,Column2,Column3\nValue1,1,2024-01-01T00:00:00Z\nValue2,2,2024-01-02T00:00:00Z";
        var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data));
        var ingestionProperties = new KustoIngestionProperties(DatabaseName, TableName)
        {
            Format = DataSourceFormat.csv,
        };
        await ingestClient.IngestFromStreamAsync(stream, ingestionProperties);
        Console.WriteLine("Data ingested.");
    }

    private static async Task QueryData(ICslQueryProvider queryProvider)
    {
        var query = $"{TableName} | take 10";
        var reader = await queryProvider.ExecuteQueryAsync(DatabaseName, query, null);
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]}, {reader[1]}");
        }
    }
}