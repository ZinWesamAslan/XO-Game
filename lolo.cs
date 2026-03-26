using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace XO
{
    public partial class lolo : UserControl
    {
        
        public lolo()
        {
            InitializeComponent();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            rbPlayFirst1.Text = tbPlayer1Name.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendToBack(); 
        }

        private void pbTrunOff_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

    }
}
