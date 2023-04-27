using System.Net.NetworkInformation;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine($"IPv4 interface information for {properties.HostName} {properties.DomainName}");
            Console.WriteLine();

            foreach(NetworkInterface adapter in nics)
            {
                if(adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
                {
                    continue;
                }

                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();

                IPv4InterfaceProperties p = adapterProperties.GetIPv4Properties();

                if (p == null)
                {
                    Console.WriteLine("No IPv4 information is available for this interface.");
                    Console.WriteLine();
                    continue;
                }
                // Display the IPv4 specific data.
                Console.WriteLine("  Index ............................. : {0}", p.Index);
                Console.WriteLine("  MTU ............................... : {0}", p.Mtu);
                Console.WriteLine("  APIPA active....................... : {0}",
                    p.IsAutomaticPrivateAddressingActive);
                Console.WriteLine("  APIPA enabled...................... : {0}",
                    p.IsAutomaticPrivateAddressingEnabled);
                Console.WriteLine("  Forwarding enabled................. : {0}",
                    p.IsForwardingEnabled);
                Console.WriteLine("  Uses WINS ......................... : {0}",
                    p.UsesWins);
                Console.WriteLine();
            }
        }
    }
}