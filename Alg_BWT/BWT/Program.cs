namespace BWT;
class Program
{
    static void Main(string[] args)
    {
        var input = BWT.DirectBWT();
        Console.WriteLine($"{input}, {input.IndexOf('$')}");
        Console.WriteLine(BWT.InverseBWT(input, input.IndexOf('$')));
    }
}
