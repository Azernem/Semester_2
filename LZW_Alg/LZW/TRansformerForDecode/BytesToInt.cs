namespace TransformerForDecode;
/// <summary>
/// Class of transformer about bytes to int
/// </summary>
public class DecodeIntTransformer
{
    private readonly List<int> transformer = [];

    public int IntBitSize { get; set; } = 8;

    public int MaxInt { get; set; } = 256;

    private const int BitsInByte = 8;

    private int currentInt = 0;

    private int currentSizeOfInt = 0;

    public int[] GetArrayOfInts()
    {
        InsertIntToArray();
        return [.. transformer];
    }

    private void InsertIntToArray()
    {
        AddIntToTransformer();
    }

    private void AddIntToTransformer()
    {
        transformer.Add(currentInt);
        currentSizeOfInt = 0;
        currentInt = 0;
    }
    
    public bool Add(byte codeByte)
    {
        var presentment = ByteToBitpresentment(codeByte);

        var newNumber = false;

        foreach (var bit in presentment)
        {
            currentInt = (currentInt * 2) + bit;

            ++currentSizeOfInt;

            if (currentSizeOfInt == IntBitSize)
            {
                AddIntToTransformer();
                newNumber = true;
            }
        }

        return newNumber;
    }


    private byte[] ByteToBitpresentment(byte convertByte)
    {
        var presentment = new byte[BitsInByte];

        for (var i = BitsInByte - 1; i >= 0; --i)
        {
            presentment[i] = (byte)(convertByte % 2);
            convertByte /= 2;
        }

        return presentment;
    }
}