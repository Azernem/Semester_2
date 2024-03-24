using OpenFile;
var _LZW_OpenFile = new OpenFile.OpenFile();
if (!(args.Length==2))
{
    Console.WriteLine("wrong record of input");
}
else{
    if (!File.Exists(args[0]))
    {
        Console.WriteLine("Not such file");
        return;
    }
    switch(args[1])
    {
        case "-c":
            float ratioOf_CompOrigin = _LZW_OpenFile.Compress(args[0]);
            args[0]+=".zipped";
            Console.WriteLine($"ratio between comp.file and origin.file = {ratioOf_CompOrigin}.");
            break;
        case "-u":
            _LZW_OpenFile.Uncompress(args[0]);
            var str = args[0];
            args[0] = str[.. (str.Length - 7)];
            break;
        default:
            Console.WriteLine("wrong input of key after files name");
            break;      
    }
    
}