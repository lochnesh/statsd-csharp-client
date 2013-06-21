using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StatsdClient
{
    public class StatsdUDP : IDisposable, IStatsdUDP
    {
        private IPEndPoint IPEndpoint { get; set; }
        private Socket UDPSocket { get; set; }
        private string Name { get; set; }
        private int Port { get; set; }

        public StatsdUDP(string name, int port)
        {
            Name = name;
            Port = port;
            
            
            IPHostEntry entry = Dns.GetHostEntry(Name);
            IPAddress ipa = entry.AddressList[0];
            UDPSocket = new Socket(ipa.AddressFamily, SocketType.Dgram, ProtocolType.Udp);            
            IPEndpoint = new IPEndPoint(entry.AddressList[0],Port);
        }

        public void Send(string command)
        {
            byte[] encodedCommand = Encoding.ASCII.GetBytes(command);
            UDPSocket.SendTo(encodedCommand, encodedCommand.Length, SocketFlags.None, IPEndpoint);
        }

        public void Dispose()
        {
            UDPSocket.Close();
        }
    }
}