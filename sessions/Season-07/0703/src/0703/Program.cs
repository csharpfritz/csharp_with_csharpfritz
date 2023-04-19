// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var theClient = BlobDemos.GetBlobClient();
var folder = theClient.GetBlobContainerClient("MyFiles");
folder.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.None);

folder.UploadBlobAsync();

