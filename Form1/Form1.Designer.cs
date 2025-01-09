using System;
using System.Drawing;
using System.Windows.Forms;

namespace Form1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label problemLabel;
        private TextBox answerTextBox;
        private Button submitButton;
        private Button resetButton;
        private Label scoreLabel;
        private Label timerLabel;
        private Label levelLabel;  
        private Timer timer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.problemLabel = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            this.problemLabel.AutoSize = true;
            this.problemLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.problemLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.problemLabel.Location = new System.Drawing.Point(126, 610);
            this.problemLabel.Name = "problemLabel";
            this.problemLabel.Size = new System.Drawing.Size(128, 45);
            this.problemLabel.TabIndex = 0;
            this.problemLabel.Text = "Solve: ";

            this.answerTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.answerTextBox.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.answerTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.answerTextBox.Location = new System.Drawing.Point(69, 671);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(250, 42);
            this.answerTextBox.TabIndex = 1;
            this.answerTextBox.TextChanged += new System.EventHandler(this.answerTextBox_TextChanged);
            this.answerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerTextBox_KeyDown);

            this.submitButton.AutoSize = true;
            this.submitButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.submitButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(333, 674);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 39);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.submitButton.MouseEnter += new System.EventHandler(this.submitButton_MouseEnter);
            this.submitButton.MouseLeave += new System.EventHandler(this.submitButton_MouseLeave);

            this.resetButton.AutoSize = true;
            this.resetButton.BackColor = System.Drawing.Color.IndianRed;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(443, 674);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(86, 39);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            this.resetButton.MouseEnter += new System.EventHandler(this.resetButton_MouseEnter);
            this.resetButton.MouseLeave += new System.EventHandler(this.resetButton_MouseLeave);

            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.scoreLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.scoreLabel.Location = new System.Drawing.Point(63, 734);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(193, 35);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.timerLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.timerLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.timerLabel.Location = new System.Drawing.Point(213, 734);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(200, 35);
            this.timerLabel.TabIndex = 5;
            this.timerLabel.Text = "Time Left: 30";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.levelLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.levelLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.levelLabel.Location = new System.Drawing.Point(413, 734);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(120, 35);
            this.levelLabel.TabIndex = 6;
            this.levelLabel.Text = "Level: 1";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(600, 880);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.problemLabel);
            this.Name = "Form1";
            this.Text = "Math Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void submitButton_MouseEnter(object sender, EventArgs e)
        {
            submitButton.BackColor = Color.DarkGreen;  
            submitButton.ForeColor = Color.White;  
        }

        private void submitButton_MouseLeave(object sender, EventArgs e)
        {
            submitButton.BackColor = Color.MediumSeaGreen;  
            submitButton.ForeColor = Color.White;  
        }

        private void resetButton_MouseEnter(object sender, EventArgs e)
        {
            resetButton.BackColor = Color.DarkRed;  
        }

        private void resetButton_MouseLeave(object sender, EventArgs e)
        {
            resetButton.BackColor = Color.IndianRed;  
        }
    }
}
