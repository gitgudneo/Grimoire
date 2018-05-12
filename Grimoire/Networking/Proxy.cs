using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Grimoire.Networking.Handlers;
using Grimoire.Tools;

namespace Grimoire.Networking
{
    public delegate void ReceiveEventHandler(Message message);

    public class Proxy
    {
        public static Proxy Instance { get; } = new Proxy();

        public event ReceiveEventHandler ReceivedFromClient;

        public event ReceiveEventHandler ReceivedFromServer;

        public int ListenerPort { get; set; }

        private GrimoireClient _client;

        private GrimoireClient _server;

        private TcpListener _listener;

        private readonly List<IJsonMessageHandler> _handlersJson = new List<IJsonMessageHandler>
        {
            new HandlerDropItem(),
            new HandlerGetQuests(),
            new HandlerQuestComplete(),
            new HandlerLoadShop()
        };

        private readonly List<IXtMessageHandler> _handlersXt = new List<IXtMessageHandler>();

        private readonly List<IXmlMessageHandler> _handlersXml = new List<IXmlMessageHandler>
        {
            new HandlerPolicy()
        };

        private Proxy()
        {
            ReceivedFromServer += ProcessMessage;
            ReceivedFromClient += ProcessMessage;
        }

        public void RegisterHandler(IJsonMessageHandler handler) => _handlersJson.Add(handler);

        public void RegisterHandler(IXmlMessageHandler handler) => _handlersXml.Add(handler);

        public void RegisterHandler(IXtMessageHandler handler) => _handlersXt.Add(handler);

        public void UnregisterHandler(IJsonMessageHandler handler) => _handlersJson.Remove(handler);

        public void UnregisterHandler(IXmlMessageHandler handler) => _handlersXml.Remove(handler);

        public void UnregisterHandler(IXtMessageHandler handler) => _handlersXt.Remove(handler);

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Loopback, ListenerPort);
            _listener.Start();
            _listener.BeginAcceptTcpClient(OnClientAccept, null);
        }

        public void Stop()
        {
            _listener.Stop();
            _server?.Disconnect();
            _client?.Disconnect();
        }

        private void OnClientAccept(IAsyncResult result)
        {
            if (_client != null)
            {
                _client.MessageReceived -= OnClientMessage;
                _client.Disconnect();
            }

            if (_server != null)
            {
                _server.MessageReceived -= OnServerMessage;
                _server.Disconnect();
            }

            try
            {
                _client = new GrimoireClient(_listener.EndAcceptTcpClient(result));
                _server = new GrimoireClient(Flash.Call<string>("RealAddress"), Flash.Call<int>("RealPort"));

                _client.MessageReceived += OnClientMessage;
                _server.MessageReceived += OnServerMessage;

                _client.Start();
                _server.Start();
            }
            finally
            {
                _listener.BeginAcceptTcpClient(OnClientAccept, null);
            }
        }

        private void OnClientMessage(string message)
        {
            Message msg = CreateMessage(message);

            ReceivedFromClient?.Invoke(msg);

            if (msg.Send)
                SendToServer(msg.ToString());
        }

        private void OnServerMessage(string message)
        {
            Message msg = CreateMessage(message);

            ReceivedFromServer?.Invoke(msg);

            if (msg.Send)
                SendToClient(msg.ToString());
        }

        private void ProcessMessage(Message message)
        {
            try
            {
                switch (message)
                {
                    case JsonMessage msgJson:
                        foreach (IJsonMessageHandler handler in _handlersJson.Where(h => h.HandledCommands.Contains(msgJson.Command)))
                            handler.Handle(msgJson);
                        break;
                    case XmlMessage msgXml:
                        foreach (IXmlMessageHandler handler in _handlersXml.Where(h => h.HandledCommands.Contains(msgXml.Command)))
                            handler.Handle(msgXml);
                        break;
                    case XtMessage msgXt:
                        foreach (IXtMessageHandler handler in _handlersXt.Where(h => h.HandledCommands.Contains(msgXt.Command)))
                            handler.Handle(msgXt);
                        break;
                }
            }
            catch
            {
            }
        }

        private Message CreateMessage(string raw)
        {
            if (raw?.Length > 0)
            {
                switch (raw[0])
                {
                    case '<': return new XmlMessage(raw);
                    case '%': return new XtMessage(raw);
                    case '{': return new JsonMessage(raw);
                }
            }

            return null;
        }

        public void SendToServer(string data) => _server.Write(data);

        public void SendToServer(byte[] data) => _server.Write(data);

        public async Task SendToServerTask(string data) => await _server.WriteTask(data);

        public async Task SendToServerTask(byte[] data) => await _server.WriteTask(data);

        public void SendToClient(string data) => _client.Write(data);

        public void SendToClient(byte[] data) => _client.Write(data);

        public async Task SendToClientTask(string data) => await _client.WriteTask(data);

        public async Task SendToClientTask(byte[] data) => await _client.WriteTask(data);
    }
}
