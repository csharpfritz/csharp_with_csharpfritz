// See https://aka.ms/new-console-template for more information
using Azure.Storage.Blobs;

public class BlobDemos
{


    public static BlobServiceClient GetBlobClient()
    {

        string sas = "BlobEndpoint=https://hatcollection.blob.core.windows.net/;QueueEndpoint=https://hatcollection.queue.core.windows.net/;FileEndpoint=https://hatcollection.file.core.windows.net/;TableEndpoint=https://hatcollection.table.core.windows.net/;SharedAccessSignature=sv=2021-12-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2023-04-19T19:37:30Z&st=2023-04-19T11:37:30Z&spr=https&sig=wijFLCwFPv6zgeU30F88Q%2Bn7pvYWnSm05tcirmJiN%2BI%3D";

        return new BlobServiceClient(sas);

    }

    public static void Demo()
    {

        // First, get a client 
        var theClient = BlobDemos.GetBlobClient();

        // Generate your own SAS URIs
        theClient.GenerateAccountSasUri();

        // Allocate a container client - think of this as a folder
        var folder = theClient.GetBlobContainerClient("MyFiles");
        folder.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.None);

        // List contents
        folder.GetBlobs();

        // Upload a file
        folder.UploadBlobAsync();

        // Get files
        var theBlob = folder.GetBlobClient("myfile");
        var myStream = new MemoryStream();
        theBlob.DownloadToAsync(myStream);

    }

}