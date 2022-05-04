using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_
{
    class Contact
    {
        public string Name { get; set; }

        public string Num { get; set; }
    }

    class Phonebook
    {
        private Contact[] _contacts = new Contact[100];
        private int _used;

        public void Add(string name, string num)
        {
            _contacts[_used++] = new Contact
            {
                Name = name,
                Num = num
            };
        }


        public void Insert(string name, string num)
        {
            var contact = new Contact
            {
                Name = name,
                Num = num
            };

            int i = 0;
            for (; i < _used; i++)
                if (string.Compare(name, _contacts[i].Name) > 0)
                    break;

            for (int k = _used - 1; k >= i; k--)
                _contacts[k + 1] = _contacts[k];

            _contacts[i] = contact;
            _used++;
        }
        public Contact Find(string name)
        {
            for (int i = 0; i < _used; i++)

                if (_contacts[i].Name == name)
                    return _contacts[i];

            return null;
        }

        public Contact FindBin(string name)
        {
            var l = 0;
            var r = _used - 1;
            while (l <= r)
            {
                var m = (l + r) / 2;
                var compare = string.Compare(name, _contacts[m].Name);
                if (compare < 0)
                    r = m - 1;
                else

                if (compare > 0)
                    l = m + 1;
                else
                    return _contacts[m];
            }

            return null;
        }
        class Program
        {
            static void Main(string[] args)
            {
                var phonebook = new Phonebook();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("a - Add; f - Find; q - Quit");

                    var command = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (command)
                    {
                        case 'a':
                            {
                                Console.WriteLine("ADD");
                                Console.Write("Enter name:");
                                var name = Console.ReadLine();

                                Console.Write("Enter number:");
                                var num = Console.ReadLine();

                                phonebook.Add(name, num);
                            }
                            break;
                        case 'f':
                            {
                                Console.WriteLine("FIND");
                                Console.Write("Enter name:");
                                var name = Console.ReadLine();

                                var contact = phonebook.FindBin(name);
                                if (contact != null)
                                    Console.WriteLine($"{contact.Name}'s num:{contact.Num}");

                                else
                                    Console.WriteLine("Contact not found.");

                                Console.ReadLine();
                            }
                            break;

                        case 'q':
                            return;
                    }
                }

            }
        }
    }
}
