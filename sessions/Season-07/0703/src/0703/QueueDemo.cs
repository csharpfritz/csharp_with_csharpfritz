using Azure.Storage.Queues;

public static class QueueDemo
{

	public static QueueClient GetQueueClient(string queueName)
	{

		return new QueueClient("UseDevelopmentStorage=true", queueName);

	}

	public static void Demo()
	{

		// First, get a client 
		var theClient = QueueDemo.GetQueueClient("myqueue");

		// Create the queue
		theClient.CreateIfNotExists();

		// Add a message

		// encode the message Hello CSHarpfritz in base64 and send on the queue
		var theMessage = System.Convert.ToBase64String(
			System.Text.Encoding.UTF8.GetBytes("{Name: \"csharpfritz\", Message: \"Hello CSharpfritz\"}"));
		theClient.SendMessage(theMessage);
		
		// Get the message
		// var theMessage = theClient.ReceiveMessage();
		// System.Console.WriteLine(theMessage.Value.MessageText);

		// // Delete the message
		// theClient.DeleteMessage(theMessage.Value.MessageId, theMessage.Value.PopReceipt);

	}

	
}