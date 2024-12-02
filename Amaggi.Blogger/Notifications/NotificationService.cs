using System.Net.WebSockets;
using System.Text;

namespace Amaggi.Blogger.Notifications
{
    public class NotificationService
    {
        private readonly List<WebSocket> _sockets = new();

        public async Task AddSocketAsync(WebSocket socket)
        {
            _sockets.Add(socket);
            await Task.CompletedTask;
        }

        public async Task NotifyAllAsync(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            foreach (var socket in _sockets)
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
