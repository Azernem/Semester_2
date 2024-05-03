using System.Data;

internal static class Programm
{
    public static void Main(string[] argc)
    {
        /*string way = "Edges_of_Routers_.txt";*/
        string way = "Routers/Edges_of_Routers_.txt";
        string toWay = "Routers/Result_File.txt" ;
        var creategraph = new CreateGraph();
        var Graph = creategraph.GetGraph(way);
        var createexpression = new GraphToExpression();
        createexpression.CreateExpression(toWay, Graph);
    }
}