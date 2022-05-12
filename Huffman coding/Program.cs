using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_coding
{
    class HuffmanNode
    {
        public char Letter { get; set; }
        public int Freq { get; set; }

        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public override string ToString()
        {
            return Letter.ToString();
        }
    }
    class Program
    {

        static void Insert(List<HuffmanNode> list, HuffmanNode node)
        {
            for (int i = 0; i < list.Count; i++)
                if(list[i].Freq >= node.Freq)
                {
                    list.Insert(i, node);
                    return;
                }
            list.Add(node);
        }

        static string Encode(HuffmanNode root, char letter)
        {
            if (root == null)
                return null;
            if (root.Letter == letter)
                return "";

            string result;

            if ((result = Encode(root.Left, letter)) != null)
                return result + "0";
            else
            if ((result = Encode(root.Right, letter)) != null)
                return result + "1";

            return result;

        }

        static string HuffmanCode(string text)
        {
            var letterFreqs = new int[256];

            for (int c = 0; c < text.Length; c++)
                letterFreqs[c]++;

            var list = new List<HuffmanNode>(letterFreqs.Length);

            for (int i = 0; i < letterFreqs.Length; i++)
                if (letterFreqs[i] > 0)
                    Insert(
                        list,
                        new HuffmanNode
                        {
                            Letter = (char)i,
                            Freq = letterFreqs[i]
                        });

            while (list.Count > 1)
            {
                var node = new HuffmanNode
                {
                    Left = list[0],
                    Right = list[1],
                    Freq = list[0].Freq + list[1].Freq
                };

                list.RemoveAt(0);
                list.RemoveAt(0);

                Insert(list, node);
            }

            var result = "";
            for (int c = 0; c < text.Length; c++)
                result += $"{text[c]}: {Encode(list[0], text[c])}{Environment.NewLine}";
            return result;
         }
        static void Main(string[] args)
        {

            Console.Write("Enter text: ");
            var text = Console.ReadLine();

            Console.WriteLine(HuffmanCode(text));
            Console.ReadLine();
        }
    }
}
