using OpenFile;
var LZWOpenFile = new OpenFile.OpenFile();
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
            float ratioOfCompOrigin = LZWOpenFile.Compress(args[0]);
            args[0]+=".zipped";
            Console.WriteLine($"ratio between comp.file and origin.file = {ratioOfCompOrigin}.");
            break;
        case "-u":
            LZWOpenFile.Uncompress(args[0]);
            var str = args[0];
            args[0] = str[.. (str.Length - 7)];
            break;
        default:
            Console.WriteLine("wrong input of key after files name");
            break;      
    }
    
}