namespace OpenFile;
public class OpenFile
{
    int BitsAtByte = 8;
    public float Compress(string way)
    {   
    if (!File.Exists(way)) 
    {
        return -1;
    }
        var masoriginal = File.ReadAllBytes(way);
        if (masoriginal.Length == 0) 
        {
            return 0;
        }
        var InfoOriginF = this.BitsAtByte*masoriginal.Length;
        var LZW = new ALZW();
        var InfoCompressF = String.Join("", LZW.Coding(masoriginal)).Length;
        File.WriteAllBytes(way, LZW.Coding(masoriginal));
        return (float)(InfoCompressF/InfoOriginF);
    }
    public void Uncompress(string way)
    {
        if (!(way.Contains(".zipped"))) 
        {
            throw new ArgumentException("Wrong name of compressed file");
        }
        var mascompressedf = File.ReadAllBytes(way);
        var LZW = new ALZW();
        var InfoCompressF = String.Join("", mascompressedf).Length;
        File.WriteAllBytes(way, LZW.Decoding(mascompressedf));

    }
}