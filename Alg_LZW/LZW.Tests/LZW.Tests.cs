using LZW;
namespace LZW.Tests;

public class Tests
{
    [TestCase("../../../Files/Words.txt")]
    [TestCase("../../../Files/Empty.txt")]
    [TestCase("../../../Files/Tyson.jpg")]
    public void Empty_YesOrNo(string way)
    {
        var result = OpenFile.Compress(way);
        Assert.That(!(result=0), "file is empty");
    }

    [TestCase("../../../Files/Words.txt")]
    [TestCase("../../../Files/Empty.txt")]
    [TestCase("../../../Files/Tyson.jpg")]
    public void ExistsFile_YesOrNo(string way)
    {
        Assert.That(!(Math.Abs(OpenFile.Compress(way) - (-1))==0) , "doesnt exist file");
    }

    [TestCase("../../../Files/Words.txt")]
    [TestCase("../../../Files/Empty.txt")]
    [TestCase("../../../Files/Tyson.jpg")]
    public void Сorrect_file_compression(string way)
    {
        byte[] first_inf = File.ReadAllBytes(way);
        OpenFile.Compress(way);
        way+=".zipped";
        OpenFile.Uncompress(way);
        byte[] second_inf = File.ReadAllBytes(way);
        Assert.AreEqual(first_inf, second_inf);
    }
    
    
}