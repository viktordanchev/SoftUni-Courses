using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using BookShop;
using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models;
using BookShop.Models.Enums;

[TestFixture]
public class Test_006_000_001
{
    private IServiceProvider serviceProvider;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<BookShopContext>()
            .UseInMemoryDatabase(databaseName: "BookShop")
            .Options;

        var services = new ServiceCollection()
            .AddDbContext<BookShopContext>(b => b.UseInMemoryDatabase("BookShop"));

        serviceProvider = services.BuildServiceProvider();
    }

    [Test]
    public void ValidateOutput()
    {
        var service = serviceProvider.GetService<BookShopContext>();
        DbInitializer.Seed(service);

        var assertService = serviceProvider.GetService<BookShopContext>();

        string input = "horror mystery drama";

        string result = StartUp.GetBooksByCategory(assertService, input).Trim();

        Assert.AreEqual(611, result.Length, "Returned value is incorrect!");
    }
}