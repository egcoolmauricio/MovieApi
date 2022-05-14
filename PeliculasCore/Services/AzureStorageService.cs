using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class AzureStorageService : IFileStorageService
    {
        private readonly string connectionString;

        public AzureStorageService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("AzureStorage");
        }
        public async Task<string> Save(byte[] data, string extension, string container, string contentType)
        {
            var client = new BlobContainerClient(connectionString, container);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);

            var fileName = $"{Guid.NewGuid()}.{extension}";
            var blob = client.GetBlobClient(fileName);
            var blobUploadOptions = new BlobUploadOptions();
            var blobHttpHeader = new BlobHttpHeaders();
            blobHttpHeader.ContentType = contentType;
            blobUploadOptions.HttpHeaders = blobHttpHeader;

            await blob.UploadAsync(new BinaryData(data), blobUploadOptions);
            return blob.Uri.ToString();
        }
        public async Task Delete(string path, string container)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            var blobContainer = new BlobContainerClient(connectionString, container);
            await blobContainer.CreateIfNotExistsAsync();
            var file = Path.GetFileName(path);
            var blobClient = blobContainer.GetBlobClient(file);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> Edit(byte[] data, string extension, string container, string contentType, string path)
        {
           await Delete(path, container);
           return await Save(data, extension, contentType, path);
        }

        
    }
}
