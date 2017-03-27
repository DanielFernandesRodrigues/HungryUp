using Microsoft.AspNet.SignalR;

namespace HungryUp.Mvc.Helpers
{
    public class ScoreHub : Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ScoreHub>();

        public void Send(string message)
        {
            Clients.All.broadcastMessage(message);
        }

        public static void Static_Send(string scoreBoard)
        {
            hubContext.Clients.All.broadcastMessage(scoreBoard);
        }
    }
}