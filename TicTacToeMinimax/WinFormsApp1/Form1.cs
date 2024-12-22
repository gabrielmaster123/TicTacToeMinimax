using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Game game;
        private Minimax mm;
        public Form1(Game gameInstance)
        {
            InitializeComponent();
            game = gameInstance;
            mm = new Minimax();
            InitializeGameButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void turn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point move = mm.BestMove(game);
            //if(game.CheckWinner() == null)
            //{
            //    game.GameArr = new string[3, 3];
            //}
            //else
            //{
                game.GameArr[move.X, move.Y] = game.Turn();
            //}
            UpdateButtons();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            game.GameArr = new string[3, 3];
            UpdateButtons();
        }
    }
}
