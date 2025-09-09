using UniqueList;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Exceptions;

namespace UniqueList.Tests;

public class Tests
{
    [TestCase(1, 0, 3, 2)]
    [TestCase(3, 0, 4, 6)]
    public void IndexOutOfRange_Adding(int i1, int i2, int j1, int j2)
    {
        var list = new UsualList();
        list.Adding_Value(i1, i2);
        Assert.Throws<IndexOutOfRangeException>(() => list.Adding_Value(j1,j2));
    }
    [Test]
    public void IndexOutOfRange_Change()
    {
        var list = new UsualList();
        list.Adding_Value(2, 0);
        list.Adding_Value(3, 1);
        list.Adding_Value(5, 2);
        Assert.Throws<IndexOutOfRangeException>(() => list.Change_Value(4, 3));
    }
    [Test]
    public void IndexOutOfRange_Remove()
    {
        var list = new UsualList();
        list.Adding_Value(2, 0);
        list.Adding_Value(3, 1);
        list.Adding_Value(5, 2);
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(4));
    }
    [TestCase(1, 0, 3, 2)]
    [TestCase(3, 0, 4, 6)]
    public void IndexOutOfRange_Adding_UniqueList(int i1, int i2, int j1, int j2)
    {
        var list = new UniqueList();
        list.Adding_Value(i1, i2);
        Assert.Throws<IndexOutOfRangeException>(() => list.Adding_Value(j1,j2));
    }
    [Test]
    public void ValueAtList_UniqueList()
    {
        var list = new UniqueList();
        list.Adding_Value(1, 0);
        Assert.That(list.ValueAtList(1));
    }
    [Test]
    public void ValueAtList_SeveralElements_UniqueList()
    {
        var list = new UniqueList();
        list.Adding_Value(1, 0);
        list.Adding_Value(3, 1);
        list.Adding_Value(15, 2);
        list.Adding_Value(2, 3);
        Assert.That(list.ValueAtList(15));
    }
    [TestCase(3)]
    [TestCase(0)]
    public void EmptyList_UniqueList(int i)
    {
        var list = new UniqueList();
        Assert.Throws<EmptyListException>(() => list.ValueAtList(i));
    }
    [TestCase(15, 5)]
    [TestCase(3, 5)]
    [TestCase(1, 3)]
    public void Exception_Adding_Value_UniqueList(int value, int index)
    {
        var list = new UniqueList();
        list.Adding_Value(1, 0);
        list.Adding_Value(3, 1);
        list.Adding_Value(15, 2);
        list.Adding_Value(4, 3);
        list.Adding_Value(43, 4);
        Assert.Throws<RepeatOfValueException>(() => list.Adding_Value(value, index));
    }
    [Test]
    public void Exception_Change_Value_UniqueList()
    {
        var list = new UniqueList();
        list.Adding_Value(1, 0);
        list.Adding_Value(3, 1);
        list.Adding_Value(15, 2);
        list.Adding_Value(4, 3);
        list.Adding_Value(43, 4);
        Assert.Throws<ChangeToExistingElementException>(() => list.Change_Value(15, 0));
    }
    [Test]
    public void Adding_Value_NoToEnd()
    {
        var list =  new UniqueList();
        list.Adding_Value(1, 0);
        list.Adding_Value(3, 1);
        list.Adding_Value(10, 2);
        list.Adding_Value(9, 1);
        Assert.That(list.Count == 4);
        Assert.That(list.ValueAtList(9));
    }
}