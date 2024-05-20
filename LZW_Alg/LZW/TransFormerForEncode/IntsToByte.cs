namespace TransformerForEncode;
/// <summary>
/// Class of transformer about ints to bytes
/// </summary>
public class EncodeByteTransformer
{
    private readonly List<byte> transformer = [];

    public int SizeOfSymbolBit { get; set; } = 8;

    public int MaxSymbol { get; set; } = 256;

    private const int BitsInByte = 8;

    private byte currentByte = 0;

    private int currentSizeOfByte = 0;

    public byte[] GetByteArray()
    {
        MakeByteArray();
        return [.. transformer];
    }

    private void MakeByteArray()
    {
        currentByte <<= BitsInByte - currentSizeOfByte;

        AddByteTotransformer();
    }

    private void AddByteTotransformer()
    {
        transformer.Add(currentByte);
        currentSizeOfByte = 0;
        currentByte = 0;
    }

    public void Add(int number)
    {
        var presentment = IntToBytepresentment(number);

        foreach (var bit in presentment)
        {
            currentByte = (byte)((currentByte * 2) + bit);
            ++currentSizeOfByte;

            if (currentSizeOfByte == BitsInByte)
            {
                AddByteTotransformer();
            }
        }
    }


    private byte[] IntToBytepresentment(int number)
    {
        var presentment = new byte[SizeOfSymbolBit];

        for (var i = SizeOfSymbolBit - 1; i >= 0; --i)
        {
            presentment[i] = (byte)(number % 2);
            number /= 2;
        }

        return presentment;
    }
}