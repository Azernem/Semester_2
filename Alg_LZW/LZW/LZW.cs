using Bor_Trie;
public class A_LZW
{
    private int Bytes = 255;
    private int num1 = 256;
    private int num2 = 256;
    public byte[] Coding(byte[] bits_of_originf)
    {
        var dict = new Trie();
        for (int i = 0; i<=Bytes; ++i)
        {
            List<byte> a=  new List<byte>{(byte)i};
            dict.Add(a, i);
        }
        byte[] res = new byte[0];
        List<byte> CheckBits = new List<byte> {bits_of_originf[0]};
        for (int i =1; i<bits_of_originf.Length; ++i)
        {
            CheckBits.Add(bits_of_originf[i]);
            if (dict.Contains(CheckBits))
            {
                continue;
            }
            else
            {
                dict.Add(CheckBits, num1);
                num1+=1;
                CheckBits.RemoveAt(CheckBits.Count - 1);
                Array.Resize(ref res, res.Length +1);
                res.Append((byte)dict.ValueOfKey(CheckBits));
                CheckBits = new List<byte> {bits_of_originf[i]};
            }
        }
        Array.Resize(ref res, res.Length +1);
        res.Append((byte)dict.ValueOfKey(CheckBits));
        return res;
    }
    public byte[] Decoding(byte[] bits_of_compressedf)
    {
        Dictionary<int, List<byte>> dict = new();
        for (int i = 0; i<=Bytes; ++i)
        {
            dict.Add(i, new List<byte> {(byte)i});
        }
        var res = new List<byte>();
        List<byte> CheckBitsCf = new();
        res.Add(bits_of_compressedf[0]);
        CheckBitsCf.Add(bits_of_compressedf[0]);
        for (int i = 1; i<bits_of_compressedf.Length; ++i)
        {
            CheckBitsCf.Add(dict[(int)bits_of_compressedf[i]][0]);
            dict.Add(num2, CheckBitsCf);
            num2++;
            foreach (var j in dict[(int)bits_of_compressedf[i]])
            {
                res.Add(j);
            }
            CheckBitsCf = new List<byte> (dict[(int)bits_of_compressedf[i]]);
        }
        return res.ToArray();
    }

}