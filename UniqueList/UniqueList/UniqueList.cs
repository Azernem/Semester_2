namespace UniqueList;
using Exceptions;
public class UniqueList: UsualList
{
    public bool ValueAtList(int value)
    {
        if (Count == 0) {throw new EmptyListException("empty list");};
        Element current_Element = start;
        for (int i=0; i<Count; ++i)
        {
            if (current_Element.Value ==value) {return true;};
            current_Element = current_Element.Next;
        }
        return false;
    }
    public void Adding_Value(int value, int index)
    {
        if (ValueAtList(value))
        {
            throw new RepeatOfValueException("element is repeated with one of the list elements");
        }
        base.Adding_Value(value, index);
    }
    public void Remove(int index)
    {
        base.Remove(index);
    }
    public void Change_Value(int value, int index)
    {
        ValueAtList(value);
        if (ValueAtList(value))
        {
            throw new ChangeToExistingElementException("cannot change a value to an existing one in the list");
        }
        base.Change_Value(value, index);
    }
}