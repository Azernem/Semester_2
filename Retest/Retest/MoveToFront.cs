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

    /// <summary>
    ///  ethod that gets english alphabet.
    /// </summary>
    public static void CreateSymbolTable()
    {
        string letters = "abcdefghijklmnopqrstuvwxyz";

        for (int i = 0; i < letters.Length; ++i)
        {
            alphabet[i] = letters[i];
        }
    }

    /// <summary>
    /// method that performs encoding.
    /// </summary>
    /// <param name="input">input string.</param>
    /// <returns>encodedSequence.</returns>
    public static int[] Encode(string input)
    {
        result = new List<int>();
        CreateSymbolTable();

        if (input.Length == 0)
        {
            throw new ArgumentNullException("string cannot be empty for encoding");
        }

        foreach (char symbol in input.ToLower())
        {
            if (IsLetter(symbol))
            {
                var index = Array.IndexOf(alphabet, symbol);
                result.Add(index);
                MoveToStart(index);
            }
            else
            {
                throw new ArgumentException("incorrect symbol");
            }
        }

        foreach (int n in result)
        {
            Console.WriteLine(n);
        }

        return result.ToArray();
    }

    private static bool IsLetter(char symbol) => alphabet.Any(element => (element == symbol));

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