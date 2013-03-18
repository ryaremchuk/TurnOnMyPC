using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace TurnOnMyPCProcessing.Services
{
    public class RemotePCManager
    {
        public bool IsTurnedOn(string computerName)
        {
            try
            {
                var ping = new Ping();
                var reply = ping.Send(computerName, 200);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }

        public void WakeOnLan(string macAddress)
        {
            var macAddressBytes = TransformMac(macAddress);

            var packet = new List<byte>();

            for (var i = 0; i < 6; i++)
                packet.Add(0xFF);

            for (var i = 0; i < 16; i++)
                packet.AddRange(macAddressBytes);

            var client = new UdpClient();
            //note: 7 this is random port number. this is doesn't matter
            client.Connect(IPAddress.Broadcast, 7);
            client.Send(packet.ToArray(), packet.Count);
        }

        private byte[] TransformMac(string mac)
        {
            mac = mac.Replace("-", "");
            var value = long.Parse(mac, NumberStyles.HexNumber, CultureInfo.CurrentCulture.NumberFormat);
            var macBytes = BitConverter.GetBytes(value);

            Array.Reverse(macBytes);
            var macAddress = new byte[6];
            for (var i = 0; i <= 5; i++)
                macAddress[i] = macBytes[i + 2];

            return macAddress;
        }
    }
}