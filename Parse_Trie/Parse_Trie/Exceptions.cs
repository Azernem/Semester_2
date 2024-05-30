// <copyright file="Exceptions.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// class of FileException.
/// </summary>
namespace Parse_Trie;
public class FileException: Exception
{
    public FileException(string message): base(message)
    {
    }
}
public class IncorrectException: Exception
{
    public IncorrectException(string message): base(message)
    {
        
    }
}
public class DivisionByZeroException: Exception
{
    public DivisionByZeroException(string message): base(message)
    {
        
    }
}