using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SmallTurnOnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input PC mac: ");
            var mac = Console.ReadLine();
            WakeOnLan(mac);
            Console.WriteLine("success");
            Console.ReadLine();
        }

        public static void WakeOnLan(string macAddress)
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

        private static byte[] TransformMac(string mac)
        {
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
