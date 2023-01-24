using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string[] words = wordsReader.ReadLine().Split();

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];

                    if (!wordCounts.ContainsKey(word))
                    {
                        wordCounts.Add(word, 0);
                    }
                }

                using (StreamReader lineReader = new StreamReader(textFilePath))
                {
                    string line = lineReader.ReadLine();

                    while (line != null)
                    {
                        line = line.ToLower();

                        foreach (var word in wordCounts)
                        {
                            if (line.Contains(word.Key))
                            {
                                wordCounts[word.Key]++;
                            }
                        }

                        line = lineReader.ReadLine();
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    wordCounts = wordCounts.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);

                    foreach (var word in wordCounts)
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}