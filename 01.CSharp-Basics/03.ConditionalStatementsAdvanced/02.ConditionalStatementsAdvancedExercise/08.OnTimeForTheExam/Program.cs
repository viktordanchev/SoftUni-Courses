using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());


            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            examMin = examMin + examHour * 60;
            arrivalMin = arrivalMin + arrivalHour * 60;

            int difference = Math.Abs(arrivalMin - examMin);

            int diffHour = difference / 60;
            int diffMin = difference % 60;

            if (examMin < arrivalMin)
            {
                Console.WriteLine("Late");

                if (diffHour >= 1)
                {
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes after the start");
                }
            }
            else if (examMin - arrivalMin <= 30)
            {
                Console.WriteLine("On time");

                if (examMin != arrivalMin)
                {

                    Console.WriteLine($"{difference} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");

                if (diffHour >= 1)
                {
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes before the start");
                }
            }
        }
    }
}
