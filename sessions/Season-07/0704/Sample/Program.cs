global using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

//await SendMessages.Execute();
// await ReceiveMessages.Execute();

//await SendMessagesToTopic.Execute();
await ReceiveMessagesFromSubscription.Execute();

public static class Constants
{

	public const string ServiceBusConnectionString = "Endpoint=sb://csharpwithcsharpfritz.servicebus.windows.net/;SharedAccessKeyName=fritz-demo;SharedAccessKey=Sa9wk4LyXhS+nGWyxWI8BJhjk6zFcA0TG+ASbOySIvk=";
	public const string QueueName = "my-first-queue";
	public const string TopicName = "my-first-topic";
	public const string SubscriptionName = "subscription-1";

}
