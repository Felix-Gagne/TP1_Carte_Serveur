using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Controllers;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace Super_Cartes_Infinies.Hubs
{
    [Authorize]
    public class MatchHub : Hub
    {
        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

        ApplicationDbContext _context;

        MatchesService _matchService;

        public MatchHub(ApplicationDbContext context, MatchesService matchService)
        {
            _context = context;
            _matchService = matchService;
        }
        
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            await Clients.All.SendAsync("UserCount", UserHandler.ConnectedIds.Count);
            await Clients.Caller.SendAsync("TaskList", _context.MatchTasks.ToList());
        }

        public async Task JoinMatch()
        {
            var UserId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            JoiningMatchData result = await _matchService.JoinMatch(UserId);

            if (result != null)
            {
                await Clients.User(UserId).SendAsync("ReceiveJoinMatchValue", result);

                var start = await _matchService.StartMatch(UserId, result.Match.Id);
            }
        }

        public async Task CancelQueue()
        {
            await _matchService.CancelQueue();
        }

        public async Task PlayCard(int matchId, int playableCardId)
        {
            var UserId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var events = await _matchService.PlayCard(UserId, matchId, playableCardId);
        }

        public async Task Surrender(int matchId)
        {
            var UserId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _matchService.Surrender(matchId, UserId);
        }

        public async Task EndTurn(int matchId)
        {
            var UserId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var events = await _matchService.EndTurn(UserId, matchId);
        }

    }
}
