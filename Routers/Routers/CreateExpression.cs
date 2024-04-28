/// <summary>
/// class that transformes graph to expression if topology without extra edges
/// </summary>
public class GraphToExpression
{
    /// <summary>
    /// transformes graph to expression 
    /// </summary>
    /// <param name="way">filepath with right topology</param>
    /// <param name="_Graph">class of graph trie and algoritme Prima</param>
    public void CreateExpression(string way, Graph _Graph)
    {
        _Graph.Prima();
        var trie = _Graph.trie;
        var result = new List<string>();
        for (int line = 0; line<trie.Count; ++line)
        {
            if (trie[line].Count>1)
            {
            string s = $"{line+1}: ";
            foreach((int, int) couple in trie[line])
            {
                s+= $"{couple.Item1} ({couple.Item2}), ";
            } 
            s = s.Substring(0, s.Length - 2);
            result.Add(s);
            }
        }
        File.WriteAllLines(way, result.ToArray());
    }
}