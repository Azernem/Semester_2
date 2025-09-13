namespace BWT;
public static class BWT
{
    private static void SortString(string[] array)
    {
        for (int i = 0; i < array.Length; ++i)
        {
            for (int j = 0; j < array.Length - 1; ++j)
            {
                if (String.Compare(array[j], array[j + 1]) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    public static string DirectBWT()
    {
        Console.WriteLine("Write the string for BWT algoritm: ");
        string s = Console.ReadLine();
        s+='$';
        string[] array = new string[s.Length];

        for (int i = 0; i < s.Length; ++i)
        {
            array[i] = s.Substring(i, s.Length - i);
        }

        SortString(array);
        string s2 = "";
        s = "$" + s;

        for (int i = 0; i < array.Length; ++i)
        {
            for (int z = 0; z < s.Length; ++z)
            {
                if (array[i] == s.Substring(z, s.Length - z))
                {
                    s2 += s[z - 1];
                }
            }
        }

        return s2;
    }

    public static string InverseBWT(string s2, int indexOfEnd)
    {
        int[] ARR = new int[123];

        for (int i = 0; i < s2.Length; ++i)
        {
            ARR[Convert.ToByte(s2[i])] ++;
        }

        int[] a = new int[123];
        int j = Convert.ToByte('$');
        a[j] = 1;

        for (int i = j + 1; i < a.Length; ++i)
        {
            if (ARR[i] != 0)
            {
                a[i] = a[j] + ARR[j];
                j = i;
            }
        }

        int[] p = new int[s2.Length];

        for (int i = 0; i < p.Length; ++i)
        {
            p[i] = a[Convert.ToByte(s2[i])];
            a[Convert.ToByte(s2[i])] ++;
        }

        string s3 = "$";
        int k = indexOfEnd;

        for (int i = 0; i < p.Length; ++i)
        {
            p[i] --;
        }

        for (int i = 0; i < s2.Length - 1; ++i)
        {
            s3 = s2[p[k]] + s3;
            k = p[k];
        }
        
        return s3;
    }
}
