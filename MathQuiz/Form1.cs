using System;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int timeLeft;
        private int score;
        private int num1, num2;
        private string operation;
        private int correctAnswer;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            // Initially disable buttons until game starts
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;

            label1.Text = "Time: 60";
            label3.Text = "Score: 0";
            label2.Text = "Click Start to begin!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void StartGame()
        {
            score = 0;
            timeLeft = 60;

            // Enable/disable appropriate controls
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            textBox1.Enabled = true;

            // Update labels
            label1.Text = $"Time: {timeLeft}";
            label3.Text = $"Score: {score}";

            // Generate first problem
            GenerateProblem();

            // Start timer
            timer1.Interval = 1000; // 1 second
            timer1.Start();
        }
        private void GenerateProblem()
        {
            // Generate random numbers and operation
            num1 = random.Next(1, 10);
            num2 = random.Next(1, 10);

            // Randomly choose operation
            string[] operations = { "+", "-", "×", "÷" };
            operation = operations[random.Next(operations.Length)];

            // Calculate correct answer
            switch (operation)
            {
                case "+":
                    correctAnswer = num1 + num2;
                    break;
                case "-":
                    correctAnswer = num1 - num2;
                    break;
                case "×":
                    correctAnswer = num1 * num2;
                    break;
                case "÷":
                    // Ensure division problems have integer results
                    correctAnswer = num1;
                    num1 = num1 * num2; // Make dividend a multiple of divisor
                    break;
                }

                 // Display problem
                 label2.Text = $"{num1} {operation} {num2} = ?";

                 // Clear textbox and focus
                textBox1.Clear();
                textBox1.Focus();
                }

        private void button2_Click(object sender, EventArgs e)
        {
                CheckAnswer();
        }
        private void CheckAnswer()
        {
            if (int.TryParse(textBox1.Text, out int userAnswer))
            {
                if (userAnswer == correctAnswer)
                {
                    score++;
                    label3.Text = $"Score: {score}";
                    MessageBox.Show("Correct!", "Math Quiz",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Incorrect! The answer was {correctAnswer}",
                        "Math Quiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Generate next problem automatically after submission
                GenerateProblem();
            }
            else
            {
                MessageBox.Show("Please enter a valid number!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                label1.Text = $"Time: {timeLeft}";
            }
            else
            {
                timer1.Stop();
                EndGame();
            }
        }
        private void EndGame()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;
            button1.Enabled = true;

            MessageBox.Show($"Time's up! Your final score is: {score}",
                "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            label2.Text = "Game Over! Click Start to play again.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if game is running
            if (!timer1.Enabled)
            {
                MessageBox.Show("Please start the game first!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Optional: Check if current problem was attempted
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                DialogResult result = MessageBox.Show("Skip this problem without answering?",
                    "Skip Problem",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                    return;
                }
            }

            // Generate new problem
            GenerateProblem();

            // Update status (optional)
            label2.Text += " (Skipped)";
        }

        private void Form1_Load(object sender, EventArgs e)
             {
            // Initialize game state
            InitializeGame();

            // Set up initial control states
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;

            // Set button texts explicitly
            button1.Text = "&Start";      // Alt+S shortcut
            button2.Text = "&Submit";     // Alt+U shortcut
            button3.Text = "&Next";       // Alt+N shortcut

            // Set label texts
            label1.Text = "Time: 60";
            label2.Text = "Welcome to Math Quiz!";
            label3.Text = "Score: 0";

            // Configure textbox
            textBox1.Text = "";
            textBox1.MaxLength = 4; // Limit answer length

            // Set focus to Start button
            button1.Focus();

            // Optional: Configure form appearance
            this.Text = "Math Quiz Game";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
