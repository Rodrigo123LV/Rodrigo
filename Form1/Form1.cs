using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int score = 0;
        private int timeLeft = 30; 
        private string currentProblem;
        private double correctAnswer;
        private int level = 1; 
        private int wrongAnswersInARow = 0; 

        private Label fallingProblemLabel; 
        private Timer fallingTimer; 
        private int fallingSpeed = 1; 

        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fallingTimer = new Timer();
            fallingTimer.Interval = 50; 
            fallingTimer.Tick += new EventHandler(FallingTimer_Tick);
            StartNewProblem(); 
        }

        private void StartNewProblem()
        {
            timer.Stop(); 
            fallingTimer.Stop(); 
            if (fallingProblemLabel != null)
            {
                this.Controls.Remove(fallingProblemLabel); 
            }

            currentProblem = GenerateMathProblem();
            correctAnswer = EvaluateMathProblem(currentProblem);

            fallingProblemLabel = new Label();
            fallingProblemLabel.Text = currentProblem;
            fallingProblemLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            fallingProblemLabel.Size = new Size(150, 40); 
            fallingProblemLabel.Location = new Point(random.Next(0, this.ClientSize.Width - 150), 0); 
            fallingProblemLabel.ForeColor = Color.DarkSlateGray;
            this.Controls.Add(fallingProblemLabel);

            answerTextBox.Clear();
            answerTextBox.Focus();
            timeLeft = 30;
            timerLabel.Text = $"Time Left: {timeLeft}";
            levelLabel.Text = $"Level: {level}"; 
            timer.Start(); 
            fallingTimer.Start(); 
        }

        private string GenerateMathProblem()
        {
            int rangeAdditionSubtraction = level * 10; 
            int rangeMultiplicationDivision = 1 + (level / 2); 

            int num1, num2;
            char[] operations;

            if (level <= 3)
            {
                operations = new char[] { '+', '-' }; 
            }
            else if (level <= 6)
            {
                operations = new char[] { '+', '-', '*' }; 
            }
            else
            {
                operations = new char[] { '+', '-', '*', '/' }; 
            }

            char operation = operations[random.Next(operations.Length)];

            if (operation == '+' || operation == '-')
            {
                num1 = random.Next(1, rangeAdditionSubtraction + 1);
                num2 = random.Next(1, rangeAdditionSubtraction + 1);
            }
            else if (operation == '*')
            {
                num1 = random.Next(1, rangeMultiplicationDivision + 1);
                num2 = random.Next(1, rangeMultiplicationDivision + 1);
            }
            else 
            {
                num1 = random.Next(1, rangeMultiplicationDivision + 1);
                num2 = random.Next(1, rangeMultiplicationDivision + 1);
                while (num2 == 0 || !IsFiniteDecimal((double)num1 / num2))
                {
                    num2 = random.Next(1, rangeMultiplicationDivision + 1);
                }
            }

            string problem = $"{num1} {operation} {num2}";

            for (int i = 0; i < level / 2; i++)
            {
                operation = operations[random.Next(operations.Length)];
                int nextNum = random.Next(1, rangeAdditionSubtraction + 1);
                problem = $"{problem} {operation} {nextNum}";

                if (level >= 12 && random.Next(0, 2) == 0)
                {
                    problem = $"({problem})";
                }
            }

            return problem;
        }

        private bool IsFiniteDecimal(double result)
        {
            return (result * 100) % 1 == 0;
        }

        private double EvaluateMathProblem(string problem)
        {
            try
            {
                DataTable table = new DataTable();
                double result = Convert.ToDouble(table.Compute(problem, string.Empty));
                return Math.Round(result, 2); 
            }
            catch
            {
                return 0; 
            }
        }

        private void FallingTimer_Tick(object sender, EventArgs e)
        {
            if (fallingProblemLabel != null)
            {
                fallingProblemLabel.Top += fallingSpeed;

                if (fallingProblemLabel.Bottom >= this.ClientSize.Height)
                {
                    fallingTimer.Stop();
                    timer.Stop();
                    MessageBox.Show($"You missed it! The correct answer was {correctAnswer}.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetButton_Click(sender, e);
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ProcessAnswer();
        }

        private void ProcessAnswer()
        {
            if (double.TryParse(answerTextBox.Text, out double userAnswer))
            {
                timer.Stop();
                fallingTimer.Stop();

                if (Math.Abs(userAnswer - correctAnswer) < 0.01)
                {
                    score += 10;
                    wrongAnswersInARow = 0;
                    MessageBox.Show("Correct!", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    score -= 5;
                    wrongAnswersInARow++;
                    MessageBox.Show($"Incorrect! The correct answer was {correctAnswer}", "Incorrect Answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (wrongAnswersInARow >= 3)
                    {
                        MessageBox.Show("You have answered incorrectly 3 times in a row. Game Over!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton_Click(this, EventArgs.Empty);
                        return;
                    }
                }

                scoreLabel.Text = $"Score: {score}";
                level = (score / 50) + 1;
                levelLabel.Text = $"Level: {level}";

                StartNewProblem();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            timerLabel.Text = $"Time Left: {timeLeft}";

            if (timeLeft == 0)
            {
                timer.Stop();
                fallingTimer.Stop();
                MessageBox.Show("Time's up!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ProcessAnswer();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            score = 0;
            level = 1;
            wrongAnswersInARow = 0;
            scoreLabel.Text = $"Score: {score}";
            levelLabel.Text = $"Level: {level}";
            timeLeft = 30;
            timerLabel.Text = $"Time Left: {timeLeft}";
            timer.Stop();
            fallingTimer.Stop();
            if (fallingProblemLabel != null)
            {
                this.Controls.Remove(fallingProblemLabel);
                fallingProblemLabel = null;
            }
            StartNewProblem();
        }

        private void answerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitButton_Click(sender, e);
            }
        }
        private void answerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(answerTextBox.Text, out _))
            {
                answerTextBox.BackColor = Color.WhiteSmoke; 
            }
            else
            {
                answerTextBox.BackColor = Color.White; 
            }
        }
    }
}
