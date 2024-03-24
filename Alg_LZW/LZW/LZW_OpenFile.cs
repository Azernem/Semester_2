namespace OpenFile;
public class OpenFile
{
    int BitsAtByte = 8;
    public float Compress(string way)
    {   if (!File.Exists(way)) {return -1;};
        var mas_original = File.ReadAllBytes(way);
        if (mas_original.Length == 0) {return 0;};
        var InfoOriginF = this.BitsAtByte*mas_original.Length;
        var _LZW = new A_LZW();
        var InfoCompressF = String.Join("", _LZW.Coding(mas_original)).Length;
        File.WriteAllBytes(way, _LZW.Coding(mas_original));
        return (float)(InfoCompressF/InfoOriginF);
    }
    public void Uncompress(string way)
    {
        if (!(way.Contains(".zipped"))) 
        {
            throw new ArgumentException("Wrong name of compressed file");
        }
        var mas_of_compressedF = File.ReadAllBytes(way);
        var _LZW = new A_LZW();
        var InfoCompressF = String.Join("", mas_of_compressedF).Length;
        File.WriteAllBytes(way, _LZW.Decoding(mas_of_compressedF));

    }
}