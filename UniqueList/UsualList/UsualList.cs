namespace UniqueList;
public class UsualList
{
    public int Count {get; private set;}
    public Element start;
    public class Element
    {
        public int Value {get; set;}
        public Element Next {get; set;}
        public Element(int value, Element next)
        {
            Value = value;
            Next = next;
        }
    }
    public void Adding_Value(int value, int index)
    {
        if (index>Count) {throw new IndexOutOfRangeException();};
        Count++;
        if (index==0) {start = new Element(value, start); return;};
        Element current_Element = start;
        Element previous_Element = start;
        for (int i=0; i<index; ++i)
        {
            previous_Element = current_Element;
            current_Element = current_Element.Next;
        }
        previous_Element.Next = new Element(value, current_Element);
    }

    public void Remove(int index)
    {
        if (index>=Count) {throw new IndexOutOfRangeException();};
        Count--;
        if (index==0) {start = start.Next; return ;};
        Element current_Element = start;
        Element previous_Element = current_Element;
        for (int i=0; i<index; ++i)
        {
            previous_Element = current_Element;
            current_Element = current_Element.Next;
        }
        previous_Element = new Element(previous_Element.Value, current_Element.Next);
    }

    public void Change_Value(int value, int index)
    {
        if (index>=Count) {throw new IndexOutOfRangeException();};
        Element current_Element = start;
        Element previous_Element = current_Element;
        for (int i=0; i<index; ++i)
        {
            previous_Element = current_Element;
            current_Element = current_Element.Next;
        }
        current_Element.Value = value;
    }
    
}
