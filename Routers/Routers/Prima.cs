using Microsoft.VisualBasic;

public class Graphe
{
    public int Size {get; set;}
    public List<List<(int, int)>> graph {get; set;}
    public List<List<(int, int)>> trie;
    public List<int> NodesAtTrie;
    public Graphe(int size)
    {
        this.Size = size;
        this.graph = GraphWithSize(size);
        this.trie = GraphWithSize(size);
        this.NodesAtTrie = new List<int>();
    }
    /// <summary>
    /// creates graph with size
    /// </summary>
    /// <param name="size">size of graph, topology</param>
    /// <returns>topology at graph</returns>
    public List<List<(int, int)>> GraphWithSize(int size)
    {
        List<List<(int, int)>> graph = new();
        for (int i =0; i<size; ++i)
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
        trie[secondNode-1].Add((firstNode+1, weight));
    }
    /// <summary>
    /// checking to useless nodes
    /// </summary>
    /// <exception cref="NoEdgeException">exception if empty nodes</exception>
    public void EmptyNodes()
    {
        foreach (List<(int, int)> list in graph)
        {
            if (list.Count == 0 )
            {
                throw new NoEdgeException("Tere is Node, which doesnt contain edge");
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
        int firstNode =0, secondNode = 0;
        for (int i = 0; i<graph.Count; ++i)
        {
            foreach((int, int) couple in graph[i])
            {
                if (couple.Item2>max)
                {
                    max = couple.Item2;
                    secondNode = couple.Item1;
                    firstNode = i;
                }
            }
        }
        NewEdge(firstNode, secondNode, max);
        NodesAtTrie.Add(firstNode+1);
        NodesAtTrie.Add(secondNode);
    }
    /// <summary>
    /// crates right topology-graph 
    /// </summary>
    /// <returns>graph without extra edges</returns>
    public List<List<(int, int)>> Prima()
    {
        AddMaxWeight();
        int max = 0;
        int candidatToTrieOne = 0;
        int candidatToTrietwo = 0;
        while (NodesAtTrie.Count!=Size)
        {
            for (int Node = 0; Node<graph.Count; Node++)
            {
                if (NodesAtTrie.Contains(Node+1))
                {
                    foreach((int, int) couple in graph[Node])
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
                        else{
                            continue;
                        }
                    }
                }
                else{
                    continue;
                }
            }
            NewEdge(candidatToTrieOne, candidatToTrietwo, max);
            NodesAtTrie.Add(candidatToTrietwo);
        }
        return trie;
    }
}
