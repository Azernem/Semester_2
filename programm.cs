using System.Data;
using System.Numerics;

internal static class Programm
{
    public static void Main(string[] argc)
    {
        var array1 = new int[4] {2, 0, 2, 2};
        var array2 = new int[4] {3, 0, 4, 3};
        var v = new VectorOperations(array1, array2, 4);
        Console.WriteLine(v.Summ()[1]);
    }
}