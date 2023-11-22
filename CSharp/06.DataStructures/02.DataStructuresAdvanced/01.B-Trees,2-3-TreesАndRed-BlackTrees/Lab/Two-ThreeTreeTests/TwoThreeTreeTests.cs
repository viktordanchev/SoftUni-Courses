using System;
using NUnit.Framework;
using _01.Two_Three;

public class TwoThreeTreeTests
{
    [Test]
    public void Insert_SingleElement()
    {
        var tree = new TwoThreeTree<string>();
        tree.Insert("13");

        Assert.AreEqual("13", tree.ToString().Trim());
    }

    [Test]
    public void Insert_FewElements()
    {
        var tree = new TwoThreeTree<string>();
        tree.Insert("A");
        tree.Insert("B");
        tree.Insert("C");
        Assert.AreEqual("B " + Environment.NewLine +
                        "A " + Environment.NewLine +
                        "C", tree.ToString().Trim());
    }

    [Test]
    public void Insert_LargeNumberOfElements()
    {
        var tree = new TwoThreeTree<string>();

        String[] arr = { "F", "C", "G", "A", "B", "D", "E", "K", "I", "G", "H", "J", "K" };
        for (int i = 0; i < 13; i++)
        {
            tree.Insert(arr[i]);
        }

        Assert.AreEqual("D G" + Environment.NewLine +
                        "B " + Environment.NewLine +
                        "A " + Environment.NewLine +
                        "C " + Environment.NewLine +
                        "F " + Environment.NewLine +
                        "E " + Environment.NewLine +
                        "G " + Environment.NewLine +
                        "I K" + Environment.NewLine +
                        "H " + Environment.NewLine +
                        "J " + Environment.NewLine +
                        "K", tree.ToString().Trim());
    }
}