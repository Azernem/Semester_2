/// <summary>
/// class about node at trie of calcilating
/// </summary>
public abstract class Node
{
    public float? Value {get; set;}
    public abstract float? Value_Of_Node();
    public abstract string PrintC();
}
/// <summary>
/// class about тще дуфмуы фе екшу
/// </summary>
public class Operation: Node
{
    public char Operand {get; private set;}
    public Node? left_Node;
    public Node? right_Node;
    public Operation(char operand)
    {
        Operand = operand;
    }
    /// <summary>
    /// returns value of nodes
    /// </summary>
    /// <returns>value of node</returns>
    public override float? Value_Of_Node()
    {
        switch(Operand)
            {
                case '+':
                    Value = left_Node.Value + right_Node.Value;
                    break;
                case '-':
                    Value = left_Node.Value - right_Node.Value;
                    break;
                case '*':
                    Value = left_Node.Value * right_Node.Value;
                    break;
                case '/':
                    if (!(right_Node.Value==0))
                    {
                        throw new DivisionByZeroException("dont divide on zero");
                    }
                    Value = left_Node.Value / right_Node.Value;
                    break;      
            }
        return Value;
    }
    /// <summary>
    /// method printes whole trie
    /// </summary>
    /// <returns>whole trie at expression</returns>
    public override string PrintC()
    {
        var s = $"( {Operand} {left_Node.PrintC()} {right_Node.PrintC()} )";
        return s;
    }
}
public class Number: Node
{
    public Number(int value)
    {
        Value = value;
    }
    /// <summary>
    /// returns value of node
    /// </summary>
    /// <returns>value</returns>
    public override float? Value_Of_Node()
    {
        return Value;
    }
    /// <summary>
    /// returnes whole trie
    /// </summary>
    /// <returns>expression of whole trie</returns>
    public override string PrintC()
    {
        var s = Convert.ToString(Value);
        return s;
    }
}