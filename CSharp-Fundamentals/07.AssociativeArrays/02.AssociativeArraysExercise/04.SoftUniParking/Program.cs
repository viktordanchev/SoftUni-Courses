using System;
using System.Collections.Generic;

namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> userByLicensePlateNumber = new Dictionary<string, string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "register")
                {
                    string user = input[1];
                    string licensePlateNumber = input[2];

                    if (userByLicensePlateNumber.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        userByLicensePlateNumber.Add(user, licensePlateNumber);
                        Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                    }
                }
                else
                {
                    string user = input[1];
                    int counter = 0;

                    foreach (var item in userByLicensePlateNumber)
                    {
                        if (!userByLicensePlateNumber.ContainsKey(user))
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                            counter++;
                            break;
                        }
                    }

                    if (counter == 0)
                    {
                        userByLicensePlateNumber.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }

            foreach (var user in userByLicensePlateNumber)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}