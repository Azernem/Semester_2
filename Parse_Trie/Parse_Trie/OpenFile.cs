/// <summary>
/// class that openes file
/// </summary>
public class OpenFile
{
    /// <summary>
    /// read expression for calculate
    /// </summary>
    /// <param name="way">name of file</param>
    /// <returns>expression of file</returns>
    /// <exception cref="FileException">exception existing file</exception>
    public string ReadExpression(string way)
    {
        if (!(File.Exists(way)))
        {
            throw new FileException("no such file");
        }
        string s = File.ReadAllText(way);
        return s;
    }
}
/// <summary>
/// class that returnes new tries
/// </summary>
public class ExpessionToNewTries
{
    /*""*/
    /// <summary>
    /// returnes new tries
    /// </summary>
    /// <param name="s">expression</param>
    /// <returns><new tries/returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public string[] NewExpressions(string s)
    {
        int number;
        (int CountLeftScope, int CountRightScope) = (0, 0);
        bool flag = false;
        int ind=0;
        s = s.Substring(3, s.Length- 4);
        if ((int.TryParse(Convert.ToString(s[0]), out number)) && (s[2]=='(' || int.TryParse(Convert.ToString(s[2]), out number)))
        {
            return SplitByIndex(s, 1);
        }
        else{
            for (int i =0; i<s.Length; ++i)
            {
                if (s[i]=='(') 
                {
                    CountLeftScope++;
                }
                if (s[i] == ')') 
                {
                    CountRightScope++;
                } 
                if (CountLeftScope == CountRightScope) 
                {
                    ind = i+1; flag = true; break;
                }
            }
            if (flag == true && (s[ind+1] == '(' || int.TryParse(Convert.ToString(s[ind+1]), out number)) )
            {
                return SplitByIndex(s, ind);
            }
            else 
            {
                throw new IncorrectException("incorrect trie");
            }

        }  
    }
    /// <summary>
    /// method that splites expression to left and right
    /// </summary>
    /// <param name="s">expression</param>
    /// <param name="ind">index of chapter left and right nodes</param>
    /// <returns>new splitted expression</returns>
    public string[] SplitByIndex(string s, int ind)
    {
        string[] a = new string[] {s.Substring(0, ind ), s.Substring(ind+1, s.Length - 1 - ind)};
        return a;
    }

}