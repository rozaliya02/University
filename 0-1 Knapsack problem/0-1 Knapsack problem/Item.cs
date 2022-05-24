using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0_1_Knapsack_problem
{
    class Item
    {
        private string Name { get; }
        private int Value { get; }
        private int Weight { get; }
        private bool IsChosen { get; set; }

        public Item(string name, int value, int weight , bool isChosen)
        {
            Name = name; 
            Value = value;
            Weight = weight;
            IsChosen = isChosen;
        }

        public string GetName()
        {
            return Name;
        }
        public int GetValue()
        {
            return Value;
        }
        public int GetWeight()
        {
            return Weight;
        }
        public bool GetIsChosen()
        {
            return IsChosen;
        }
        public void GetIsChosen(bool isChosen)
        {
            IsChosen = isChosen;
        }
    }
}
