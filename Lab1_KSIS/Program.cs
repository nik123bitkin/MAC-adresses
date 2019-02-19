using System;
using System.Net.NetworkInformation;

namespace Lab1_KSIS
{
    class Program
    {
        public static void ShowNetworkInterfaces()
        {
            //get local computer information(name, domain etc);
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            //returns array of all computer network interfaces
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            //print name and domain, if possible
            Console.WriteLine("Computer name: {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            //if no interfaces found
            if (interfaces == null || interfaces.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            //for every interface display data
            foreach (NetworkInterface adapter in interfaces)
            {
                //IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                Console.WriteLine();
                Console.WriteLine("Device: {0}", adapter.Description);
                
                Console.WriteLine("  Interface type      : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Device state        : {0}", adapter.OperationalStatus);
                Console.WriteLine("  Device id           : {0}", adapter.Id);
                Console.WriteLine("  Adapter's name      : {0}", adapter.Name);
                Console.Write("  MAC-address         : ");
                //convert mac-address to readable format
                //using class representation
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    if (i != bytes.Length - 1)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
                
            }
            Console.WriteLine();
            Console.WriteLine("Number of interfaces is {0}", interfaces.Length);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            ShowNetworkInterfaces();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Finish...");
        }
    }
}
