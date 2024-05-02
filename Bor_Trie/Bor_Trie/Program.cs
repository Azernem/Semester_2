
namespace BorTrie
{
    public class Trie
    {
        public class Node
        {
            public bool Terminal { get; set; }
            public Dictionary<char, Node> Children { get; set; }
            public int Number { get; set; }
            public Node()
            {
                Terminal = false;
                Children = new Dictionary<char, Node>();
                Number = 0;
            }
        }

        public Node root;
        public int Size { get; set; }
        public Trie()
        {
            Size = 0;
            root = new Node();
        }
        public bool Add(string s)
        {
            Node ChekNode = root;
            for (int i = 0; i < s.Length; ++i)
            {
                if (ChekNode.Children.ContainsKey(s[i]))
                {
                    ChekNode = ChekNode.Children[s[i]];
                }
                else
                {
                    ChekNode.Children.Add(s[i], new Node());
                    Size++;
                    ChekNode = ChekNode.Children[s[i]];
                }
                ChekNode.Number++;
            }
            if (!(ChekNode.Terminal)) 
            { 
                ChekNode.Terminal = true; return true; 
            }
            return false;
        }
        public bool Contains(string s)
        {
            Node ChekNode = root;
            for (int i = 0; i < s.Length; ++i)
            {
                if (ChekNode.Children.ContainsKey(s[i]))
                {
                    ChekNode = ChekNode.Children[s[i]];
                }
                else 
                { 
                    return false; 
                }
            }
            return ChekNode.Terminal;
        }

        public bool Remove(string s)
        {
            Node ChekNode = root;
            if (Contains(s))
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    if (ChekNode.Children[s[i]].Number > 1)
                    {
                        ChekNode = ChekNode.Children[s[i]];
                        ChekNode.Number--;
                    }
                    else 
                    { 
                        ChekNode.Children.Remove(s[i]); Size -= (s.Length - i); return true; 
                    }
                }
                return true;
            }
            return false;
        }

        public int HowManyStartsWithPrefix(string prefix)
        {
            Node ChekNode = root;
            for (int i = 0; i < prefix.Length; ++i)
            {
                if (ChekNode.Children.ContainsKey(prefix[i]))
                {
                    ChekNode = ChekNode.Children[prefix[i]];
                }
                else 
                { 
                    return 0; 
                }
            }
            return ChekNode.Number;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // вводим строки через пробел
            string[] mas = s.Split(' ');
            var Trie = new Trie();
            foreach (string element in mas)
            {
                Console.WriteLine($"HowManyStartsWithPrefix:{Trie.HowManyStartsWithPrefix(element)},  Contains:{Trie.Contains(element)},  Remove:{Trie.Remove(element)}, Add:{Trie.Add(element)}");
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
    }
}