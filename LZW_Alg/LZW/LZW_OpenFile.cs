namespace LZW;
public static class OpenFile
{
    static int BitsAtByte = 8;
    public static float Compress(string path)
    {   
        if (!File.Exists(path)) 
        {

            return -1;
        }

        var bytesCompressedFile = File.ReadAllBytes(path);

        if (bytesCompressedFile.Length == 0) 
        {

            return 0;
        }

        var LZW = new ALZW();
        float firstFileInfo = new FileInfo(path).Length;
        path+=".zipped";
        File.WriteAllBytes(path, LZW.Encode(bytesCompressedFile));
        var secondFileInfo = new FileInfo(path).Length;

        return (float)(secondFileInfo/firstFileInfo);
    }

    public static void Uncompress(string path)
    {
        if (!path.Contains(".zipped")) 
        {
            throw new ArgumentException("Wrong name of compressed file");
        }

        var bytesCompressedFile = File.ReadAllBytes(path);
        var LZW = new ALZW();
        path = path[..path.LastIndexOf('.')];
        File.WriteAllBytes(path, LZW.Decode(bytesCompressedFile));
    }
}