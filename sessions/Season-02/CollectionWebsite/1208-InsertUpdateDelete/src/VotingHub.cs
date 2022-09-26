using Microsoft.AspNetCore.SignalR;
using MyCollectionSite.Models;

namespace MyCollectionSite;

public class VotingHub : Hub
{
	private readonly ICollectionRepository _repository;

	public VotingHub(ICollectionRepository repository)
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