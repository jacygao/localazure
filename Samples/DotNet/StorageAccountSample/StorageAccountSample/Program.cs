﻿using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;

internal class Program
{
    private static readonly string endpoint = "http://127.0.0.1:10000";

    private static readonly string accountName = "devstoreaccount1";

    private static readonly string accountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";

    public static async Task Main(string[] args)
    {
        BlobServiceClient client = new(
            new Uri($"{endpoint}/{accountName}"),
            new StorageSharedKeyCredential(accountName, accountKey)
        );

        BlobContainerClient bcc = await client.CreateBlobContainerAsync("sample-container");

    }
}