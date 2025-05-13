/*  Created by: 
 *  Project: Brick Breaker
 *  Date: 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Reflection;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, escapeKeyDown, spaceKeyDown;

        // Game values
        public static int screenHeight;
        public static int screenWidth;
        Random randGen = new Random();
        bool bounce = true;
        int BulletBallTimer = 0;
        public static int lives = 3;
        public static int points = 0;
        public static int level;
        public static int layerCount;
        public float scaleX;
        public float scaleY;


        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        List<Bricks> bricks = new List<Bricks>();
        List<Powers> powerUps = new List<Powers>();


        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);

        List<Arrow> arrows = new List<Arrow>();
        #endregion

        public GameScreen()
        {
            scaleX = 1068 / this.Width;
            scaleY = 678 / this.Height;
            InitializeComponent();
            Dock = DockStyle.Fill;
            screenHeight = this.Height;
            screenWidth = this.Width;

            OnStart();
        }


        public void OnStart()
        {
            //set life counter
            lives = 3;
            level = 1;

            //make bricks 
            CreateBricks();

            //set all button presses to false.
            leftArrowDown = rightArrowDown = escapeKeyDown = spaceKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = Convert.ToInt32 (30 * scaleX);
            int paddleHeight = Convert.ToInt32 (7 * scaleY);
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = 10 + paddleHeight;
            int paddleSpeed = Convert.ToInt32 (3 * scaleX);
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = Convert.ToInt32 (paddleHeight + 20*scaleY);

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = Convert.ToInt32(10 * scaleY);
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    escapeKeyDown = true;
                    Application.Exit();
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    if (gameTimer.Enabled == false)
                    {
                        gameTimer.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Escape:
                    escapeKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //ball.OverallSpeedLimit();

            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            // Move ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this,scaleX,scaleY);

            // Check for ball hitting top of screen
            if (ball.TopCollision(this))
            {
                lives--;
                

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = paddle.y + ball.size;

                if (lives == 0)
                {
                    OnEnd();
                }

                gameTimer.Enabled = false;
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            //ball brick collision
            CheckBallBrickCollision();

            //move powers 
            foreach (Powers p in powerUps)
            {
                p.Move();
            }

            //apply powerups
            for (int i = powerUps.Count - 1; i >= 0; i--)
            {
                Powers p = powerUps[i];


                if (paddle.x < p.x + p.size && paddle.x + paddle.width > p.x &&
                    paddle.y < p.y + p.size && paddle.y + paddle.height > p.y)
                {
                    ApplyPowerUps(p.type);
                    powerUps.RemoveAt(i);

                }
            }


            if (bounce == false)
            {
                BulletBallTimer--;
                if (BulletBallTimer <= 0) bounce = true;

            }

            //redraw the screen
            liveslabel.Text = $"{lives}";
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        private void CheckBallBrickCollision()
        {

            for (int i = 0; i < bricks.Count; i++)
            {

                if (ball.Collision(bricks[i].Rect))
                {
                    BricksDestroyed(i);
                    bricks.RemoveAt(i);
                    if (bounce == true)
                    {
                        ball.ySpeed = ball.ySpeed * -1;
                    }
                }
            }
        }

        public void BricksDestroyed(int i)
        {


            if (randGen.Next(100) < 30)
            {
                string[] powerUpTypes = { "ExtraLife", "SpeedBoost", "BigPaddle", "Bullet" };
                string selectedPowerUp = powerUpTypes[randGen.Next(powerUpTypes.Length)];

                powerUps.Add(new Powers(bricks[i].Rect.X + Bricks.width / 2, bricks[i].Rect.Y, selectedPowerUp));
            }
        }

        public void CreateBricks()
        {
            bricks.Clear(); // Clear existing bricks to prevent duplication

            int brickWidth = (int)(Bricks.width * scaleX);
            int brickHeight = (int)(Bricks.height * scaleY);
            int brickSpacing = (int)(Bricks.spacing * scaleX);

           

            for (int row = 0; row < Bricks.numRows; row++)
            {
                for (int col = 0; col < Bricks.numCols; col++)
                {
                    int x = (col * (brickWidth + brickSpacing) + 2) + this.Width/4;
                    int y = (this.Height - 50) + row * (brickHeight + brickSpacing);

                    bricks.Add(new Bricks(x, y, brickWidth, brickHeight));
                }
            }
        }


        public void ApplyPowerUps(string type)
        {
            if (type == "ExtraLife") lives++;
            else if (type == "SpeedBoost") paddle.speed += 2;
            else if (type == "BigPaddle") paddle.width += 40;
            else if (type == "Bullet")
            {
                bounce = false;
                BulletBallTimer = 200;
            }

        }
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {

           // e.Graphics.ScaleTransform(scaleX, scaleY);

            // Draw paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draw power-ups
            foreach (Powers p in powerUps)
            {
                e.Graphics.FillEllipse(p.color, p.x, p.y, p.size, p.size);
            }

            // Draw ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            // Draw bricks using resource image
            foreach (Bricks b in bricks)
            {
                e.Graphics.DrawImage(Properties.Resources.Cobblestone, b.Rect);
            }
        }

    }
}
