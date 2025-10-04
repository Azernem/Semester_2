namespace Exceptions;
public class EmptyListException: Exception
{
    public EmptyListException()
    {

    }
    public EmptyListException(string message): base(message)
    {

    }
}
public class RepeatOfValueException: Exception
{
    public RepeatOfValueException()
    {

    }
    public RepeatOfValueException(string message): base(message)
    {

    }
}
public class ChangeToExistingElementException: Exception
{
    public ChangeToExistingElementException()
    {

    }
    public ChangeToExistingElementException(string message): base(message)
    {

    }
}