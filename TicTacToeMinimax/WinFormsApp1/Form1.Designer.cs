﻿namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            turnLabel = new Label();
            SuspendLayout();
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Location = new Point(617, 49);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(57, 15);
            turnLabel.TabIndex = 0;
            turnLabel.Text = "turnLabel";
            turnLabel.Click += label1_Click_2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(turnLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button[,] buttons = new Button[3, 3];
        private void InitializeGameButtons()
        {
            int buttonSize = 100; // Size of the buttons
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Create a new button
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(buttonSize, buttonSize);
                    buttons[i, j].Location = new Point(100 + j * (buttonSize + 5), 50 + i * (buttonSize + 5));
                    buttons[i, j].Text = "";  // Initial text (empty)
                    buttons[i, j].Click += Button_Click;  // Attach the click event

                    buttons[i, j].Tag = new Point(i, j); // Store the position of the button

                    Controls.Add(buttons[i, j]);  // Add button to the form
                }
            }
        }

        private void UpdateButtons()
        {
            for (int i = 0; i < game.GameArr.GetLength(0); i++)  // Iterate over rows
            {
                for (int j = 0; j < game.GameArr.GetLength(1); j++)  // Iterate over columns
                {
                    // Find the button corresponding to the (i, j) position
                    Button button = buttons[i, j];

                    // Update the button's text based on the value in gameArr
                    if (game.GameArr[i, j] == "X")
                    {
                        button.Text = "X";
                    }
                    else if (game.GameArr[i, j] == "O")
                    {
                        button.Text = "O";
                    }
                    else
                    {
                        button.Text = "";  // If it's an empty space in gameArr
                    }
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            Point position = (Point)clickedButton.Tag; // Retrieve the position
            int row = position.X;  // Row index
            int col = position.Y;  // Column index

            game.GameArr[row, col] = game.Turn(game.GameArr);
            turnLabel.Text = game.Turn(game.GameArr);
            UpdateButtons();
        }

        private Label turnLabel;
    }
}