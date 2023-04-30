using System;

namespace _04.PersonalTitles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            switch (gender)
            {
                case 'm':
                    if (age >= 16)  
                    {
                        Console.WriteLine("Mr.");
                    }
                    else
                    {
                        Console.WriteLine("Master");
                    }
                    break;
                case 'f':
                    if (age >= 16)
                    {
                        Console.WriteLine("Ms.");
                    }
                    else
                    {
                        Console.WriteLine("Miss");
                    }
                    break;
            }
        }
    }
}
