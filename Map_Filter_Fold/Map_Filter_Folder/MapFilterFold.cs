namespace MapFilterFold;
/// <summary>
/// class that contains methodes where one of parameters is function
/// </summary>
public class Functions
{
    /// <summary>
    /// delegate to function, referense to function
    /// </summary>
    /// <typeparam name="T">type of type of element supplied to the function</typeparam>
    /// <typeparam name="Tres">type of element called to the function</typeparam>
    /// <param name="value">valгу that converted to Tres type</param>
    /// <returns>converted value with Tres type </returns>
    public delegate Tres F_for_Map<T, Tres>(T value);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">type of elements of current list</typeparam>
    /// <typeparam name="Tres">type of elements of result list</typeparam>
    /// <param name="list_start">current list</param>
    /// <param name="fun">function that convertes element of list with Tres type</param>
    /// <returns>converted list</returns>
    public List<Tres> Map<T, Tres>(List<T> list_start, F_for_Map<T, Tres> fun)
    {
        if (list_start == null)
        {
            throw new ArgumentNullException("empty list");
        }
        List<Tres> result = [];
        for (int i = 0; i<list_start.Count; ++i)
        {
            result.Add(fun(list_start[i]));
        }
        return result;
    } 
    /// <summary>
    /// delegate to function, referense to function
    /// </summary>
    /// <typeparam name="T">type of type of element supplied to the function</typeparam>
    /// <param name="value">element of current list</param>
    /// <returns>boolean to condition</returns>
    public delegate bool F_for_Filter<T>(T value);
    /// <summary>
    /// method that return filtered list
    /// </summary>
    /// <typeparam name="T">type of current list</typeparam>
    /// <param name="list_start"> currrent list</param>
    /// <param name="fun">function that returns boolean to condition on conditional to element of list</param>
    /// <returns>filtered list</returns>
    public List<T> Filter<T>(List<T> list_start, F_for_Filter<T> fun)
    {
        if (list_start == null)
        {
            throw new ArgumentNullException("empty list");
        }
        var res = new List<T>();
        for (int i = 0; i < list_start.Count; ++i)
        {
            if (fun(list_start[i]))
            {
                res.Add(list_start[i]);
            }
        }
        return res;
    }
    public delegate Tres F_for_Fold<T, Tres>(Tres acc, T elem);
    /// <summary>
    /// method that returns a value that changes depending on the elements of the list
    /// </summary>
    /// <typeparam name="T">type of elementes of list</typeparam>
    /// <typeparam name="Tres">type of result</typeparam>
    /// <param name="list">current list</param>
    /// <param name="acc">result</param>
    /// <param name="fun">returnes Tres value</param>
    /// <returns>value acc that depending on elementes of list</returns>
    public Tres Fold<T, Tres>(List<T> list, Tres acc, F_for_Fold<T, Tres> fun)
    {
        if (list == null)
        {
            throw new ArgumentNullException("empty list");
        }
        for (int i = 0; i  < list.Count; ++i)
        {
            acc = fun(acc,  list[i]);
        }
        return acc;
    }
}
