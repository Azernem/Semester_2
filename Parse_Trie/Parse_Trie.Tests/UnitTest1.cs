namespace Parse_Trie.Tests;

using System.Linq.Expressions;
using Microsoft.VisualBasic;
using Parse_Trie;
public class Tests
{
    [TestCase("../../../NewExpressionForTrie.txt", new string[2] {"(+ 1 1)", "2"})]
    [TestCase("../../../NewExpressionForTrie2.txt", new string[2] {"(+ 3 4)", "(- 4 1)"})]
    
    public void NewExpressionForTrie(string s, string[] a)
    {
        var open = new OpenFile();
        s = open.ReadExpression(s);
        var expression = new ExpessionToNewTries();
        Assert.That(a,  Is.EqualTo(expression.NewExpressions(s)));
    }
    [Test]
    public void CalculatingExpression()
    {
        var parsetrie = new ParseTrie();
        var s = "(+ (* 4 5) (/ 5 10))";
        var res = 20.5;
        Assert.That(res, Is.EqualTo(parsetrie.GetTrieValue(s)));
    }
    [Test]
    public void CalculatingFile()
    {
        var open = new OpenFile();
        string s = "../../../NewExpressionForTrie2.txt";
        s = open.ReadExpression(s);
        var parsetrie = new ParseTrie();
        var res = 21;
        Assert.That(res, Is.EqualTo(parsetrie.GetTrieValue(s)));
    }
    [Test]
    public void PrintOfCalculate()
    {
        var s = "(* (+ 1 1) 2)";
        var parsetrie = new ParseTrie();
        parsetrie.GetTrieValue(s);
        var check_str = "( * ( + 1 1 ) 2 )";
        Assert.That(check_str, Is.EqualTo(parsetrie.PrintCalculate()));

    }

}