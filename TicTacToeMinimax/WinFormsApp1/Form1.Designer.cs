namespace WinFormsApp1
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
            makeAITurn = new Button();
            button1 = new Button();
            getValue = new Button();
            valueLabel = new Label();
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
            // makeAITurn
            // 
            makeAITurn.Location = new Point(617, 67);
            makeAITurn.Name = "makeAITurn";
            makeAITurn.Size = new Size(75, 23);
            makeAITurn.TabIndex = 1;
            makeAITurn.Text = "AI Turn";
            makeAITurn.UseVisualStyleBackColor = true;
            makeAITurn.Click += button1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(617, 96);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // getValue
            // 
            getValue.Location = new Point(616, 136);
            getValue.Name = "getValue";
            getValue.Size = new Size(75, 23);
            getValue.TabIndex = 3;
            getValue.Text = "GetValue";
            getValue.UseVisualStyleBackColor = true;
            getValue.Click += getValue_Click;
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Location = new Point(618, 175);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(35, 15);
            valueLabel.TabIndex = 4;
            valueLabel.Text = "Value";
            valueLabel.Click += Value_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(valueLabel);
            Controls.Add(getValue);
            Controls.Add(button1);
            Controls.Add(makeAITurn);
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

            if (game.GameArr[row, col] == null &&
                game.CheckWinner() == null)
            {
                game.GameArr[row, col] = game.Turn();
            }

            if (game.CheckWinner() == null)
            {
                turnLabel.Text = game.Turn();

            }
            else if (game.CheckWinner() == "Tie!")
            {
                turnLabel.Text = "It's a Tie!";
            }
            else
            {
                turnLabel.Text = "The winner is: " + game.CheckWinner();
            }
            UpdateButtons();
        }

        private Label turnLabel;
        private Button makeAITurn;
        private Button button1;
        private Button getValue;
        private Label valueLabel;
    }
}