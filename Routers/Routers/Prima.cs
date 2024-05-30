// <copyright file="Prima.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Microsoft.VisualBasic;

public class Graph
{
    public int Size {get; set;}

    public List<List<(int, int)>> graph {get; set;}

    public List<List<(int, int)>> trie;

    public List<int> NodesAtTrie;

    public string path;

    public Graph(string path)
    {
        this.path = path;
        this.Size = MaxNode(path);
        this.graph = GraphWithSize(Size);
        this.trie = GraphWithSize(Size);
        this.NodesAtTrie = new List<int>();
    }

    /// <summary>
    /// method wich gets graph from input expression
    /// </summary>
    /// <param name="path">filepath</param>
    /// <returns></returns>
    /// <exception cref="NoSuchpathException">throw exseption if file doesnt exist </exception>
    public void GetGraph()
    {

        if (!File.Exists(path))
        {
            throw new NoSuchPathException("No such file");
        }

        string[] expression = File.ReadAllLines(path);

        for (int i = 0; i < expression.Length; ++i)
        {
            var stringDependendNodes = expression[i].Substring(3, expression[i].Length - 4);
            stringDependendNodes = stringDependendNodes.Replace("(", "").Replace(")", "").Replace(", ", ",");
            var couples = GetCouplesDependendNodes(stringDependendNodes);

            foreach (var couple in couples)
            {
                graph[i].Add(couple);
                graph[couple.Item1 - 1].Add((i + 1, couple.Item2));
            }
        }

        this.EmptyNodes();
    }

    /// <summary>
    /// method that returns a max number router (emount of all routers at topology)
    /// </summary>
    /// <param name="path">filepath with topology-text</param>
    /// <returns>emount of all routers at topology</returns>
    /// <exception cref="NoSuchpathException">throw exseption if file doesnt exist</exception>
    public int MaxNode(string path)
    {
        int max = 0;

        if (!File.Exists(path))
        {
            throw new NoSuchPathException("No such file");
        }

        string[] expression = File.ReadAllLines(path);

        for (int i = 0; i < expression.Length; ++i)
        {
            var stringDependendNodes = expression[i].Substring(3, expression[i].Length - 4);
            stringDependendNodes = stringDependendNodes.Replace("(", "").Replace(")", "").Replace(", ", ",");
            var couples = GetCouplesDependendNodes(stringDependendNodes);

            foreach (var couple in couples)
            {
                if (couple.Item1 > max)
                {
                    max = couple.Item1;
                }
            }
        }

        return max;
    }

    /// <summary>
    /// method transformes topology-text to array of couples
    /// </summary>
    /// <param name="s">line of file</param>
    /// <returns>array of int couples</returns>
    /// <exception cref="IncorrectExpressionException">incorrect topology</exception>
    public (int, int)[] GetCouplesDependendNodes(string s)
    {
        var array = s.Split(",");
        var result = new (int, int)[array.Length];

        for (int i = 0; i < array.Length; ++i)
        {
            var arraypara = array[i].Split(" ");
            int numbernode, numberweight;

            if (int.TryParse(arraypara[0], out numbernode) && int.TryParse(arraypara[1], out numberweight))
            {
                result[i] = (numbernode, numberweight);
            }
            else
            {
                throw new IncorrectExpressionException(" router isnt number in expression");
            }
        }

        return result;

    }

    /// <summary>
    /// creates graph with size
    /// </summary>
    /// <param name="size">size of graph, topology</param>
    /// <returns>topology at graph</returns>
    public List<List<(int, int)>> GraphWithSize(int size)
    {
        List<List<(int, int)>> graph = new ();

        for (int i =0; i < size; ++i)
        {
            var list = new List<(int, int)>();
            graph.Add(list);
        }

        return graph;
    }

    /// <summary>
    /// method that to  new router-edges to graph 
    /// </summary>
    /// <param name="firstNode">first node</param>
    /// <param name="secondNode">second node</param>
    /// <param name="weight">power of edge</param>
    public void NewEdge(int firstNode, int secondNode, int weight)
    {
        trie[firstNode].Add((secondNode, weight));
        trie[secondNode - 1].Add((firstNode + 1, weight));
    }

    /// <summary>
    /// checking to useless nodes
    /// </summary>
    /// <exception cref="NoEdgeException">exception if empty nodes</exception>
    public void EmptyNodes()
    {
        foreach (List<(int, int)> list in graph)
        {
            if (list.Count == 0)
            {
                throw new NoEdgeException("There is Node, which doesnt contain edge");
            }
        }
    }

    /// <summary>
    /// searcing of maximal weight? power of edge
    /// </summary>
    public void AddMaxWeight()
    {
        EmptyNodes();
        var max = 0;
        int firstNode = 0, secondNode = 0;

        for (int i = 0; i < graph.Count; ++i)
        {
            foreach (var couple in graph[i])
            {
                if (couple.Item2 > max)
                {
                    max = couple.Item2;
                    secondNode = couple.Item1;
                    firstNode = i;
                }
            }
        }

        NewEdge(firstNode, secondNode, max);
        NodesAtTrie.Add(firstNode + 1);
        NodesAtTrie.Add(secondNode);
    }

    /// <summary>
    /// crates right topology-graph 
    /// </summary>
    /// <returns>graph without extra edges</returns>
    public List<List<(int, int)>> Prima()
    {
        GetGraph();
        AddMaxWeight();
        int max = 0;
        int candidatToTrieOne = 0;
        int candidatToTrietwo = 0;

        while (NodesAtTrie.Count!=Size)
        {
            for (int Node = 0; Node < graph.Count; Node++)
            {
                if (NodesAtTrie.Contains(Node + 1))
                {
                    foreach(var couple in graph[Node])
                    {
                        if (!(NodesAtTrie.Contains(couple.Item1)))
                        {
                            if (couple.Item2>max)
                            {
                                max = couple.Item2;
                                candidatToTrietwo = couple.Item1;
                                candidatToTrieOne = Node;
                            }
                        }
                    }
                }
            }

            NewEdge(candidatToTrieOne, candidatToTrietwo, max);
            NodesAtTrie.Add(candidatToTrietwo);
        }
        
        return trie;
    }
}
