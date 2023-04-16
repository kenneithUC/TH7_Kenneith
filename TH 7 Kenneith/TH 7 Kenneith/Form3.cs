using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH_7_Kenneith
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Form1 form1 = new Form1();
        private void Form3_Load(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            this.Controls.Add(form1);
            form1.Show();
            
        }
    }
}
