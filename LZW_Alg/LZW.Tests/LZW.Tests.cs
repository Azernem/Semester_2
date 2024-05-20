using LZW;
namespace LZW.Tests;

public class Tests
{
    
    [TestCase("../../../Files/text.txt")]
    [TestCase("../../../Files/Tyson.jpg")]
    public void Empty_YesOrNo(string path)
    {
        var result = OpenFile.Compress(path);
        Assert.That(!(result==0), "file is empty");
    }

    [TestCase("../../../Files/text.txt")]
    [TestCase("../../../Files/Empty.txt")]
    [TestCase("../../../Files/Tyson.jpg")]
    
    public void ExistsFileYesOrNo(string path)
    {
        Assert.That(!(Math.Abs(OpenFile.Compress(path) - (-1))==0) , "doesnt exist file");
    }

    [TestCase("../../../Files/text.txt")]
    [TestCase("../../../Files/Tyson.jpg")]
    public void IsСorrectfilecompression(string path)
    {
        byte[] firstinf = File.ReadAllBytes(path);
        OpenFile.Compress(path);
        path+=".zipped";
        OpenFile.Uncompress(path);
        byte[] secondinf = File.ReadAllBytes(path[..path.LastIndexOf('.')]);
        Assert.That(firstinf, Is.EqualTo(secondinf), "incorrect compression");
    }
    
    [TestCase("../../../Files/text.txt")]
    public void IsCorrectDataAtFiles(string path)
    {
        byte[] firstinf = File.ReadAllBytes(path);
        Assert.That(firstinf.Length>0);
        OpenFile.Compress(path);
        path+=".zipped";
        byte[] secondinf = File.ReadAllBytes(path);
        Assert.That(secondinf.Length<firstinf.Length);
        Assert.That(secondinf.Length>0);
        OpenFile.Uncompress(path);
    }
}