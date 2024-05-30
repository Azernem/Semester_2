/// <summary>
/// class about node at trie of calcilating
/// </summary>
public abstract class Node
{
    public float? Value {get; set;}
    public abstract float? ValueOfNode();
    public abstract string PrintC();
}
/// <summary>
/// class about тще дуфмуы фе екшу
/// </summary>
public class Operation: Node
{
    public char Operand {get; private set;}
    public Node? leftNode;
    public Node? rightNode;
    public Operation(char operand)
    {
        Operand = operand;
    }
    /// <summary>
    /// returns value of nodes
    /// </summary>
    /// <returns>value of node</returns>
    public override float? ValueOfNode()
    {
        switch(Operand)
            {
                case '+':
                    Value = leftNode.Value + rightNode.Value;
                    break;
                case '-':
                    Value = leftNode.Value - rightNode.Value;
                    break;
                case '*':
                    Value = leftNode.Value * rightNode.Value;
                    break;
                case '/':
                    if (rightNode.Value==0)
                    {
                        throw new DivisionByZeroException("dont divide on zero");
                    }
                    Value = leftNode.Value / rightNode.Value;
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
        var s = $"( {Operand} {leftNode.PrintC()} {rightNode.PrintC()} )";
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
    public override float? ValueOfNode()
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