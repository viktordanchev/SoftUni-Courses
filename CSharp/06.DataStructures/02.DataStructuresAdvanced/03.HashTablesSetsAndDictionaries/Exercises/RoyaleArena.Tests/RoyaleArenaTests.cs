using System;
using System.Collections.Generic;
using NUnit.Framework;
using RoyaleArena;

[TestFixture]
public class RoyaleArenaTests
{
    [Test]
    public void Add_SingleElement_ShouldWorkCorrectly()
    {
        IArena RA = new Arena();
        BattleCard cd = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
        RA.Add(cd);

        //Assert
        foreach (var bc in RA)
        {
            Assert.AreEqual(bc, cd);
        }
    }

    [Test]
    public void Add_SingleElement_ShouldIncreaseCountToOne()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
        //Act
        RA.Add(cd);

        //Assert
        foreach (var battleCard in RA)
        {
            Assert.AreEqual(battleCard, cd);
        }

        Assert.AreEqual(1, RA.Count);
    }

    [Test]
    public void Add_MultipleElements_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 5, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 5, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);

        //Assert
        Assert.IsTrue(RA.Contains(cd1));
        Assert.IsTrue(RA.Contains(cd2));
        Assert.IsTrue(RA.Contains(cd3));
    }

    [Test]
    public void Contains_OnExistingElement_ShouldReturnTrue()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 6, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 7, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 8, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        //Assert

        Assert.True(RA.Contains(cd1));
        Assert.False(RA.Contains(new BattleCard(3, CardType.BUILDING, "ta", 6, 52.2)));
        Assert.True(RA.Contains(cd2));
        Assert.False(RA.Contains(new BattleCard(0, CardType.RANGED, "b", 7, 5)));
    }

    [Test]
    public void Count_MultipleElements_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 3, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 8, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 9, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);

        //Assert
        Assert.AreEqual(3, RA.Count);
    }

    [Test]
    public void GetById_OnExistingElement_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 10, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 10, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);

        //Assert
        Assert.AreEqual(cd1, RA.GetById(5));
        Assert.AreNotEqual(
            new BattleCard(53, CardType.RANGED, "a", 10, 5),
            RA.GetById(7)
        );
    }

    [Test]
    public void ChangeCardType_OnExistingCard_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 10, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 10, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        RA.ChangeCardType(5, CardType.MELEE);

        //Assert
        Assert.AreEqual(CardType.MELEE, cd1.Type);
        Assert.AreEqual(3, RA.Count);
    }

    [Test]
    public void GetEnumerator_ShowWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 6, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 7, 5);
        List<BattleCard> expected = new List<BattleCard>() { cd1, cd3, cd2 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);

        List<BattleCard> actual = new List<BattleCard>();

        foreach (BattleCard battlecard in RA)
        {
            actual.Add(battlecard);
        }

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetEnumerator_AfterDelete_ShouldReturnBattlecardsInCorrectOrder()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 11, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 12, 5);
        List<BattleCard> expected = new List<BattleCard>() { cd2 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.RemoveById(5);
        RA.RemoveById(7);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (BattleCard battlecard in RA)
        {
            actual.Add(battlecard);
        }

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetInSwagRange_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "dragon", 8, 1);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "raa", 7, 2);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "maga", 6, 5.5);
        BattleCard cd4 = new BattleCard(12, CardType.SPELL, "shuba", 5, 15.6);
        BattleCard cd5 = new BattleCard(15, CardType.SPELL, "tanuki", 5, 7.8);
        List<BattleCard> expected = new List<BattleCard>() { cd5, cd4 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        IEnumerable<BattleCard> battlecards = RA.GetAllInSwagRange(7, 16);
        List<BattleCard> actual = new List<BattleCard>();

        foreach (var b in battlecards)
        {
            actual.Add(b);
        }

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void FindFirstLeastSwag_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 6.0, 1.0);
        BattleCard cd2 = new BattleCard(6, CardType.MELEE, "joro", 7.0, 5.5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 11.0, 5.5);
        BattleCard cd4 = new BattleCard(12, CardType.BUILDING, "joro", 12.0, 15.6);
        BattleCard cd5 = new BattleCard(15, CardType.BUILDING, "moro", 13.0, 7.8);
        List<BattleCard> expected = new List<BattleCard>() { cd1, cd2, cd3, cd5 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        IEnumerable<BattleCard> battlecards = RA.FindFirstLeastSwag(4);

        List<BattleCard> actual = new List<BattleCard>();
        foreach (var b in battlecards)
        {
            actual.Add(b);
        }

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByTypeAndDamageRangeOrderedByDamageThenById_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 1, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 5.5, 6);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 5.5, 7);
        BattleCard cd4 = new BattleCard(12, CardType.SPELL, "joro", 15.6, 10);
        BattleCard cd5 = new BattleCard(15, CardType.RANGED, "joro", 7.8, 6);
        List<BattleCard> expected = new List<BattleCard>() { cd4, cd2, cd3, cd1 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        IEnumerable<BattleCard> battlecards = RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.SPELL, 0, 20);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var b in battlecards)
        {
            actual.Add(b);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByNameOrderedBySwagDescending_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 5, 1);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "joro", 6, 1);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "joro", 7, 15.6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "joro", 8, 15.6);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "joro", 11, 17.8);
        List<BattleCard> expected = new List<BattleCard>() { cd5, cd4, cd3, cd2, cd1 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        IEnumerable<BattleCard> joro = RA.GetByNameOrderedBySwagDescending("joro");
        List<BattleCard> actual = new List<BattleCard>();

        foreach (var item in joro)
        {
            actual.Add(item);
        }
        CollectionAssert.AreEquivalent(expected, actual);
    }


    [Test]
    public void GetByCardTypeAndMaximumDamage_FewElements_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 1, 5);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 14.8, 6);
        BattleCard cd3 = new BattleCard(3, CardType.SPELL, "valq", 15.6, 12);
        BattleCard cd4 = new BattleCard(4, CardType.SPELL, "valq", 15.6, 61);
        BattleCard cd5 = new BattleCard(8, CardType.SPELL, "valq", 17.8, 13);
        List<BattleCard> expected = new List<BattleCard>() { cd3, cd4, cd2, cd1 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        IEnumerable<BattleCard> battlecards = RA.GetByCardTypeAndMaximumDamage(CardType.SPELL, 15.6);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var item in battlecards)
        {
            actual.Add(item);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByCardType_AfterRemove_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 2, 14.8);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 2, 14.8);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 4, 15.6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 3, 15.6);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 8, 17.8);
        List<BattleCard> expected = new List<BattleCard>() { cd3, cd2, cd1 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(8);
        RA.RemoveById(3);

        //Assert
        IEnumerable<BattleCard> battlecards = RA.GetByCardType(CardType.SPELL);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var item in battlecards)
        {
            actual.Add(item);
        }
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void Contains_OnEmptyArena_ShouldReturnFalse()
    {
        //Arrange
        IArena RA = new Arena();

        //Act

        //Assert
        Assert.AreEqual(0, RA.Count);
        Assert.IsFalse(RA.Contains(new BattleCard(5, CardType.BUILDING, "test", 5, 6.2)));
        Assert.IsFalse(RA.Contains(new BattleCard(3, CardType.RANGED, "a", 6, 0.5)));
    }

    [Test]
    public void Count_OnEmptyCollection_ShouldBeZero()
    {
        //Arrange
        IArena RA = new Arena();

        //Act

        //Assert
        Assert.AreEqual(0, RA.Count);
        RA.Add(new BattleCard(3, CardType.RANGED, "a", 6, 0.5));
        Assert.AreEqual(1, RA.Count);
    }

    [Test]
    public void Count_AfterRemove_ShouldRemainCorrect()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 10, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 10, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        RA.RemoveById(cd1.Id);
        RA.RemoveById(cd3.Id);

        //Assert
        Assert.AreEqual(1, RA.Count);
        Assert.AreNotEqual(cd1, RA.GetById(cd2.Id));
    }

    [Test]
    public void GetById_OnNonExistingElement_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 10, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 10, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        RA.RemoveById(5);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetById(5);
        });
    }



    [Test]
    public void ChangeCardType_OnMultipleBattleCards_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 6, 5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 7, 5);

        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        RA.ChangeCardType(7, CardType.BUILDING);
        RA.ChangeCardType(5, CardType.MELEE);
        RA.ChangeCardType(6, CardType.SPELL);

        //Assert
        Assert.AreEqual(3, RA.Count);
        Assert.AreEqual(cd1.Type, CardType.MELEE);
        Assert.AreEqual(cd3.Type, CardType.BUILDING);
        Assert.AreEqual(cd2.Type, CardType.SPELL);
    }

    [Test]
    public void ChangeCardType_OnNonExistingType_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();

        //Act

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.ChangeCardType(6, CardType.RANGED);
        });
    }

    [Test]
    public void GetAllInSwagRange_OnNonExistingRange_ShouldReturnEmptyCollection()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 2, 1);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 3, 2);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 4, 5.5);
        BattleCard cd4 = new BattleCard(12, CardType.SPELL, "joro", 5, 15.6);
        BattleCard cd5 = new BattleCard(15, CardType.SPELL, "joro", 6, 7.8);
        List<BattleCard> expected = new List<BattleCard>();

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        IEnumerable<BattleCard> BattleCards = RA.GetAllInSwagRange(7.7, 7.75);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }

        //Assert
        Assert.AreEqual(expected, actual);
        RA.RemoveById(12);
        RA.RemoveById(15);
        IEnumerable<BattleCard> BattleCards1 = RA.GetAllInSwagRange(7.8, 16);
        actual.Clear();
        foreach (var card in BattleCards1)
        {
            actual.Add(card);
        }
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetAllInSwagRange_OnEmptyArena_ShouldReturnEmptyCollection()
    {
        //Arrange
        IArena RA = new Arena();

        //Act
        IEnumerable<BattleCard> BattleCards = RA.GetAllInSwagRange(7.7, 7.75);
        List<BattleCard> actual = new List<BattleCard>();

        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }

        //Assert
        Assert.AreEqual(new List<BattleCard>(), actual);
    }

    [Test]
    public void FindFirstLeastSwag_OnNonExistingCards_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 5, 1);
        BattleCard cd2 = new BattleCard(6, CardType.MELEE, "joro", 5, 5.5);
        BattleCard cd3 = new BattleCard(7, CardType.MELEE, "joro", 10, 5.5);
        BattleCard cd4 = new BattleCard(12, CardType.RANGED, "joro", 11, 15.6);
        BattleCard cd5 = new BattleCard(15, CardType.SPELL, "joro", 16, 7.8);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.FindFirstLeastSwag(150);
        });
    }

    [Test]
    public void FindFirstLeastSwag_AfterRemove_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 5, 1);
        BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 6, 5.5);
        BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 7, 5.5);
        BattleCard cd4 = new BattleCard(12, CardType.SPELL, "joro", 8, 15.6);
        BattleCard cd5 = new BattleCard(15, CardType.RANGED, "joro", 12, 7.8);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(5);
        RA.RemoveById(7);
        RA.RemoveById(6);
        RA.RemoveById(12);
        RA.RemoveById(15);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.FindFirstLeastSwag(1);
        });
    }

    [Test]
    public void GetByTypeAndDamageRange_WithFewElements_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 1, 5);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "joro", 1, 100);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "joro", 15.6, 53);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "joro", 15.6, 100);
        BattleCard cd5 = new BattleCard(8, CardType.SPELL, "joro", 17.8, 102);
        List<BattleCard> expected = new List<BattleCard> { cd5, cd4, cd3, cd2, cd1 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        IEnumerable<BattleCard> BattleCards = RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.SPELL, 0, 20);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByTypeAndDamageRangeOrderedByDamageThenById_AfterRemove_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 1, 5);
        BattleCard cd2 = new BattleCard(6, CardType.RANGED, "joro", 5.5, 5);
        BattleCard cd3 = new BattleCard(7, CardType.MELEE, "joro", 5.5, 10);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.RemoveById(5);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.SPELL, 0, 20);
        });
    }

    [Test]
    public void GetByTypeAndDamageRangeOrderedByDamageThenById_OnEmptyArena_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.MELEE, 0, 20);
        });
    }

    [Test]
    public void GetByNameOrderedBySwagDescending_WithNonExistingName_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "pesho", 53, 1);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "mesho", 5, 1);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "kalin", 6, 15.6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "peshor", 6, 15.6);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "barko", 7, 17.8);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByNameOrderedBySwagDescending("mecho");
        });
    }

    [Test]
    public void GetByNameOrderedBySwagDescending_OnEmptyArena_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();

        //Act

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByNameOrderedBySwagDescending("pesho");
        });

    }

    [Test]
    public void GetByCardTypeAndMaximumDamage_OnNonExistingType_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 5, 1);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 5, 14.8);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 13, 15.6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 6, 15.6);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 123, 17.8);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByCardTypeAndMaximumDamage(CardType.MELEE, 15.5);
        });
    }

    [Test]
    public void GetByCardTypeAndMaximumDamage_ShouldOrderAndPickCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 1, 6);
        BattleCard cd2 = new BattleCard(1, CardType.RANGED, "valq", 14.8, 7);
        BattleCard cd3 = new BattleCard(4, CardType.RANGED, "valq", 15.6, 6);
        BattleCard cd4 = new BattleCard(3, CardType.RANGED, "valq", 15.6, 12);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 17.8, 63);

        List<BattleCard> expected = new List<BattleCard> { cd3, cd2 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(8);
        RA.RemoveById(3);

        //Assert
        IEnumerable<BattleCard> BattleCards = RA.GetByCardTypeAndMaximumDamage(CardType.RANGED, 15.6);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByCardTypeAndMaximumDamage_OnEmptyArena_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        //Act

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByCardTypeAndMaximumDamage(CardType.MELEE, 5);
        });

    }

    [Test]
    public void GetByCardType_WithFewElements_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 6, 14.8);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 6, 14.8);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 7, 15.6);
        BattleCard cd4 = new BattleCard(3, CardType.RANGED, "valq", 8, 15.6);
        BattleCard cd5 = new BattleCard(8, CardType.SPELL, "valq", 9, 17.8);
        List<BattleCard> expected = new List<BattleCard> { cd5, cd3, cd2, cd1 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        IEnumerable<BattleCard> BattleCards = RA.GetByCardType(CardType.SPELL);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByNonExistingCardType_ShouldThrow()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 5, 14.8);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 5, 14.8);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 6, 15.6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 7, 15.6);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 8, 17.8);
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert

        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByCardType(CardType.BUILDING);
        });
    }

    [Test]
    public void GetByCardTypeAndMaximumDamage_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 14, 5);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 14, 5);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 15, 6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 15, 7);
        BattleCard cd5 = new BattleCard(8, CardType.SPELL, "valq", 18, 8);
        List<BattleCard> expected = new List<BattleCard> { cd4, cd3, cd2, cd1 };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        IEnumerable<BattleCard> BattleCards = RA.GetByCardTypeAndMaximumDamage(CardType.SPELL, 17);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByCardTypeAndMaximumDamage_AfterRemove_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 14.8, 53);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 14.8, 5);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 15.6, 6);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 15.6, 12);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 17.8, 613);
        List<BattleCard> expected = new List<BattleCard> { cd2 };

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(cd1.Id);

        //Assert
        IEnumerable<BattleCard> BattleCards = RA.GetByCardTypeAndMaximumDamage(CardType.SPELL, 15.0);
        List<BattleCard> actual = new List<BattleCard>();
        foreach (var card in BattleCards)
        {
            actual.Add(card);
        }
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetByCardTypeAndMaximumDamage_ShouldThrow_OnEmptyCollection()
    {
        //Arrange
        IArena RA = new Arena();
        BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 14.8, 6);
        BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 14.8, 7);
        BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 15.6, 8);
        BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 15.6, 9);
        BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 17.8, 10);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByCardTypeAndMaximumDamage(CardType.BUILDING, 5);
        });
    }
}