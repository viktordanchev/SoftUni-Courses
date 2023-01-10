using System;
using System.Text;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int lastIndex = path.LastIndexOf('\\');

            StringBuilder fileName = new StringBuilder();
            StringBuilder extension = new StringBuilder();
            for (int i = lastIndex + 1; i < path.Length; i++)
            {
                if (path[i] == '.')
                {
                    for (int j = i + 1; j < path.Length; j++)
                    {
                        extension.Append(path[j]);
                    }

                    break;
                }

                fileName.Append(path[i]);
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}