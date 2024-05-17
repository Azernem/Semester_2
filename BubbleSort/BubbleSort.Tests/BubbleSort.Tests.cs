namespace BubbleSort.Tests;
using BubbleSort;
public class Tests
{
    [Test]
    public void AlphString()
    {
        var list = new List<string>() { "bob", "bat", "ase" };

        var result = new List<string>() { "ase","bat", "bob"};
        Assert.That(BubbleSort<string>.Bubble(list, Comparer<string>.Default), Is.EqualTo(result));
    }
    [Test]
    public void Ints()
    {
        var list = new List<int>() { 2, 4, 1};

        var result = new List<int>() { 1, 2, 4};
        Assert.That(BubbleSort<int>.Bubble(list, Comparer<int>.Default), Is.EqualTo(result));
    }

}