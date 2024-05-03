using Bor_Trie;
public class ALZW
{
    private int Bytes = 255;
    private int num1 = 256;
    private int num2 = 256;
    public byte[] Coding(byte[] bitsoforiginf)
    {
        var dict = new Trie();
        for (int i = 0; i<=Bytes; ++i)
        {
            List<byte> a=  new List<byte>{(byte)i};
            dict.Add(a, i);
        }
        byte[] res = new byte[0];
        List<byte> CheckBits = new List<byte> {bitsoforiginf[0]};
        for (int i =1; i<bitsoforiginf.Length; ++i)
        {
            CheckBits.Add(bitsoforiginf[i]);
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
                CheckBits = new List<byte> {bitsoforiginf[i]};
            }
        }
        Array.Resize(ref res, res.Length +1);
        res.Append((byte)dict.ValueOfKey(CheckBits));
        return res;
    }
    public byte[] Decoding(byte[] bitsofcompressedf)
    {
        Dictionary<int, List<byte>> dict = new();
        for (int i = 0; i<=Bytes; ++i)
        {
            dict.Add(i, new List<byte> {(byte)i});
        }
        var res = new List<byte>();
        List<byte> CheckBitsCf = new();
        res.Add(bitsofcompressedf[0]);
        CheckBitsCf.Add(bitsofcompressedf[0]);
        for (int i = 1; i<bitsofcompressedf.Length; ++i)
        {
            CheckBitsCf.Add(dict[(int)bitsofcompressedf[i]][0]);
            dict.Add(num2, CheckBitsCf);
            num2++;
            foreach (var j in dict[(int)bitsofcompressedf[i]])
            {
                res.Add(j);
            }
            CheckBitsCf = new List<byte> (dict[(int)bitsofcompressedf[i]]);
        }
        return res.ToArray();
    }

}