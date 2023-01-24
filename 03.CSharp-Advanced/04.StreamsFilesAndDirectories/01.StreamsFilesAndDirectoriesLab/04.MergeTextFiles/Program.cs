using System;
using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> firstFile = new List<string>();
            List<string> secondFile = new List<string>();

            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                string row = firstReader.ReadLine();

                while (row != null)
                {
                    firstFile.Add(row);

                    row = firstReader.ReadLine();
                }
            }

            using (StreamReader secondReader = new StreamReader(secondInputFilePath))
            {
                string row = secondReader.ReadLine();

                while (row != null)
                {
                    secondFile.Add(row);

                    row = secondReader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int end = Math.Max(firstFile.Count, secondFile.Count);

                for (int i = 0; i < end; i++)
                {
                    if (firstFile.Count == 0)
                    {
                        writer.WriteLine(secondFile[0]);
                        secondFile.RemoveAt(0);
                    }
                    else if (secondFile.Count == 0)
                    {
                        writer.WriteLine(firstFile[0]);
                        firstFile.RemoveAt(0);
                    }
                    else
                    {
                        writer.WriteLine(firstFile[0]);
                        firstFile.RemoveAt(0);
                        writer.WriteLine(secondFile[0]);
                        secondFile.RemoveAt(0);
                    }
                }
            }
        }
    }
}