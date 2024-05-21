namespace Stack_Calculator.Tests;
public class Tests
{
    [Test]
    public void CalculateLongRecordArray()
    {
        var array = new CalculatorOnArray();
        Assert.That(Math.Abs(array.GetResultByArray("1 3 + 7 * 7 / 7 + 9 7 * -") - (-52)) < 1e-10);
    }

    [Test]
    public void CalculateWithZeroArray()
    {
        var array = new CalculatorOnArray();

        Assert.That(Math.Abs(array.GetResultByArray("0 0 *") - 0) < 1e-10);
        Assert.That(Math.Abs(array.GetResultByArray("0 4568 +") - 4568) < 1e-10);
        Assert.That(Math.Abs(array.GetResultByArray("0 34 /") - 0) < 1e-10);
        Assert.Throws<ExceptionDivideByZero>(() => array.GetResultByArray("43 0 /"));
    }

    [Test]
    public void CalculateDifferentNumbersArray()
    {
        var array = new CalculatorOnArray();

        Assert.That(Math.Abs(array.GetResultByArray("34 -67 +") - (-33)) < 1e-10);
        Assert.That(Math.Abs(array.GetResultByArray("0 -456 +") - (-456)) < 1e-10);
        Assert.That(Math.Abs(array.GetResultByArray("0 3444 *") - 0) < 1e-10);
        Assert.That(Math.Abs(array.GetResultByArray("-400 1 /") - (-400)) < 1e-10);
    }

    [TestCase(2)]
    public void TestOnePushPopAarray(int n)
    {
        var array = new CalculatorOnArray();
        array.Push(n);
        Assert.That(array.Pop(), Is.EqualTo(n));
    }

    [Test]
    public void PushPopTestArray()
    {
        var array = new CalculatorOnArray();
        array.Push(1);
        array.Push(2);
        Assert.That(Math.Abs(array.Pop() - 2) < 1e-10);
        Assert.That(Math.Abs(array.Pop() - 1) < 1e-10);
    }

    [TestCase("0 a /")]
    [TestCase("3 4 &")]
    public void IncorrectInputOnArray(string s)
    {
        var array = new CalculatorOnArray();
        Assert.Throws<ExceptionIncorrectInput>(() => array.GetResultByArray(s));
    }

    [TestCase("4 /")]
    [TestCase("+ * 3")]
    public void EmptyStackOnArray(string s)
    {
        var array = new CalculatorOnArray();
        Assert.Throws<ExceptionEmptyStack>(() => array.GetResultByArray(s));
    }

    [TestCase("1 2 3 +")]
    [TestCase("23 5 / 8")]
    public void DoesntExistFiniteResultOnArray(string s)
    {
        var array = new CalculatorOnArray();
        Assert.Throws<ExceptionDoesntExistResult>(() => array.GetResultByArray(s));
    }

    [Test]
    public void CalculateLongRecordList()
    {
        var list = new CalculatorOnList();
        Assert.That(Math.Abs(list.GetResultByList("1 3 + 7 * 7 / 7 + 9 7 * -") - (-52)) < 1e-10);
    }

    [Test]
    public void CalculateWithZeroList()
    {
        var list = new CalculatorOnList();

        Assert.That(Math.Abs(list.GetResultByList("0 0 *") - 0) < 1e-10);
        Assert.That(Math.Abs(list.GetResultByList("0 4568 +") - 4568) < 1e-10);
        Assert.That(Math.Abs(list.GetResultByList("0 34 /") - 0) < 1e-10);
        Assert.Throws<ExceptionDivideByZero>(() => list.GetResultByList("43 0 /"));
    }

    [Test]
    public void Different_Numberslist()
    {
        var list = new CalculatorOnList();

        Assert.That(Math.Abs(list.GetResultByList("34 -67 +") - (-33)) < 1e-10);
        Assert.That(Math.Abs(list.GetResultByList("0 -456 +") - (-456)) < 1e-10);
        Assert.That(Math.Abs(list.GetResultByList("0 3444 *") - 0) < 1e-10);
        Assert.That(Math.Abs(list.GetResultByList("-400 1 /") - (-400)) < 1e-10);
    }

    [TestCase(2)]
    public void TestOnePushPoplist(int n)
    {
        var list = new CalculatorOnList();
        list.Push(n);
        Assert.That(list.Pop(), Is.EqualTo(n));
    }

    [Test]
    public void PushPopTestList()
    {
        var list = new CalculatorOnList();
        list.Push(1);
        list.Push(2);
        Assert.That(Math.Abs(list.Pop() - 2) < 1e-10);
        Assert.That(Math.Abs(list.Pop() - 1) < 1e-10);
    }

    [TestCase("0 a /")]
    [TestCase("3 4 &")]
    public void IncorrectInputOnList(string s)
    {
        var list = new CalculatorOnList();
        Assert.Throws<ExceptionIncorrectInput>(() => list.GetResultByList(s));
    }

    [TestCase("4 /")]
    [TestCase("+ * 3")]
    public void EmptyStackOnList(string s)
    {
        var list = new CalculatorOnList();
        Assert.Throws<ExceptionEmptyStack>(() => list.GetResultByList(s));
    }

    [TestCase("1 2 3 +")]
    [TestCase("23 5 / 8")]
    public void DoesntExistFiniteResultOnList(string s)
    {
        var list = new CalculatorOnList();
        Assert.Throws<ExceptionDoesntExistResult>(() => list.GetResultByList(s));
    }
}