/// <summary>
/// class wich creates graph (topology) of input expression
/// </summary>
public class CreateGraph
{
    /// <summary>
    /// method wich gets graph from input expression
    /// </summary>
    /// <param name="path">filepath</param>
    /// <returns></returns>
    /// <exception cref="NoSuchpathException">throw exseption if file doesnt exist </exception>
    public Graphe GetGraph(string path)
    {
        if (!(File.Exists(path)))
        {
            throw new NoSuchpathException("No such file");
        }
        string[] expression = File.ReadAllLines(path);
        var Graph = new Graphe(MaxNode(path));
        var graph = Graph.graph;
        for (int i = 0; i<expression.Length; ++i)
        {
            var stringDependendNodes = expression[i].Substring(3, expression[i].Length - 4);
            stringDependendNodes = stringDependendNodes.Replace("(", "").Replace(")", "").Replace(", ", ",");
            var couples = GetCouplesDependendNodes(stringDependendNodes);
            foreach ((int, int) couple in couples)
            {
                graph[i].Add(couple);
                graph[couple.Item1 - 1].Add((i+1, couple.Item2));
            }
        }
        Graph.graph = graph;
        Graph.EmptyNodes();
        return Graph;
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
        if (!(File.Exists(path)))
        {
            throw new NoSuchpathException("No such file");
        }
        string[] expression = File.ReadAllLines(path);
        for (int i = 0; i<expression.Length; ++i)
        {
            var stringDependendNodes = expression[i].Substring(3, expression[i].Length - 4);
            stringDependendNodes = stringDependendNodes.Replace("(", "").Replace(")", "").Replace(", ", ",");
            var couples = GetCouplesDependendNodes(stringDependendNodes);
            foreach ((int, int) couple in couples)
            {
                if (couple.Item1>max)
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
        for (int i =0; i<array.Length; ++i)
        {
            var arraypara = array[i].Split(" ");
            int numbernode, numberweight;
            if (int.TryParse(arraypara[0], out numbernode) && int.TryParse(arraypara[1], out numberweight))
            {
                result[i] = (numbernode, numberweight);
            }
            else{
                throw new IncorrectExpressionException(" router isnt number in expression");
            }
        }
        return result;

    }
}