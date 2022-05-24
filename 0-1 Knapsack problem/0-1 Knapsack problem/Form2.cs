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
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public DataGridView dataGridView;
        public Label Label1;
        public Label Label2;
        public Label Label3;


        public Form2()
        {
            InitializeComponent();
            instance = this;
            dataGridView = dataGridView2;
            Label1 = label3;
            Label2 = label5;
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
