using Microsoft.AspNetCore.SignalR;
using MyCollectionSite.Models;

namespace MyCollectionSite;

public class VotingHub : Hub
{
	private readonly CollectionRepository _repository;

	public VotingHub(CollectionRepository repository)
	{
		_repository = repository;
	}

	public async Task SendVote(int collectionItemId, bool voteDirection)
	{
		System.Console.WriteLine("Receiving vote for " + collectionItemId);
		var newVoteTotal = _repository.Vote(collectionItemId, voteDirection);
		await Clients.All.SendAsync("ReceiveVote", collectionItemId, newVoteTotal);
		
	}

}