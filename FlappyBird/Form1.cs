using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        int pipeSeed = 8;
        int gravity = 7;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipesdown.Left -= pipeSeed;
            PipeTop.Left -= pipeSeed;
            ScoreText.Text = "Score: " + score;

            if (pipesdown.Left < -150)
            {
                pipesdown.Left = 800;
                score++;
            }
            if (PipeTop.Left < -180)
            {
                PipeTop.Left = 950;
                score++;
            }

            if (FlappyBird.Bounds.IntersectsWith(pipesdown.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(ground.Bounds) || FlappyBird.Top < -25
                )
            {
                endGame();
            }


            if (score > 5)
            {
                pipeSeed = 15;
            }


        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void endGame()
        {
            GameTimer.Stop();
            ScoreText.Text += "Game over!!!";
        }


    }

}
