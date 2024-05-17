namespace Trie;
public class ALZW
{
    private int bytes = 255;
    private int num1 = 256;
    private int num2 = 256;
    public byte[] Coding(byte[] bitsoforiginfile)
    {
        var dictionary = new Trie();
        for (int i = 0; i<=bytes; ++i)
        {
            List<byte> a=  new List<byte>{(byte)i};
            dictionary.Add(a, i);
        }
        byte[] res = new byte[0];
        List<byte> CheckBits = new List<byte> {bitsoforiginfile[0]};
        for (int i =1; i<bitsoforiginfile.Length; ++i)
        {
            CheckBits.Add(bitsoforiginfile[i]);
            if (dictionary.Contains(CheckBits))
            {
                continue;
            }
            else
            {
                dictionary.Add(CheckBits, num1);
                num1+=1;
                CheckBits.RemoveAt(CheckBits.Count - 1);
                Array.Resize(ref res, res.Length +1);
                res.Append((byte)dictionary.ValueOfKey(CheckBits));
                CheckBits = new List<byte> {bitsoforiginfile[i]};
            }
        }
        Array.Resize(ref res, res.Length +1);
        res.Append((byte)dictionary.ValueOfKey(CheckBits));
        return res;
    } 
    public byte[] Decoding(byte[] bitsofcompressedfile)
    {
        Dictionary<int, List<byte>> dictionary = new();
        for (int i = 0; i<=bytes; ++i)
        {
            dictionary.Add(i, new List<byte> {(byte)i});
        }
        var res = new List<byte>();
        List<byte> CheckBitsCf = new();
        res.Add(bitsofcompressedfile[0]);
        CheckBitsCf.Add(bitsofcompressedfile[0]);
        for (int i = 1; i<bitsofcompressedfile.Length; ++i)
        {
            CheckBitsCf.Add(dictionary[(int)bitsofcompressedfile[i]][0]);
            dictionary.Add(num2, CheckBitsCf);
            num2++;
            foreach (var j in dictionary[(int)bitsofcompressedfile[i]])
            {
                res.Add(j);
            }
            CheckBitsCf = new List<byte> (dictionary[(int)bitsofcompressedfile[i]]);
        }
        return res.ToArray();
    }

}