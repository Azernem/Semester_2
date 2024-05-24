// <copyright file="MoveToFront.cs" company="NematMusaev"> 
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Retest;

/// <summary>
/// class that executes the algorithm Move To Front.
/// </summary>
public static class MoveToFront
{
    /// <summary>
    /// result of program.
    /// </summary>
    /// <returns>encodedSequence. </returns>
    private static List<int> result = new();

    private static char[] alphabet = new char[26];

    public static void CreateSymbolTable()
    {
        string letters = "abcdefghijklmnopqrstuvwxyz";

        for (int i = 0; i < letters.Length; ++i)
        {
            alphabet[i] = letters[i];
        }
    }
    
    public static int[] Encode(string input)
    {
        CreateSymbolTable();

        if (input.Length == 0)
        {
            throw new ArgumentNullException("string cannot be empty for encoding");
        }

        foreach (char symbol in input)
        {
            for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == symbol)
                    {
                        result.Add(i);
                        MoveToStart(i);
                        break;
                    }
                }
        }

        return result.ToArray();
    }

    private static void MoveToStart(int index)
    {
        var currentLetter = alphabet[index];

        for (int i = index; i > 0; --i)
        {
            alphabet[i] = alphabet[i - 1];
        }

        alphabet[0] = currentLetter;
    }
}