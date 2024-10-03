using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Reflection.Metadata;

internal class Program
{
    private static readonly string endpoint = "http://127.0.0.1:10000";

    private static readonly string accountName = "devstoreaccount1";

    private static readonly string accountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";

    private static readonly string blobName = "TestBlob";

    public static async Task Main(string[] args)
    {
        BlobServiceClient client = new(
            new Uri($"{endpoint}/{accountName}"),
            new StorageSharedKeyCredential(accountName, accountKey)
        );

        BlobContainerClient bcc = await client.CreateBlobContainerAsync("sample-container");

        // Upload Blob
        BlobClient blobClient = bcc.GetBlobClient(blobName);
        string blobContents = "Sample blob data";

        await blobClient.UploadAsync(BinaryData.FromString(blobContents), overwrite: true);

        Console.WriteLine($"A blob with context {blobContents} has been uploaded");

        // Download Blob
        BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
        
        string downloadedBlobContents = downloadResult.Content.ToString();

        Console.WriteLine($"A blob with context {downloadedBlobContents} has been downloaded");

        // Delete Blob
        await blobClient.DeleteAsync();

        Console.WriteLine($"A blob has been deleted");
    }

}