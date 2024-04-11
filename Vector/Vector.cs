using System.Drawing;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.Intrinsics;

public class VectorOperations
{
    public int Size {get; private set;}
    public Dictionary<int, int> Vector1 {get; private set;}
    public Dictionary<int, int> Vector2 {get; private set;}
    public VectorOperations(int[] array1, int[] array2, int size)
    {
        this.Size = size;
        this.Vector1 = TransformToVector(array1);
        this.Vector2 = TransformToVector(array2);
    } 
    public Dictionary<int, int> TransformToVector(int[] array)
    {
        if (array.Length <= Size)
        {
            /*throw new IncorrectSize*/
        }
        var vector = new Dictionary<int, int>();
        for (int i = 0;  i<array.Length; ++i)
        {
            if (!(array[i] == 0)) 
            {
                vector.Add(i, array[i]);
            }
        }
        return vector;
    }
    public Dictionary<int, int> Summ()
    {
        var result = new Dictionary<int, int>(Size);
        for (int i = 0; i<Size; ++i)
        {
            if (Vector1.ContainsKey(i) & Vector2.ContainsKey(i))
            {
                result.Add(i, Vector1[i]+Vector2[i]);
            }
            if (Vector1.ContainsKey(i) & Vector2.ContainsKey(i)==false)
            {
                result.Add(i, Vector1[i]);
            }
            if (Vector1.ContainsKey(i)==false & Vector2.ContainsKey(i))
            {
                result.Add(i, Vector2[i]);
            }
        }
        return result;
    }
    public Dictionary<int, int> Subtraction()
    {
        var result = new Dictionary<int, int>(Size);
        for (int i = 0; i<Size; ++i)
        {
            if (Vector1.ContainsKey(i) & Vector2.ContainsKey(i))
            {
                result.Add(i, Vector1[i]-Vector2[i]);
            }
            if (Vector1.ContainsKey(i) & Vector2.ContainsKey(i)==false)
            {
                result.Add(i, Vector1[i]);
            }
            if (Vector1.ContainsKey(i)==false & Vector2.ContainsKey(i))
            {
                result.Add(i, -Vector2[i]);
            }
        }
        return result;
    }
    public (bool, bool) CheckingToZero()
    {
        return (Vector1.Count==0, Vector1.Count==0);
    }
    public int SkalarDop()
    {
        int result = 0;// не доделал
        for (int i = 0; i<Size; ++i)
        {
            if (Vector1.ContainsKey(i) & Vector2.ContainsKey(i))
            {
                result+=(Vector1[i]*Vector2[i]);
            }
        }
        return result;
    }

    
}