using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

public class BlobDemos
{


    public static BlobServiceClient GetBlobClient()
    {

        string sas = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

        return new BlobServiceClient(sas);

    }

    public static void Demo()
    {

        // First, get a client 
        var theClient = BlobDemos.GetBlobClient();

        // Generate your own SAS URIs
        //theClient.GenerateAccountSasUri()

        // Allocate a container client - think of this as a folder
        var folder = theClient.GetBlobContainerClient("images");
        folder.CreateIfNotExists(PublicAccessType.Blob);

        // List contents
        var blobs = folder.GetBlobs();
				foreach (var blob in blobs)
				{
						System.Console.WriteLine(blob.Name);
				}


        // // Upload a file
				var ms = new MemoryStream();
				var sw = new StreamWriter(ms);
				sw.WriteLine("Hello, World!");
				sw.Flush();
				ms.Position = 0;
        folder.UploadBlob("myfile.txt", ms);

        // // Get files
        var theBlob = folder.GetBlobClient("myfile.txt");
        var myStream = new MemoryStream();
        theBlob.DownloadTo(myStream);
				myStream.Position = 0;
				var sr = new StreamReader(myStream);
				System.Console.WriteLine(sr.ReadToEnd());

    }

}