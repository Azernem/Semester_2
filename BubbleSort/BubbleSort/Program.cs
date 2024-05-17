namespace BubbleSort;
/// <summary>
/// 
/// </summary>
/// <typeparam name="T">general type</typeparam> <summary>
/// class  of inte
/// </summary>
/// <typeparam name="T">general type</typeparam>

public class BubbleSort<T>
{
    /// <summary>
    /// method which makes bubble sort of list of object
    /// </summary>
    /// <param name="list"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public List<T> Bubble<T>(IList<T> list, IComparer<T> comparer)
    {
    for (int i = 0; i < list.Count; ++i)
    {
        for (int j = 1; j < list.Count - i; ++j)
        {
            if (comparer.Compare(list[j-1], list[j]>0))
            {
                (list[j - 1], list[j]) = (list[j], list[j-1]);
            }
        }
    }
    return list;
    }
}
class Program
{
    static void Main(string[] args)
    {

    }
}

