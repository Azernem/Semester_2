/// <summary>
/// class wich creates graph (topology) of input expression
/// </summary>
public class CreateGraph
{
    /// <summary>
    /// method wich gets graph from input expression
    /// </summary>
    /// <param name="way">filepath</param>
    /// <returns></returns>
    /// <exception cref="NoSuchWayException">throw exseption if file doesnt exist </exception>
    public Graph GetGraph(string way)
    {
        if (!(File.Exists(way)))
        {
            throw new NoSuchWayException("No such file");
        }
        string[] expression = File.ReadAllLines(way);
        var _Graph = new Graph(MaxNode(way));
        var graph = _Graph.graph;
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
        _Graph.graph = graph;
        _Graph.EmptyNodes();
        return _Graph;
    }
    /// <summary>
    /// method that returns a max number router (emount of all routers at topology)
    /// </summary>
    /// <param name="way">filepath with topology-text</param>
    /// <returns>emount of all routers at topology</returns>
    /// <exception cref="NoSuchWayException">throw exseption if file doesnt exist</exception>
    public int MaxNode(string way)
    {
        int max = 0;
        if (!(File.Exists(way)))
        {
            throw new NoSuchWayException("No such file");
        }
        string[] expression = File.ReadAllLines(way);
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