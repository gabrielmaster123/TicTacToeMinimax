﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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

            try
            {
                game.GameArr[move.X, move.Y] = game.Turn();
            } catch
            {
                turnLabel.Text = "No more moves Possible";
            }
            

            UpdateButtons();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            game.GameArr = new string[3, 3];
            UpdateButtons();
        }

        private void getValue_Click(object sender, EventArgs e)
        {
            valueLabel.Text = mm.getValue(game).ToString();
            UpdateButtons();
        }

        private void Value_Click(object sender, EventArgs e)
        {

        }
    }
}
