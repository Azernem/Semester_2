using TransformerForEncode;
using TransformerForDecode;
namespace LZW;
public class ALZW
{
    const int Bytes = 256;
    private int num1 = 256;
    private int num2 = 256;

    public byte[] Encode(byte[] bitsOfOriginalFile)
    {
        var dictionary = new Trie();
        var number = Bytes;

        for (int i = 0; i<Bytes; ++i)
        {
            List<byte> a=  new List<byte>{(byte)i};
            dictionary.Add(a, i);
        }

        var code = new EncodeByteTransformer();
        List<byte> checkBits = new List<byte> {bitsOfOriginalFile[0]};

        for (int i =1; i<bitsOfOriginalFile.Length; ++i)
        {
            checkBits.Add(bitsOfOriginalFile[i]);

            if (dictionary.Contains(checkBits))
            {
                continue;
            }
            else
            {
                if (code.MaxSymbol == dictionary.Size)
                {
                    code.SizeOfSymbolBit++;
                    code.MaxSymbol *= 2;
                }

                dictionary.Add(checkBits, number);
                number++;
                checkBits.RemoveAt(checkBits.Count - 1);
                code.Add(dictionary.ValueOfKey(checkBits));
                checkBits = new List<byte> {bitsOfOriginalFile[i]};
            }
        }
        code.Add(dictionary.ValueOfKey(checkBits));

        return code.GetByteArray();
    }

    public byte[] Decode(byte[] code)
    {
        var encode = new DecodeIntTransformer();
        var number = Bytes;
        Dictionary<int, List<byte>> dictionary = new();

        for (int i = 0; i<Bytes; ++i)
        {
            dictionary.Add(i, new List<byte> {(byte)i});
        }

        foreach (var newByte in code)
        {
            if (number == encode.MaxInt)
            {
                ++encode.IntBitSize;
                encode.MaxInt *= 2;
            }

            if (encode.Add(newByte))
            {
                ++number;
            }
        }

        var encodeInts = encode.GetArrayOfInts();
        number = 256;
        var result = new List<byte>();
        List<byte> checkBits = new();
        result.AddRange(dictionary[encodeInts[0]]);
        checkBits.AddRange(dictionary[encodeInts[0]]);

        for (int i = 1; i < encodeInts.Length; ++i)
        {
            if (dictionary.ContainsKey(encodeInts[i]))
            {
                checkBits.Add(dictionary[encodeInts[i]][0]);
            }
            else
            {
                checkBits.Add(checkBits[0]);
            }
            
            dictionary.Add(number, checkBits);
            number++;

            foreach (var j in dictionary[encodeInts[i]])
            {
                result.Add(j);
            }

            checkBits = new List<byte> (dictionary[encodeInts[i]]);
        }
        result.RemoveAt(result.Count - 1);

        return [.. result];
    }

}