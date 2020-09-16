using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderCodeSelector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbTest.Text.Contains("L： 山推"))
                MessageBox.Show("L： 山推");
            if(this.cbTest.Text.Contains("D：德工"))
                MessageBox.Show("D：德工");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.cbTest.Items.Add("增加项");
        }
    }
}
