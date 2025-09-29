using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace SnakeGameTest
{
    public partial class GameplayForm : Form
    {
        private const int SegmentSize = 20; // Change this value to make the snake and food bigger
        private List<Point> snake = new List<Point>();
        private Point food;
        private int score = 0;
        private Timer gameTimer = new Timer();
        private enum Direction { Up, Down, Left, Right };
        private Direction currentDirection = Direction.Right;

        public GameplayForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            gamePanel.Paint += new PaintEventHandler(UpdateGraphics);
            gameTimer.Interval = 100; // Set the interval as needed
            gameTimer.Tick += new EventHandler(UpdateGame);
            gameTimer.Start();

            StartGame();
        }

        private void StartGame()
        {
            snake.Clear();
            snake.Add(new Point(10, 10)); // Initial position of the snake
            GenerateFood();
            score = 0;
            lblScore.Text = "Score: " + score;
            gameTimer.Start();
        }

        private void GenerateFood()
        {
            Random rand = new Random();
            bool validPosition = false;

            while (!validPosition)
            {
                food = new Point(rand.Next(gamePanel.Width / SegmentSize), rand.Next(gamePanel.Height / SegmentSize));
                validPosition = true;

                // Check if the food position is on the snake
                foreach (Point segment in snake)
                {
                    if (food == segment)
                    {
                        validPosition = false;
                        break;
                    }
                }
            }
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            // Move the snake
            Point head = snake[0];
            Point newHead = head;

            switch (currentDirection)
            {
                case Direction.Up:
                    newHead.Y -= 1;
                    break;
                case Direction.Down:
                    newHead.Y += 1;
                    break;
                case Direction.Left:
                    newHead.X -= 1;
                    break;
                case Direction.Right:
                    newHead.X += 1;
                    break;
            }

            // Check for collisions with the walls
            if (newHead.X < 0 || newHead.Y < 0 || newHead.X >= gamePanel.Width / SegmentSize || newHead.Y >= gamePanel.Height / SegmentSize)
            {
                GameOver();
                return;
            }

            // Check for collisions with itself
            if (snake.Contains(newHead))
            {
                GameOver();
                return;
            }

            // Check for collisions with food
            if (newHead == food)
            {
                snake.Insert(0, newHead); // Add new head instead of adding to the end
                GenerateFood();
                score += 10;
                lblScore.Text = "Score: " + score;
            }
            else
            {
                snake.Insert(0, newHead); // Add new head
                snake.RemoveAt(snake.Count - 1); // Remove the tail
            }

            gamePanel.Invalidate();
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            // Draw the snake
            foreach (Point segment in snake)
            {
                canvas.FillRectangle(Brushes.Green, new Rectangle(segment.X * SegmentSize, segment.Y * SegmentSize, SegmentSize, SegmentSize));
            }

            // Draw the food
            canvas.FillRectangle(Brushes.Red, new Rectangle(food.X * SegmentSize, food.Y * SegmentSize, SegmentSize, SegmentSize));
        }

        private void GameOver()
        {
            gameTimer.Stop();
            // Create an instance of the new form
            GameOverForm gameOverForm = new GameOverForm(score); // Pass the score to the new form if needed
            gameOverForm.Show(); // Show the new form
            this.Hide(); // Close the current form
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (currentDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
                case Keys.Down:
                    if (currentDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
                case Keys.Left:
                    if (currentDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case Keys.Right:
                    if (currentDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
            }
        }

        private void GameplayForm_Load(object sender, EventArgs e)
        {

        }
    }
}