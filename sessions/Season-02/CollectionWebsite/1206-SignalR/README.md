# Session 1206: SignalR and Live Data

We're building on the previous state of our application by adding a live interaction with our content using SignalR.

## Agenda

1. Introduce [SignalR](https://docs.microsoft.com/aspnet/core/signalr/introduction) - an abstraction over server-push technologies
1. Add "Upvote and Downvote" buttons to items in the collection
1. Add `VotingHub` and SignalR to our application
1. Add JavaScript client to allow voting and publish updates immediately
1. Discuss scaling SignalR with backplanes 

Note: we will connect authentication and validation to the voting in our session about security