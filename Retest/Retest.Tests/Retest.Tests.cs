// <copyright file="Retest.Tests.cs" company="NematMusaev"> 
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Retest.Tests;
using Retest;
public class Tests
{
    [Test]
    public void TestWordWithRepetition()
    {
        var word = "banana";
        var encodedSequence = new int[] { 1, 1, 13, 1, 1, 1 };
        Assert.That(MoveToFront.Encode(word), Is.EqualTo(encodedSequence));
    }

    [Test]
    public void CheckNullString()
    {
        var emptyString = "";
        Assert.Throws<ArgumentNullException>(() => MoveToFront.Encode(emptyString));
    }
}