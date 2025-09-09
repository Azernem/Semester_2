namespace Stack_Calculator;

interface ICalculator
{
    void Push(float t);

    float Pop();
}
public class CalculatorOnList : ICalculator
{
    private float element1;
    private float element2;
    List<float> list = new();

    public void Push(float t)
    {
        list.Add(t);
    }

    public float Pop()
    {
        if (list.Count==0)
        {
            throw new ExceptionEmptyStack("empty stack");
        }

        var lastelement = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);

        return lastelement;
    }

    public float GetResultByList(string z)
    {
        string[] s = z.Split(' ');
        int number;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == " ")
            {
                continue;
            }
            else if (s[i] == "+")
            {
                element1 = Pop();
                element2 = Pop();
                Push(element1 + element2);
            }
            else if (s[i] == "-")
            {
                element1 = Pop();
                element2 = Pop();
                Push(element2 - element1);
            }
            else if (s[i] == "/")
            {
                element1 = Pop();

                if (Math.Abs(element1) < 1e-7) 
                {
                     throw  new ExceptionDivideByZero("cant divide by zero"); 
                }

                element2 = Pop();
                Push(element2 / element1);
            }
            else if (s[i] == "*")
            {
                element1 = Pop();
                element2 = Pop();
                Push(element1 * element2);
            }
            else if (int.TryParse(Convert.ToString(s[i]), out number))
            {
                Push(number);
            }
            else 
            {
                throw new ExceptionIncorrectInput("incorrect input: inter float number or operand ");
            }
        }
        if (list.Count!=1)
        {
            throw new ExceptionDoesntExistResult("result doesnt exist");
        }

        return Pop();
    }
}

public class CalculatorOnArray: ICalculator
{
    private float element1;
    private float element2;
    private int ArrayResize = 4;
    private int MaxIndex = -1;
    float[] array = new float[4];

    public void Push(float t)
    {
        MaxIndex++;

        if (MaxIndex >= ArrayResize)
        {
            ArrayResize *= 2;
            Array.Resize(ref array, ArrayResize);
        }

        array[MaxIndex] = t;
    }
    public float Pop()
    {
        MaxIndex--;

        if (MaxIndex < -1)
        {
            throw new ExceptionEmptyStack("empty stack");
        }

        return array[MaxIndex+1];
    }
    public float GetResultByArray(string z)
    {
        string[] s = z.Split(' ');
        int number;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == " ")
            {
                continue;
            }
            else if (s[i] == "+")
            {
                element1 = Pop();
                element2 = Pop();
                Push(element1 + element2);
            }
            else if (s[i] == "-")
            {
                element1 = Pop();
                element2 = Pop();
                Push(element2 - element1);
            }
            else if (s[i] == "/")
            {
                element1 = Pop();

                if (Math.Abs(element1) < 1e-7) 
                {  
                    throw new ExceptionDivideByZero("cant divide by zero");
                }

                element2 = Pop();
                Push(element2 / element1);
            }
            else if (s[i] == "*")
            {
                element1 = Pop();
                element2 = Pop();
                Push(element1 * element2);
            }
            else if (int.TryParse(Convert.ToString(s[i]), out number))
            {
                Push(number);
            }
            else 
            {
                throw new ExceptionIncorrectInput("incorrect input: inter float number or operand ");
            }
        }
        if (MaxIndex!=0)
        {
            throw new ExceptionDoesntExistResult("result doesnt exist");
        }

        return Pop();
    }
}

internal class Program
{ 
static void Main(string[] args)
    {
        string s = Console.ReadLine();
        var c1 = new CalculatorOnList();
        var c2 = new CalculatorOnArray();
        Console.WriteLine(c1.GetResultByList(s));
        Console.WriteLine(c2.GetResultByArray(s));
        
    }
}