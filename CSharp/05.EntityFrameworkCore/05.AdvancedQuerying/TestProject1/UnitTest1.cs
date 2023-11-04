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
public class Test_002_000_001
{
    private IServiceProvider serviceProvider;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection()
            .AddDbContext<BookShopContext>(b =>
            {
                b.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });

        serviceProvider = services.BuildServiceProvider();
    }

    [Test]
    public void ValidateOutput()
    {
        var service = serviceProvider.GetService<BookShopContext>();
        DbInitializer.Seed(service);

        var assertService = serviceProvider.GetService<BookShopContext>();

        string input = "miNor";

        #region HardCoded Output
        string output = @"A Confederacy of Dunces
A Farewell to Arms
A Handful of Dust
A Monstrous Regiment of Women
A Summer Bird-Cage
After Many a Summer Dies the Swan
Ah
All the King's Men
Alone on a Wide
An Evil Cradling
Arms and the Man
Behold the Man
Blue Remembered Earth
Bonjour Tristesse
Butter In a Lordly Dish
By Grand Central Station I Sat Down and Wept
Carrion Comfort
Clouds of Witness
Consider the Lilies
Dance Dance Dance
Dominations
Dulce et Decorum Est
Everything is Illuminated
Fair Stood the Wind for France
Fame Is the Spur
Far From the Madding Crowd
Fear and Trembling
For a Breath I Tarry
For Whom the Bell Tolls
Gone with the Wind
Have His Carcase
How Sleep the Brave
I Sing the Body Electric
I Will Fear No Evil
If I Forget Thee Jerusalem
In a Glass Darkly
Jacob Have I Loved
Moab Is My Washpot
Mother Night
Nectar in a Sieve
No Country for Old Men
No Highway
No Longer at Ease
Of Human Bondage
Pale Kings and Princes
Precious Bane
Recalled to Life
Stranger in a Strange Land
Such
Surprised by Joy
Taming a Sea Horse
Tender Is the Night
The Golden Bowl
The Heart Is a Lonely Hunter
The Heart Is Deceitful Above All Things
The Last Temptation
The Lathe of Heaven
The Little Foxes
The Man Within
The Millstone
The Mirror Crack'd from Side to Side
The Moon by Night
The Moving Toyshop
The Skull Beneath the Skin
The Stars' Tennis Balls
The Sun Also Rises
The Violent Bear It Away
The Way Through the Woods
Those Barren Leaves
Thrones
Unweaving the Rainbow
Vile Bodies";
        #endregion

        string result = StartUp.GetBooksByAgeRestriction(assertService, input).Trim();

        Assert.AreEqual(output, result, "Returned value is incorrect!");
    }
}