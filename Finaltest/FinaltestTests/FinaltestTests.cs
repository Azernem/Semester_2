// <copyright file="FinaltestTests.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FinaltestTests;

using Finaltest;

public class Tests
{
    private class IntZeroChecker : IZeroChecker<int>
    {
        public bool IsNull(int element)
        {
            return (int)element == 0;
        }
    }

    private class StringZeroChecker : IZeroChecker<string>
    {
        public bool IsNull(string element)
        {
            return (string)element == string.Empty;
        }
    }

    [Test]
    public void CountIntZeroElements()
    {
        var list = new List<int> {1, 2, 0, 6, 0 };
        Assert.That(NullElements.CountZeroElements(list, new IntZeroChecker()), Is.EqualTo(2));
    }

    [Test]
    public void CountStringZeroElements()
    {
        var list = new List<string> { string.Empty, "sd", string.Empty , string.Empty, "ererter" };
        Assert.That(NullElements.CountZeroElements(list, new StringZeroChecker()), Is.EqualTo(3));
    }
}