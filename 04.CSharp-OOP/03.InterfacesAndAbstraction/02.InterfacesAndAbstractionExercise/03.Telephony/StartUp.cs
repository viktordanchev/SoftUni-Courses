using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            HashSet<string> websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    try
                    {
                        Smartphone smartphone = new();
                        smartphone.Calling(phoneNumber);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                else
                {
                    try
                    {
                        StationaryPhone stationaryPhone = new();
                        stationaryPhone.Dialing(phoneNumber);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
            }

            foreach (string website in websites) 
            {
                try
                {
                    Smartphone smartphone = new();
                    smartphone.Browsing(website);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
