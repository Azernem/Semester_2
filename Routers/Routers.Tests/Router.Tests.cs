namespace Routers.Tests;

using System;
using System.Collections.Generic;
using Routers;

public class Tests
{
    [Test]
    public void IsCountDependings()
    {
        var creat = new CreateGraph();
        string s = "../../../IsCountDependings.txt";
        var g = creat.GetGraph(s);
        Assert.That(g.graph.Count, Is.EqualTo(5));
    }
    [Test]
    public void ExpressionToGraph()
    {
        var creategraph = new CreateGraph();
        string way = "../../../ExpressionToGraph.txt";
        var Graph = creategraph.GetGraph(way);
        var checkgraph = new List<List<(int, int)>>() {new List<(int, int)> {(2, 10), (3, 5)}, new List<(int, int)> {(1, 10), (3, 1)}, new List<(int, int)> {(1, 5), (2, 1)}};
        Assert.That(checkgraph, Is.EqualTo(Graph.graph));
    }
    [Test]
    public void TopologyWithoutExtraEdges()
    {
        var creategraph = new CreateGraph();
        string way = "../../../ExpressionToGraph.txt";
        var Graph = creategraph.GetGraph(way);
        Graph.Prima();
        var checktrie = new List<List<(int,  int)>>() {new List<(int, int)> {(2, 10), (3, 5)}, new List<(int, int)> {(1, 10)}, new List<(int, int)> {(1, 5)}};
        Assert.That(checktrie, Is.EqualTo(Graph.trie));
    }
}