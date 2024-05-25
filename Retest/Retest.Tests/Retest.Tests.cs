// <copyright file="Retest.Tests.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Retest.Tests;
using Retest;

/// <summary>
/// class of tests.
/// </summary>
public class Tests
{
    /// <summary>
    /// test method about words with repitition.
    /// </summary>
    [Test]
    public void TestWordWithRepetition()
    {
        var word = "banana";
        var encodedSequence = new int[] { 1, 1, 13, 1, 1, 1 };
        Assert.That(MoveToFront.Encode(word), Is.EqualTo(encodedSequence));
    }

    /// <summary>
    /// test method about words with big distanse between letters at alphabet.
    /// </summary>
    [Test]
    public void TestBigDistanse()
    {
        var word = "azazazaza";
        var encodedSequence = new int[] { 0, 25, 1, 1, 1, 1, 1, 1, 1 };
        Assert.That(MoveToFront.Encode(word), Is.EqualTo(encodedSequence));
    }

    /// <summary>
    /// method that checks word to alphabet letters.
    /// </summary>
    [Test]
    public void CheckToCorrectnessSymbol()
    {
        var word = "ba3ana";
        Assert.Throws<ArgumentException>(() => MoveToFront.Encode(word));
    }

    /// <summary>
    /// test method about words without repitition.
    /// </summary>
    [Test]
    public void TestWordWithoutRepetition()
    {
        var word = "bbbbbbb";
        var encodedSequence = new int[] { 1, 0, 0, 0, 0, 0, 0 };
        Assert.That(MoveToFront.Encode(word), Is.EqualTo(encodedSequence));
    }

    /// <summary>
    /// method that checks word to capital symbols.
    /// </summary>
    [Test]
    public void TestBigSymbols()
    {
        var word = "BANANA";
        var encodedSequence = new int[] { 1, 1, 13, 1, 1, 1 };
        Assert.That(MoveToFront.Encode(word), Is.EqualTo(encodedSequence));
    }

    /// <summary>
    /// method that checks the null words.
    /// </summary>
    [Test]
    public void CheckNullString()
    {
        var emptyString = string.Empty;
        Assert.Throws<ArgumentNullException>(() => MoveToFront.Encode(emptyString));
    }
}