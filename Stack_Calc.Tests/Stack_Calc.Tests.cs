
namespace Stack_Calc.Tests;

public class Tests
{
    private Massiv _massiv;
    private Spisok _spisok;

    [SetUp]
    public void SetUp1()
    {
        _massiv = new Massiv();
    }

    public void SetUp2()
    {
        _spisok = new Spisok();
    }

    [Test]
    public void Long_record_Massiv()
    {
        var _massiv = new Massiv();
        Assert.That(Math.Abs(_massiv.Answer_2("1 3 + 7 * 7 / 7 + 9 7 * -") - (-52)) < 1e-10);
    }
    [Test]
    public void With_Zero_Massiv()
    {
        var _massiv = new Massiv();

        Assert.That(Math.Abs(_massiv.Answer_2("0 0 *") - 0) < 1e-10);
        Assert.That(Math.Abs(_massiv.Answer_2("0 4568 +") - 456) < 1e-10);
        Assert.That(Math.Abs(_massiv.Answer_2("0 34 /") - 0) < 1e-10);
        Assert.AreEqual(_massiv.Answer_2("43 0 /"), "Mistake");
    }

    [Test]
    public void Different_Numbers_Massiv()
    {
        var _massiv = new Massiv();

        Assert.That(Math.Abs(_massiv.Answer_2("34 -67 +") - (-33)) < 1e-10);
        Assert.That(Math.Abs(_massiv.Answer_2("0 -456 +") - (-456)) < 1e-10);
        Assert.That(Math.Abs(_massiv.Answer_2("0 3444 *") - 0) < 1e-10);
        Assert.That(Math.Abs(_massiv.Answer_2("-400 1 /") - (-400)) < 1e-10);
    }
        

    
    [TestCase(2)]
    public void Test_one_PushPop_Massiv(int n)
    {
        _massiv.Adding(n);
        Assert.AreEqual(_massiv.Popping(), n);
    }  
    [Test]
    public void PushPop_Test_Massiv()
    {
        var _massiv = new Massiv();
        _massiv.Adding(1);
        _massiv.Adding(2);
        Assert.That(Math.Abs(_massiv.Popping() - 2) < 1e-10);
        Assert.That(Math.Abs(_massiv.Popping() - 1) < 1e-10);
    }

//
    [Test]
    public void Long_record_Spisok()
    {
        var _spisok = new Spisok();
        Assert.That(Math.Abs(_spisok.Answer_1("1 3 + 7 * 7 / 7 + 9 7 * -") - (-52)) < 1e-10);
    }
    [Test]
    public void With_Zero_Spisok()
    {
        var _spisok = new Spisok();

        Assert.That(Math.Abs(_spisok.Answer_1("0 0 *") - 0) < 1e-10);
        Assert.That(Math.Abs(_spisok.Answer_1("0 4568 +") - 456) < 1e-10);
        Assert.That(Math.Abs(_spisok.Answer_1("0 34 /") - 0) < 1e-10);
        Assert.AreEqual(_spisok.Answer_1("43 0 /"), "Mistake");
    }

    [Test]
    public void Different_Numbers_Spisok()
    {
        var _spisok = new Spisok();

        Assert.That(Math.Abs(_spisok.Answer_1("34 -67 +") - (-33)) < 1e-10);
        Assert.That(Math.Abs(_spisok.Answer_1("0 -456 +") - (-456)) < 1e-10);
        Assert.That(Math.Abs(_spisok.Answer_1("0 3444 *") - 0) < 1e-10);
        Assert.That(Math.Abs(_spisok.Answer_1("-400 1 /") - (-400)) < 1e-10);
    }
        

    
    [TestCase(2)]
    public void Test_one_PushPop_Spisok(int n)
    {
        _spisok.Adding(n);
        Assert.AreEqual(_spisok.Popping(), n);
    }  
    [Test]
    public void PushPop_Test_Spisok()
    {
        var _spisok = new Spisok();
        _spisok.Adding(1);
        _spisok.Adding(2);
        Assert.That(Math.Abs(_spisok.Popping() - 2) < 1e-10);
        Assert.That(Math.Abs(_spisok.Popping() - 1) < 1e-10);
    }

}