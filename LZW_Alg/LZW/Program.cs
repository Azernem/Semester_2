using LZW;
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
            float ratioOfCompOrigin = OpenFile.Compress(args[0]);
            Console.WriteLine($"ratio between comp.file and origin.file = {ratioOfCompOrigin}.");
            break;
        case "-u":
            OpenFile.Uncompress(args[0]);
            break;
        default:
            Console.WriteLine("wrong input of key after files name");
            break;      
    }
    
}