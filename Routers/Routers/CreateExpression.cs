// <copyright file="CreateExpression.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// class that transformes graph to expression if topology without extra edges
/// </summary>

public class GraphToExpression
{
    /// <summary>
    /// transformes graph to expression 
    /// </summary>
    /// <param name="path">filepath with right topology</param>
    /// <param name="Graph">class of graph trie and algoritme Prima</param>
    public void CreateExpression(string path, string toPath)
    {
        var graphclass = new Graph(path);
        graphclass.Prima();
        var trie = graphclass.trie;
        var result = new List<string>();

        for (int line = 0; line < trie.Count; ++line)
        {
            if (trie[line].Count > 1)
            {
                string s = $"{line + 1}: ";

                foreach (var couple in trie[line])
                {
                    s += $"{couple.Item1} ({couple.Item2}), ";
                } 

                s = s.Substring(0, s.Length - 2);
                result.Add(s);
            }
        }
        
        File.WriteAllLines(toPath, result.ToArray());
    }
}