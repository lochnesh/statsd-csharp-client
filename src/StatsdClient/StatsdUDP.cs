using System;
using System.Linq;
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
            var ipAddress = entry.AddressList.First(x => x.AddressFamily != AddressFamily.InterNetworkV6);
            UDPSocket = new Socket(ipAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            IPEndpoint = new IPEndPoint(ipAddress,Port);
        }

        public void Send(string command)
        {
            byte[] encodedCommand = Encoding.ASCII.GetBytes(command +"\n");
            UDPSocket.SendTo(encodedCommand, encodedCommand.Length, SocketFlags.None, IPEndpoint);
        }

        public void Dispose()
        {
            UDPSocket.Close();
        }
    }
}