namespace BubbleSort.Tests;
using BubbleSort;
public class Tests
{
    [Test]
    public void AlphString()
    {
        var list = new List<string>() { "bob", "bat", "ase" };

        var result = new List<string>() { "ase","bat", "bat"};
        Assert.That(BubbleSort<string>.BubbleSort(list, Comparer<string>.Default); Is.EqualTo(result));
    }
    [Test]
    public void Ints()
    {
        var list = new List<string>() { 2, 4, 1};

        var result = new List<string>() { 1, 2, 4};
        Assert.That(BubbleSort<string>.BubbleSort(list, Comparer<string>.Default); Is.EqualTo(result));
    }
    [Test]
    public void Length()
    {
        var list = new List<string>() { "bob", "bata", "asert" };

        var result = new List<string>() { "bob","bata", "asert"};
        Assert.That(BubbleSort<string>.BubbleSort(list, Comparer<string>.Default); Is.EqualTo(result));
    }

}