using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Grimoire.Networking
{
    public class GrimoireClient
    {
        public event Action Disconnected;

        public event Action<string> MessageReceived;

        private const int BufferSize = 1024;

        private readonly TcpClient _client;

        private readonly byte[] _readBuffer = new byte[BufferSize];

        private List<byte> _spillBuffer = new List<byte>();

        public GrimoireClient(TcpClient client)
        {
            _client = client;
        }

        public GrimoireClient(string address, int port)
        {
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse(address), port);
        }

        public void Start()
        {
            Read();
        }

        private void Read()
        {
            try
            {
                _client.GetStream().BeginRead(_readBuffer, 0, BufferSize, OnRead, null);
            }
            catch
            {
                Disconnect();
            }
        }

        public void Write(byte[] message)
        {
            try
            {
                _client.GetStream().BeginWrite(message, 0, message.Length, OnWrite, null);
            }
            catch
            {
                Disconnect();
            }
        }

        public void Write(string message)
        {
            if (message?.Length > 0)
            {
                if (message[message.Length - 1] != '\0')
                    message += "\0";
                Write(Encoding.UTF8.GetBytes(message));
            }
        }

        public async Task WriteTask(byte[] message)
        {
            try
            {
                await _client.GetStream().WriteAsync(message, 0, message.Length);
            }
            catch
            {
                Disconnect();
            }
        }

        public async Task WriteTask(string message)
        {
            if (message?.Length > 0)
            {
                if (message[message.Length - 1] != '\0')
                    message += "\0";
                await WriteTask(Encoding.UTF8.GetBytes(message));
            }
        }

        public void Disconnect()
        {
            try
            {
                _client.Close();
            }
            finally
            {
                Disconnected?.Invoke();
            }
        }

        private void OnRead(IAsyncResult result)
        {
            try
            {
                int read = _client.GetStream().EndRead(result);

                if (read == 0)
                {
                    Disconnect();
                    return;
                }

                int i = 0;

                while (--read >= 0)
                {
                    byte b = _readBuffer[i++];

                    if (b != 0x00)
                        _spillBuffer.Add(b);
                    else
                    {
                        string message = Encoding.UTF8.GetString(_spillBuffer.ToArray());
                        _spillBuffer = new List<byte>();
                        MessageReceived?.Invoke(message);
                    }
                }

                Read();
            }
            catch
            {
                Disconnect();
            }
        }

        private void OnWrite(IAsyncResult result)
        {
            try
            {
                _client.GetStream().EndWrite(result);
            }
            catch
            {
                Disconnect();
            }
        }
    }
}
