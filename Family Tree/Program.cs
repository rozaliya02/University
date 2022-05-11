using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{

    class Node
    {
        public char Name { get; set; }
        public Node Mother { get; set; }
        public Node Father { get; set; }
    }
    class Program
    {
        public static Node FindNode(Node root, char name)
        {
            if (root == null)
                return null;

            if (root.Name == name)
                return root;

            return
                FindNode(root.Father, name) ??
                FindNode(root.Mother, name);            
        }

        public static int Depth(IEnumerable<Node> nodes, int depth)
        {
            var nextLevelNodes = new List<Node>();
            foreach(var node in nodes)
            {
                if (node.Father != null)
                    nextLevelNodes.Add(node.Father);

                if (node.Mother != null)
                    nextLevelNodes.Add(node.Mother);
            }

            return nextLevelNodes.Count() == 0
                ? depth
                :Depth(nextLevelNodes, depth + 1);
        }

        public static void DisplayTree(IEnumerable<Node> nodes, int level)
        {
            var spaces = Math.Pow(2, level) - 1;

            var nextLevelNodes = new List<Node>();

            foreach (var node in nodes)
            {    
                    nextLevelNodes.Add(node?.Father);            
                    nextLevelNodes.Add(node?.Mother);
            }

            if (level > 0)
                DisplayTree(nextLevelNodes, level - 1);

            foreach(var node in nodes)
            {
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");

                Console.Write($"{node?.Name.ToString() ?? " "}");
                Console.Write(" ");

                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
              
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var root = new Node
            {
                Name = 'a'
            };

            while(true)
            {
                Console.Clear();

                var depth = Depth(new[] { root }, 0);
                DisplayTree(new[] { root }, depth);
                Console.WriteLine();
                Console.Write("a - add parents; f - find parents; q - quit");
          


                switch(Console.ReadKey().KeyChar)
                {
                    case 'a':
                        {
                            Console.Clear();
                            Console.WriteLine("Enter name:");

                            var current = FindNode(root, Console.ReadKey().KeyChar);

                            if(current != null)
                            {
                                Console.Clear();
                                Console.Write("Enter father's name:");
                                current.Father = new Node
                                {
                                    Name = Console.ReadKey().KeyChar
                                };

                                Console.Clear();
                                Console.Write("Enter mother's name:");
                                current.Mother = new Node
                                {
                                    Name = Console.ReadKey().KeyChar
                                };
                            }
                        }
                        break;

                    case 'f':
                        {
                            Console.Clear();
                            Console.WriteLine("Enter name:");

                            var current = FindNode(root, Console.ReadKey().KeyChar);

                            if(current != null)
                            {
                                Console.Clear();
                                Console.WriteLine($"Father: {current.Father?.Name}");
                                Console.WriteLine($"Mother: {current.Mother?.Name}");

                                Console.ReadLine();
                            }
                        }
                            
                        break;

                    case 'q':
                        
                        break;
                }
            }
        }
    }
}
