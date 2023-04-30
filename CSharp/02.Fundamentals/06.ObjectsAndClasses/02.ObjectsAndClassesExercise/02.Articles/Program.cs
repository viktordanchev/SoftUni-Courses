using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articles = Console.ReadLine().Split(", ");
            int numOfCommands = int.Parse(Console.ReadLine());
            Article article = new Article(articles[0], articles[1], articles[2]);

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    article.Edit(command);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command);
                }
                else
                {
                    article.Rename(command);
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string[] articles)
        {
            Content = articles[1];
        }

        public void ChangeAuthor(string[] articles) 
        {
            Author = articles[1];
        }

        public void Rename(string[] articles)
        {
            Title = articles[1];
        }
    }
}
