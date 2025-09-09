// <copyright file="Router.Tests.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Routers.Tests;

using System;
using System.Collections.Generic;
using Routers;

public class Tests
{
    [Test]
    public void IsCountDependings()
    {
        string way = "../../../IsCountDependings.txt";
        var graphclass = new Graph(way);
        graphclass.GetGraph();
        Assert.That(graphclass.graph.Count, Is.EqualTo(5));
    }
    [Test]
    public void ExpressionToGraph()
    {
        string way = "../../../ExpressionToGraph.txt";
        var graphclass = new Graph(way);
        graphclass.GetGraph();
        var checkgraph = new List<List<(int, int)>>() {new List<(int, int)> {(2, 10), (3, 5)}, new List<(int, int)> {(1, 10), (3, 1)}, new List<(int, int)> {(1, 5), (2, 1)}};
        Assert.That(checkgraph, Is.EqualTo(graphclass.graph));
    }
    [Test]
    public void TopologyWithoutExtraEdges()
    {
        string way = "../../../ExpressionToGraph.txt";
        var graphclass = new Graph(way);
        graphclass.Prima();
        var checktrie = new List<List<(int,  int)>>() {new List<(int, int)> {(2, 10), (3, 5)}, new List<(int, int)> {(1, 10)}, new List<(int, int)> {(1, 5)}};
        Assert.That(checktrie, Is.EqualTo(graphclass.trie));
    }
}