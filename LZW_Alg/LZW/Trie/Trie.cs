namespace LZW;
public class Trie
{
    public class Node
    {
        public bool Terminal { get; set; }
        public Dictionary<byte, Node> Children { get; set; }
        public int Number { get; set; }
        public int Code {get; set;}

        public Node()
        {
            Terminal = false;
            Children = new Dictionary<byte, Node>();
            Number = 0;
            Code = 0;
        }
    }
    public Node root;
    public int Size { get; set; }

    public Trie()
    {
        Size = 0;
        root = new Node();
    }

    public bool Add(List<byte> trybits, int code)
    {
        Node CheckNode = root;

        for (int i = 0; i < trybits.Count; ++i)
        {
            if (CheckNode.Children.ContainsKey(trybits[i]))
            {
                CheckNode = CheckNode.Children[trybits[i]];
            }
            else
            {
                CheckNode.Children.Add(trybits[i], new Node());
                Size++;
                CheckNode = CheckNode.Children[trybits[i]];
            }

            CheckNode.Number++;
        }
        CheckNode.Code=code;

        if (!CheckNode.Terminal) 
        { 
            CheckNode.Terminal = true; 
            return true; 
        }

        return false;
    }

    public bool Contains(List<byte> trybits)
    {
        Node CheckNode = root;

        for (int i = 0; i < trybits.Count; ++i)
        {
            if (CheckNode.Children.ContainsKey(trybits[i]))
            {
                CheckNode = CheckNode.Children[trybits[i]];
            }
            else 
            { 
                return false; 
            }
        }

        return CheckNode.Terminal;
    }

    public bool Remove(List<byte> trybits)
    {
        Node CheckNode = root;

        if (Contains(trybits))
        {
            for (int i = 0; i < trybits.Count; ++i)
            {
                if (CheckNode.Children[trybits[i]].Number > 1)
                {
                    CheckNode = CheckNode.Children[trybits[i]];
                    CheckNode.Number--;
                }
                else 
                { 
                    CheckNode.Children.Remove(trybits[i]); Size -= (trybits.Count - i); 
                    return true; 
                }
            }

            return true;
        }

        return false;
    }

    public int HowManyStartsWithPrefix(List<byte> trybits)
    {
        Node CheckNode = root;

        for (int i = 0; i < trybits.Count; ++i)
        {

            if (CheckNode.Children.ContainsKey(trybits[i]))
            {
                CheckNode = CheckNode.Children[trybits[i]];
            }
            else 
            {
                return 0; 
            }
        }

        return CheckNode.Number;
    }

    public int ValueOfKey(List<byte> trybits) 
    {
            Node CheckNode = root;

            for (int i = 0; i<trybits.Count; ++i)
            {
                if (CheckNode.Children.ContainsKey(trybits[i]))
                {
                    CheckNode = CheckNode.Children[trybits[i]];
                }
                else{
                    return -1;
                }
            }
            
            return CheckNode.Code;
    }
}
