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
            var Current_Node = new Number(number);
            return Current_Node;
        }
        else
        {
            var Current_Node = new Operation(s[1]);
            var _ExpessionToNewTries = new ExpessionToNewTries();
            string[] a= _ExpessionToNewTries.NewExpressions(s); 
            (Current_Node.left_Node, Current_Node.right_Node) = (Trie(a[0]), Trie(a[1]));
            return Current_Node;
        }
    }
    /// <summary>
    /// creates whole trie 
    /// </summary>
    /// <param name="s">expression</param>
    /// <param name="Current_Node">node of trie</param>
    private void BuildingTrie(string s, Operation Current_Node)
    {
        if (Current_Node == null) {root = Trie(s); Current_Node = root;}
        var _ExpessionToNewTries = new ExpessionToNewTries();
        string[] a= _ExpessionToNewTries.NewExpressions(s);
        if (Current_Node.left_Node.Value == null)
        {
            BuildingTrie(a[0], (Operation)Current_Node.left_Node);
        }
        if (Current_Node.right_Node.Value == null)
        {
            BuildingTrie(a[1], (Operation)Current_Node.right_Node);
        }
        Current_Node.Value_Of_Node();
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
internal static class Program
{
    private static void Main(string[] args)
    {
        var a = new ParseTrie();
        Console.WriteLine(a.GetTrieValue("(* (+ 1 1) 2)"));
        a.PrintCalculate();


    }
}