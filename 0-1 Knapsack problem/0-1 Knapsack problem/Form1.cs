using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0_1_Knapsack_problem
{
    public partial class Form1 : Form
    {
        public TextBox itemName;
        public TextBox itemValue;
        public TextBox itemWeight;
        public static Form1 instance;
        int[] weight;
        int[] value;
        string[] ItemName;
        int len;
        public static int KnapsackWeight;
        public static int ItemCount;
        public static int[,] ValuesMatrix;

        List<Item> list = new List<Item>();

       void KnapsackProcess(List<Item> list)
        {
            for (int i = 1; i <= ItemCount; i++)
            {
                for (int j = 1; j <= KnapsackWeight; j++)
                {
                    if (list[i - 1].GetWeight() > j)
                    {
                        ValuesMatrix[i, j] = ValuesMatrix[i - 1, j];
                    }
                    else
                    {
                        ValuesMatrix[i, j] =
                            Math.Max(list[i - 1].GetValue() + ValuesMatrix[i - 1, j - list[i - 1].GetWeight()],
                                ValuesMatrix[i - 1, j]);
                    }
                }
            }
        }

        void PrepareValues(int knapsackWeight)
        {
            for (int i = 0; i <= ItemCount; i++)
            {
                for (int j = 0; j < knapsackWeight; j++)
                {
                    ValuesMatrix[i, j] = 0;
                }
            }
        }

        List<Item> FindChosenItems(List<Item> list)
        {
            int indis = ItemCount;
            int weight = KnapsackWeight;
            while (indis > 0 && weight > 0)
            {
                if (ValuesMatrix[indis, weight] != ValuesMatrix[indis - 1, weight])
                {
                    list[indis - 1].GetIsChosen(true);
                    weight = weight - list[indis - 1].GetWeight();
                }
                indis--;
            }
            return list;
        }

        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            button2.Visible = true;
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Item Name";
            dataGridView1.Columns[1].Name = "Item Value";
            dataGridView1.Columns[2].Name = "Item Weight";
          
            
            getcall();
            dataGridView1.ClearSelection();
        }

        public void getcall()
        {
            try
            {
                string input1 = textBox1.Text;
                ItemName = input1.Split(',').ToArray();
                string input2 = textBox2.Text;
                value = input2.Split(',').Select(Int32.Parse).ToArray();
                string input3 = textBox3.Text;
                weight = input3.Split(',').Select(Int32.Parse).ToArray();

                ItemCount = Convert.ToInt32(textBox5.Text);
                KnapsackWeight = Convert.ToInt32(textBox4.Text);
                label5.Text = KnapsackWeight.ToString();
                len = weight.Length;
                int k = 0;
                while (k < len)
                {
                    dataGridView1.Rows.Add();
                    k++;
                }
                int j = 0;
                while (j < len)
                {
                    dataGridView1.Rows[j].Cells[0].Value = ItemName[j];
                    dataGridView1.Rows[j].Cells[1].Value = weight[j].ToString();
                    dataGridView1.Rows[j].Cells[2].Value = value[j].ToString();

                    j++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure input is correct");
            }
           
        }
      

  

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Write names of Items with ','", textBox1);
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Write value of Items with ','", textBox2);
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Write weight of Items with ','", textBox3);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = new List<Item>();

            Form2 form = new Form2();
            form.Show();

            for (int i = 0; i < ItemCount; i++)
            {
                var name = ItemName[i];
                var ItemWeight = weight[i];
                var ItemValue = value[i];
                var item = new Item(name, ItemValue, ItemWeight, false);
                list.Add(item);
            }
            ValuesMatrix = new int[ItemCount + 1, KnapsackWeight + 1];

            PrepareValues(KnapsackWeight);

            KnapsackProcess(list);

            int W = KnapsackWeight + 1;
            Form2.instance.dataGridView.ColumnCount = W;
            int c = 0;
            while (c < W)
            {
                Form2.instance.dataGridView.Columns[c].Name = "";
                c++;
            }

            for (int i = 0; i <= ItemCount; i++)
            {
                Form2.instance.dataGridView.Rows.Add();
                for(int j = 0; j <= KnapsackWeight; j++)
                {
                    Form2.instance.dataGridView.Rows[i].Cells[j].Value = ValuesMatrix[i, j];
                }
            }

            
            Form2.instance.Label1.Text = ValuesMatrix[ItemCount, KnapsackWeight].ToString();
            var chosenList = FindChosenItems(list);
            for (int i = 1; i <= chosenList.Count; i++)
            {
                if (chosenList[i - 1].GetIsChosen())
                {
                    Form2.instance.Label2.Text += "Item:" + chosenList[i - 1].GetName() + "-" + "Value:" + chosenList[i - 1].GetValue() + " - " + "Weight: " + chosenList[i - 1].GetWeight() + ("\n");
                    
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("In the 0/1 Knapsack problem, we are given a set of items," +
                " each with a weight and a value, and we need to determine the number " +
                "of each item to include in a collection so that the total weight" +
                " is less than or equal to a given limit and the total value is as large as possible.");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
