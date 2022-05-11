using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesh_Table
{
    class Program
    {

        struct KeyValuePair
        {
            public string word;
            public int count;

            public override string ToString()
            {
                return $"{word} : {count}";
            }
        }

        class KeyValuePairListItem
        {
            public KeyValuePairListItem next;
            public KeyValuePair value;

            public override string ToString()
            {
                var text = value.ToString();

                var current = next;
                while(current != null)
                {
                    text += "; " + current.value.ToString();
                    current = current.next;
                }

                return text;
            }
        }

        class WFT
        {
            private KeyValuePairListItem[] _keyValuePairListItems = new KeyValuePairListItem[100];

            private int HashFunc(string key)
            {
                var v = 0;

                for (int i = 0; i < key.Length; i++)
                    v = (v * 32 + key[i] % _keyValuePairListItems.Length);

                return v;               
            }

            public void Add(string word)
            {
                var position = HashFunc(word);

                var current = _keyValuePairListItems[position];
                while (current != null && current.value.word != word)
                    current = current.next;

                if (current == null)
                {
                    var nli = new KeyValuePairListItem
                    {
                        value = new KeyValuePair { word = word, count = 1 },
                        next = _keyValuePairListItems[position]
                    };

                    _keyValuePairListItems[position] = nli;
                }
                else
                    current.value.count++;
            }

            public override string ToString()
            {
                var text =  "";

                for (int i = 0; i < _keyValuePairListItems.Length; i++)
                    text += $"{i}\t{_keyValuePairListItems[i]}{Environment.NewLine}";

                return text;
               
            }
        }
        static void Main(string[] args)
        {
            var r = new Random(1);

            var words = new string[100];

            for (int w = 0; w < words.Length; w++)
                words[w] = new string(new char[] { (char)r.Next('a', 'z'), (char)r.Next('A', 'Z') });

            WFT wft = new WFT();

            foreach (var word in words)
            {
                wft.Add(word);
            }
          
                

            Console.WriteLine(wft);
     
        }
    }
}
