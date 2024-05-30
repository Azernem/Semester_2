/// <summary>
/// class that organises trie of calculating
/// </summary>
public class ParseTrie
{
    public Operation? root;
    /// <summary>
    /// initialises node of trie
    /// </summary>
    /// <param name="s">expression</param>
    /// <returns>nodes</returns>
    public dynamic Trie(string s)
    {
        int number;
        if (int.TryParse(Convert.ToString(s), out number)) {
            var CurrentNode = new Number(number);
            return CurrentNode;
        }
        else
        {
            var CurrentNode = new Operation(s[1]);
            var _ExpessionToNewTries = new ExpessionToNewTries();
            string[] a= _ExpessionToNewTries.NewExpressions(s); 
            (CurrentNode.leftNode, CurrentNode.rightNode) = (Trie(a[0]), Trie(a[1]));
            return CurrentNode;
        }
    }
    /// <summary>
    /// creates whole trie 
    /// </summary>
    /// <param name="s">expression</param>
    /// <param name="CurrentNode">node of trie</param>
    private void BuildingTrie(string s, Operation CurrentNode)
    {
        if (CurrentNode == null) 
        {
            root = Trie(s); 
            CurrentNode = root;
        }
        var _ExpessionToNewTries = new ExpessionToNewTries();
        string[] a= _ExpessionToNewTries.NewExpressions(s);
        if (CurrentNode.leftNode.Value == null)
        {
            BuildingTrie(a[0], (Operation)CurrentNode.leftNode);
        }
        if (CurrentNode.rightNode.Value == null)
        {
            BuildingTrie(a[1], (Operation)CurrentNode.rightNode);
        }
        CurrentNode.ValueOfNode();
    }
    /// <summary>
    /// moves trie calculating to root
    /// </summary>
    /// <param name="s">expression</param>
    /// <returns>value of parse trie</returns>
    public float? GetTrieValue(string s)
    {
        BuildingTrie(s, root);
        return root.Value;

    }
    /// <summary>
    /// printes trie
    /// </summary>
    /// <returns>parse trie</returns>
    public string PrintCalculate()
    {
        return root.PrintC();
    }
}
