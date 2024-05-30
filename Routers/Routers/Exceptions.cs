// <copyright file="Exceptions.cs" company="NematMusaev">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
public class NoSuchPathException: Exception
{
    public NoSuchPathException(string message): base(message) 
    {
        
    }
}
public class NoEdgeException: Exception
{
    public NoEdgeException(string message): base(message) 
    {
    }
}

public class IncorrectExpressionException: Exception
{
    public IncorrectExpressionException(string message): base(message) 
    {
    }
}



