namespace Bor_Trie
{
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
        public bool Add(List<byte> try_bits, int code)
        {
            Node Chek_Node = root;
            for (int i = 0; i < try_bits.Count; ++i)
            {
                if (Chek_Node.Children.ContainsKey(try_bits[i]))
                {
                    Chek_Node = Chek_Node.Children[try_bits[i]];
                }
                else
                {
                    Chek_Node.Children.Add(try_bits[i], new Node());
                    Size++;
                    Chek_Node = Chek_Node.Children[try_bits[i]];
                }
                Chek_Node.Number++;
            }
            Chek_Node.Code=code;
            if (Chek_Node.Terminal == false) { Chek_Node.Terminal = true; return true; }
            return false;
        }
        public bool Contains(List<byte> try_bits)
        {
            Node Chek_Node = root;
            for (int i = 0; i < try_bits.Count; ++i)
            {
                if (Chek_Node.Children.ContainsKey(try_bits[i]))
                {
                    Chek_Node = Chek_Node.Children[try_bits[i]];
                }
                else { return false; }
            }
            return Chek_Node.Terminal;
        }

        public bool Remove(List<byte> try_bits)
        {
            Node Chek_Node = root;
            if (Contains(try_bits))
            {
                for (int i = 0; i < try_bits.Count; ++i)
                {
                    if (Chek_Node.Children[try_bits[i]].Number > 1)
                    {
                        Chek_Node = Chek_Node.Children[try_bits[i]];
                        Chek_Node.Number--;
                    }
                    else { Chek_Node.Children.Remove(try_bits[i]); Size -= (try_bits.Count - i); return true; }
                }
                return true;
            }
            return false;
        }

        public int HowManyStartsWithPrefix(List<byte> try_bits)
        {
            Node Chek_Node = root;
            for (int i = 0; i < try_bits.Count; ++i)
            {
                if (Chek_Node.Children.ContainsKey(try_bits[i]))
                {
                    Chek_Node = Chek_Node.Children[try_bits[i]];
                }
                else { return 0; }
            }
            return Chek_Node.Number;
        }
        public int ValueOfKey(List<byte> try_bits) 
        {
             Node Chek_Node = root;
             for (int i = 0; i<try_bits.Count; ++i)
             {
                if (Chek_Node.Children.ContainsKey(try_bits[i]))
                {
                    Chek_Node = Chek_Node.Children[try_bits[i]];
                }
                else{
                    return -1;
                }
             }
             return Chek_Node.Code;
        }
    }

    /*internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // вводим строки через пробел
            string[] mas = s.Split(' ');
            Trie Trie = new Trie();
            foreach (string element in mas)
            {
                Console.WriteLine($"HowManyStartsWithPrefix:{Trie.HowManyStartsWithPrefix(element)},  Contains:{Trie.Contains(element)},  Remove:{Trie.Remove(element)}, Add:{Trie.Add(element)}");
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
    }*/
}