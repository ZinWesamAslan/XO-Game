using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XO.Properties;

namespace XO
{
    public partial class koko : UserControl
    {

        int ReminingMatches = 5;
        int Player1WinTimes = 0;
        int Player2WinTimes = 0;
        int Player1ScoreToTest = 0;
        int Player2ScoreToTest = 0;
        char Turn = '1';
        char XorO = 'X';

        public void ResetAllPicture()
        {
            pb0.Image = null;
            pb1.Image = null;
            pb2.Image = null;
            pb3.Image = null;
            pb4.Image = null;
            pb5.Image = null;
            pb6.Image = null;
            pb7.Image = null;
            pb8.Image = null;
        }

        public void DisableAllPicture()
        {
            pb0.Enabled = false;
            pb1.Enabled = false;
            pb2.Enabled = false;
            pb3.Enabled = false;
            pb4.Enabled = false;
            pb5.Enabled = false;
            pb6.Enabled = false;
            pb7.Enabled = false;
            pb8.Enabled = false;
        }

        public void EnableAllPicture()
        {
            pb0.Enabled = true;
            pb1.Enabled = true;
            pb2.Enabled = true;
            pb3.Enabled = true;
            pb4.Enabled = true;
            pb5.Enabled = true;
            pb6.Enabled = true;
            pb7.Enabled = true;
            pb8.Enabled = true;
        }

        public void SetPictureOfTheWinner()
        {
            if (Player1WinTimes > Player2WinTimes)
            {
                pbWinnerPicture.Image = Resources.DefaultMan;
            }
            else if (Player1WinTimes < Player2WinTimes)
            {
                pbWinnerPicture.Image = Resources.DefaultWoman;
            }
            else if (Player1WinTimes == Player2WinTimes)
            {
                pbWinnerPicture.Image = Image.FromFile(@"C:\Users\USER\Pictures\Images1\Pen.png");
            }
            DisableAllPicture();
            btnRestart.Enabled = false;
        }

        public bool AnyOneWin()
        {
            int[] result = { 7, 56, 448 , 73, 146, 292, 84, 273 };

            for (int i = 0 ; i < 8;i++)
            {
                if((result[i] & Player1ScoreToTest) == result[i])
                {
                    Player1WinTimes++;
                    lblRWinTimes1.Text = Player1WinTimes.ToString();
                    return true;
                }
                if ((result[i]& Player2ScoreToTest) == result[i])
                {
                    Player2WinTimes++;
                    lblRWinTimes2.Text = Player2WinTimes.ToString();
                    return true;
                }
            }

            return false;
        }

        public bool Draw()
        {
            if (pb0.Image != null && pb1.Image != null &&
                pb2.Image != null && pb3.Image != null &&
                pb4.Image != null && pb5.Image != null &&
                pb6.Image != null && pb7.Image != null &&
                pb8.Image != null
                )
            {
                return true;
            }
            return false;
        }
            public void SetPicture(PictureBox sender)
            {
            if (sender.Image != null)
            {
                MessageBox.Show("this Square is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if(Turn == '1')
                {
                    if(XorO == 'X')
                    {
                        sender.Image = Resources.close;
                        XorO = 'O';

                    }
                    else
                    {
                        sender.Image = Resources.circle_ring;
                        XorO = 'X';
                    }
                    lblTurnName.Text = "Player2";
                    pbTurnName.Image = Resources.DefaultWoman;
                    pbTurnXorO.Image = Resources.circle_ring;
                    Turn = '2';
                    Player1ScoreToTest += Convert.ToInt32(sender.Tag);
                }
                else if(Turn == '2')
                {
                    if (XorO == 'X')
                    {
                        sender.Image = Resources.close;
                        XorO = 'O';
                    }
                    else
                    {
                        sender.Image = Resources.circle_ring;
                        XorO = 'X';
                    }
                    lblTurnName.Text = "Player1";
                    pbTurnName.Image = Resources.DefaultMan;
                    pbTurnXorO.Image = Resources.close;
                    Turn = '1';
                    Player2ScoreToTest += Convert.ToInt32(sender.Tag);
                }
            }


            if (AnyOneWin())
            {
                if (Turn == '1')
                {
                    MessageBox.Show("Player2 Is The Winner", "Wow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Player1 Is The Winner", "Wow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReminingMatches--;
                lblRemainingMatches.Text = ReminingMatches.ToString();
                
                if (ReminingMatches==0)
                {
                    SetPictureOfTheWinner();
                }
                Player1ScoreToTest = 0;
                Player2ScoreToTest = 0;
                Turn = '1';
                XorO = 'X';
                pbTurnXorO.Image = Resources.close;
                pbTurnName.Image = Resources.DefaultMan;
                lblTurnName.Text = "Player1";

                ResetAllPicture();
            }
            else if(Draw())
            {
                MessageBox.Show("Draw", "Wow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReminingMatches--; 
                lblRemainingMatches.Text= ReminingMatches.ToString();
                if (ReminingMatches == 0)
                {
                    SetPictureOfTheWinner();
                }
                Player1ScoreToTest = 0;
                Player2ScoreToTest = 0;
                Turn = '1';
                XorO = 'X';
                pbTurnXorO.Image = Resources.close;
                pbTurnName.Image = Resources.DefaultMan;
                lblTurnName.Text = "Player1";
                ResetAllPicture();
            }
        }

        public koko()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            ReminingMatches = 5;
            Player1WinTimes = 0;
            Player2WinTimes = 0;
            Player1ScoreToTest = 0;
            Player2ScoreToTest = 0;
            Turn = '1';
            XorO = 'X';
            pbTurnXorO.Image = Resources.close;
            pbTurnName.Image = Resources.DefaultMan;
            lblTurnName.Text = "Player1";

            lblRWinTimes1.Text = "0";
            lblRWinTimes2.Text = "0";
            lblRemainingMatches.Text = "5";

            pbWinnerPicture.Image = null;

            ResetAllPicture();
            EnableAllPicture();
            btnRestart.Enabled = true;

            SendToBack();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Player1ScoreToTest = 0;
            Player2ScoreToTest = 0;
            Turn = '1';
            XorO = 'X';
            pbTurnXorO.Image = Resources.close;
            pbTurnName.Image = Resources.DefaultMan;
            lblTurnName.Text = "Player1";

            ResetAllPicture() ;
        }

        private void pb0_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb5_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb6_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb7_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }

        private void pb8_Click(object sender, EventArgs e)
        {
            SetPicture((PictureBox)sender);
        }
    }
}
