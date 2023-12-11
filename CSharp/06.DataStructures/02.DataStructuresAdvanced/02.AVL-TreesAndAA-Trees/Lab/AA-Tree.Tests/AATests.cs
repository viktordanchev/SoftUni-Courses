using System.Collections.Generic;
using NUnit.Framework;
using AA_Tree;

[TestFixture]
public class AATests
{

    private AATree<int> AATree;
    private int[] input = {
            18,
            13,
            1,
            7,
            42,
            73,
            56,
            24,
            6,
            2,
            74,
            69,
            55
        };

    [SetUp]
    public void Setup()
    {
        this.AATree = new AATree<int>();

        foreach (int element in input)
        {
            this.AATree.Insert(element);
        }
    }

    [Test]
    public void Count_MultipleElements_WorksCorrecty()
    {
        Assert.AreEqual(13, this.AATree.Count());
    }

    [Test]
    public void Count_EmptyTree_WorksCorrecty()
    {
        Assert.AreEqual(0, new AATree<int>().Count());
    }

    [Test]
    public void Contains_WithExistingElements_ShouldReturnTrue()
    {
        Assert.IsTrue(this.AATree.Contains(73));
    }

    [Test]
    public void Contains_WithNonExistingElements_ShouldReturnTrue()
    {
        Assert.IsFalse(this.AATree.Contains(78));
    }

    [Test]
    public void PreOrder_WithManyElements_ShouldWorkCorrectly()
    {
        List<int> actual = new List<int>();
        this.AATree.PreOrder(n => actual.Add(n));

        List<int> expected = new List<int>() { 13, 6, 1, 2, 7, 56, 42, 18, 24, 55, 73, 69, 74 };

        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void InOrder_WithManyElements_ShouldWorkCorrectly()
    {
        List<int> numbers = new List<int>();
        this.AATree.InOrder(n => numbers.Add(n));
        List<int> expected = new List<int>() { 1, 2, 6, 7, 13, 18, 24, 42, 55, 56, 69, 73, 74 };

        Assert.AreEqual(expected.Count, numbers.Count);
        CollectionAssert.AreEqual(expected, numbers);
    }

    [Test]
    public void PostOrder_WithManyElements_ShouldWorkCorrectly()
    {
        List<int> actual = new List<int>();
        this.AATree.PostOrder(n => actual.Add(n));

        List<int> expected = new List<int>() { 2, 1, 7, 6, 24, 18, 55, 42, 69, 74, 73, 56, 13 };

        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }
}