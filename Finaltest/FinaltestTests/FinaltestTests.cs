// <copyright file="FinaltestTests.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FinaltestTests;

using Finaltest;

/// <summary>
/// class of tests.
/// </summary>
public class Tests
{
    private class IntZeroChecker : IZeroChecker<int>
    {
        public bool IsNull(int element) => (int)element == 0;
    }

    private class StringZeroChecker : IZeroChecker<string>
    {
        public bool IsNull(string element)
        {
            return (string)element == string.Empty;
        }
    }

    private class DoubleZeroChecker : IZeroChecker<double>
    {
        public bool IsNull(double element)
        {
            return Math.Abs((double)element - 0) < 1e-7;
        }
    }

    /// <summary>
    ///  test method that count int zero elements.
    /// </summary>
    [Test]
    public void CountIntZeroElements()
    {
        List<int> list = [1, 2, 0, 6, 0];
        Assert.That(NullElements.CountZeroElements(list, new IntZeroChecker()), Is.EqualTo(2));
    }

    /// <summary>
    /// test method that count string zero elements.
    /// </summary>
    [Test]
    public void CountStringZeroElements()
    {
        var list = new List<string> { string.Empty, "sd", string.Empty, string.Empty, "ererter" };
        Assert.That(NullElements.CountZeroElements(list, new StringZeroChecker()), Is.EqualTo(3));
    }

    /// <summary>
    /// test method that count double zero elements.
    /// </summary>
    [Test]
    public void CountDoubleZeroElements()
    {
        var list = new List<double> { 1.1, 2.4, 5, 0 };
        Assert.That(NullElements.CountZeroElements(list, new DoubleZeroChecker()), Is.EqualTo(1));
    }

    /// <summary>
    /// test checks list to null.
    /// </summary>
    [Test]
    public void CheksNullList()
    {
        var list = new List<int> { };
        Assert.Throws<ArgumentNullException>(() => NullElements.CountZeroElements(list, new IntZeroChecker()));
    }
}