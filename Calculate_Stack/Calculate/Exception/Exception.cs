namespace Stack_Calculator;
public class ExceptionDivideByZero: Exception
{
    public ExceptionDivideByZero(string message): base(message)
    {
        
    }
}

public class ExceptionEmptyStack: Exception
{
    public ExceptionEmptyStack(string message): base(message)
    {
        
    }
}

public class ExceptionIncorrectInput: Exception
{
    public ExceptionIncorrectInput(string message): base(message)
    {
        
    }
}

public class ExceptionDoesntExistResult: Exception
{
    public ExceptionDoesntExistResult(string message): base(message)
    {
        
    }
}


