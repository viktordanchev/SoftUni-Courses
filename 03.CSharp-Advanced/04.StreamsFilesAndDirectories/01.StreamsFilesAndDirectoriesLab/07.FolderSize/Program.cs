using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (var fileInfo in infos)
            {
                sum += fileInfo.Length;
            }

            File.WriteAllText(outputFilePath, $"{sum / 2048} KB");
        }
    }
}