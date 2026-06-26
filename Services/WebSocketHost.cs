using Fleck;
using System;
using System.Collections.Generic;
using System.Timers;

namespace scalecloud_scale_agent.Services
{
    public class WebSocketHost
    {
        private WebSocketServer _server;

        private readonly List<IWebSocketConnection>
            _clients = new List<IWebSocketConnection>();

        private Timer _timer;

        public void Start()
        {
            FleckLog.Level = LogLevel.Warn;

            _server =
                new WebSocketServer(
                    "ws://127.0.0.1:47895");

            _server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    lock (_clients)
                    {
                        _clients.Add(socket);
                    }
                };

                socket.OnClose = () =>
                {
                    lock (_clients)
                    {
                        _clients.Remove(socket);
                    }
                };
            });

            _timer = new Timer(100);

            _timer.Elapsed += (s, e) =>
            {
                BroadcastWeight();
            };

            _timer.Start();
        }

        private void BroadcastWeight()
        {

            string json =
                   "{\"weight1\":12345" +","+"\"weight2\":67890"+"}";

            lock (_clients)
            {
                foreach (var client in _clients)
                {
                    if (client.IsAvailable)
                    {
                        client.Send(json);
                    }
                }
            }
        }

        public void Stop()
        {
            _timer?.Stop();

            lock (_clients)
            {
                foreach (var client in _clients)
                {
                    client.Close();
                }
            }
        }
    }
}
