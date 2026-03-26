using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Frm1 : Form
    { 

        public Frm1()
        {
            InitializeComponent();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnWatch.Height;
            SidePanel.Top = btnWatch.Top;
            SidePanel.Width = btnWatch.Width;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            SidePanel.Width = btnHome.Width;

        }

        private void btnTops_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTops.Height;
            SidePanel.Top = btnTops.Top;
            SidePanel.Width = btnTops.Width;
        }

        private void btnReadMore_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnReadMore.Height;
            SidePanel.Top = btnReadMore.Top;
            SidePanel.Width = btnReadMore.Width;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnLogOut.Height;
            SidePanel.Top = btnLogOut.Top;
            SidePanel.Width = btnLogOut.Width;
            this.Close();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
        }


    }
}
