// <copyright file="Program.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Data;

internal static class Programm
{
    public static void Main(string[] argc)
    {
        /*string way = "Edges_of_Routers_.txt";*/
        string way = "Routers/Edges_of_Routers_.txt";
        string toWay = "Routers/Result_File.txt" ;
        var createexpression = new GraphToExpression();
        createexpression.CreateExpression(way, toWay);
    }
}