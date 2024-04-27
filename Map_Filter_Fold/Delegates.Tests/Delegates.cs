namespace Delegates.Tests;
using MapFilterFold;
public class Tests
{
    [Test]
    public void Map_Int_Summ()
    {
        var Functions = new Functions();
        var start_list = new List<int>() {1, 2, 3};
        var res_list = new List<int>() {4, 5, 6};
        Assert.That(res_list, Is.EqualTo(Functions.Map(start_list, x => x + 3)));
    }
    [Test]
    public void Map_Int_Multiplication()
    {
        var Functions = new Functions();
        var start_list = new List<int>() {3, 9, 9};
        var res_list = new List<int>() {9, 27, 27};
        Assert.That(res_list, Is.EqualTo(Functions.Map(start_list, x => x * 3)));
    } 
    [Test]
    public void Filter_Int()
    {
        var Functions = new Functions();
        var start_list = new List<int>() {6, 8, 9};
        var res_list = new List<int>() {6, 8};
        Assert.That(res_list,  Is.EqualTo(Functions.Filter(start_list, x => x % 2 == 0)));
    }
    [Test]
    public void Filter_Double()
    {
        var Functions = new Functions();
        var start_list = new List<double>() {6.4, 8.3, 9};
        var res_list = new List<Double>() {9};
        Assert.That(res_list,  Is.EqualTo(Functions.Filter(start_list, x => x == (int)x)));
    }
    [Test]
    public void Fold_Int()
    {
        var Functions = new Functions();
        var start_list = new List<int>() {1, 2, 3};
        Assert.That(6, Is.EqualTo(Functions.Fold(start_list, 1, (x, y) => x*y)));
    }
    [Test]
    public void Fold_String()
    {
        var Functions = new Functions();
        var start_list = new List<string> {"a", "b", "c", "d"};
        Assert.That("abcd", Is.EqualTo(Functions.Fold(start_list, "", (x, y) => x + y)));
    }
}