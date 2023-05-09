# Session 0704 - Azure Service Bus with .NET

[Azure Service Bus](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview) is a fully managed enterprise message broker with message queues and publish-subscribe topics (in a namespace). Service Bus is used to decouple applications and services from each other, providing the following benefits:

- Load-balancing work across competing workers
- Safely routing and transferring data and control across service and application boundaries
- Coordinating transactional work that requires a high-degree of reliability

The service bus gives us the following features that allow us to deliver these benefits:

- **Queues** that deliver first-in first-out operations
- **Topics and Subscriptions** that allow one-to-many relationships between publishers and subscribers, allowing subscribers to select messages from a message stream
- **Transactions** that provide for multiple operations within the scope of a single atomic transation.  You could:
  1. Read a message from a queue and act on it
  2. Post the results to a different queue
  3. Remove the original message from its queue

There are size limitations and message quotas on Service bus that you will be required to abide by:

https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quotas

## Queues

![Queue Processing model](https://learn.microsoft.com/en-us/azure/service-bus-messaging/media/service-bus-messaging-overview/about-service-bus-queue.png)

Queues are useful for delayed and point-to-point communications

A comparison of Storage Queues to Service Bus queues:  https://learn.microsoft.com/azure/service-bus-messaging/service-bus-azure-and-service-bus-queues-compared-contrasted

## Topics and Subscriptions

![Topic processing model](https://learn.microsoft.com/en-us/azure/service-bus-messaging/media/service-bus-messaging-overview/about-service-bus-topic.png)

Subscriptions can receive a subset of messages using [Filtering](https://learn.microsoft.com/azure/service-bus-messaging/topic-filters)