using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace _03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numOfArticles; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                Article article = new Article(command[0], command[1], command[2]);
                articles.Add(article);
            }

            foreach (Article article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
