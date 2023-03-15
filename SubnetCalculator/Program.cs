using System;

namespace SubnetCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la dirección IP:");
            string ipAddress = Console.ReadLine();
            Console.WriteLine("Ingrese la máscara de subred:");
            string subnetMask = Console.ReadLine();

            string[] ipOctets = ipAddress.Split('.');
            string[] subnetOctets = subnetMask.Split('.');

            int[] networkAddress = new int[4];
            int[] broadcastAddress = new int[4];

            for (int i = 0; i < 4; i++)
            {
                networkAddress[i] = int.Parse(ipOctets[i]) & int.Parse(subnetOctets[i]);
                broadcastAddress[i] = int.Parse(ipOctets[i]) | ~int.Parse(subnetOctets[i]) & 0xff;
            }

            Console.WriteLine($"Dirección de red: {string.Join(".", networkAddress)}");
            Console.WriteLine($"Dirección de broadcast: {string.Join(".", broadcastAddress)}");
        }
    }
}
