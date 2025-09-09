/// <summary>
/// class that organises a ptiority  queue
/// </summary>
/// <typeparam name="T"> general type</typeparam>
public class Queue<T>
{
    public Element start;
    public bool CheckToZero => start == null;
    public class Element
    {
        public T Value {get; set;}
        public int Priority { get; set; }
        public Element Next {get; set;}
        public Element(T value, Element next, int priority)
        {
            Value = value;
            Next = next;
            Priority = priority;
        }
    }
    public void Enqueu(T value, int priority)
    {
        if (start ==null) {start = new Element(value, start, priority); return ;};
        Element current_Element = start;
        Element previous_Element = start;
        while (current_Element!=null && current_Element.Priority>=priority)
        {
            previous_Element = current_Element;
            current_Element = current_Element.Next;
        }
        previous_Element.Next = new Element(value, current_Element, priority);
    }
    public T Dequeue()
    {
        if (start==null) {throw new IndexOutOfRangeException();};
        var res = start.Value;
        start = start.Next;
        return res;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var q = new Queue<int>();
        q.Enqueu(2, 1);
        q.Enqueu(4, 2);
        Console.WriteLine(q.Dequeue());

    }
}