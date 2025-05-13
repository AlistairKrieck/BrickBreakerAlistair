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

        // Paddle and Ball objects
        public static Paddle paddle;
        public static Ball ball;

        // list of all blocks for current level
        List<Bricks> bricks = new List<Bricks>();
        List<Powers> powerUps = new List<Powers>();


        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);

        Image brickImage = Properties.Resources.Cobblestone;

        List<Projectile> projectiles = new List<Projectile>();
        List<Arrow> arrows = new List<Arrow>();
        List<ZombieSpit> spits = new List<ZombieSpit>();

        List<MobBlock> mobs = new List<MobBlock>();
        //List<Skeleton> skeletons = new List<Skeleton>();
        //List<Zombie> zombies = new List<Zombie>();
        List<Creeper> creepers = new List<Creeper>();

        int levelMobCount = 3;

        public static int arrowHeight = 20;
        public static int arrowWidth = 5;
        public static int arrowSpeed = 15;

        public static int spitSpeed = 15;
        public static int spitDiameter = 20;
        #endregion

        public GameScreen()
        {
            InitializeComponent();

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

            // spawn mobs
            SpawnMobs();


            //set all button presses to false.
            leftArrowDown = rightArrowDown = escapeKeyDown = spaceKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 60;
            int paddleHeight = 10;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = 10 + paddleHeight;
            int paddleSpeed = 16; //TODO CHANGE BACK TO 8
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = paddle.height + 20;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            // start the game engine loop
            gameTimer.Enabled = true;

            // spawn a test arrow
            //arrows.Add(new Arrow(30, this.Height - 25, 20, 5, 25));
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

            foreach (MobBlock m in mobs)
            {
                if (randGen.Next(0, 100) < 1)
                {
                    if (m.mobType == "skeleton")
                    {
                        Skeleton s = (Skeleton)m;
                        projectiles.Add(s.AttackPlayer());
                    }

                    if (m.mobType == "zombie")
                    {
                        Zombie z = (Zombie)m;
                        projectiles.Add(z.AttackPlayer());
                    }
                }
            }

            // Move all arrows and delete them on collision with player or top wall
            foreach (Projectile p in projectiles)
            {
                // Update the arrows position if it has not hit the player or the top wall
                if (!p.PaddleCollision(paddle) && !p.TopCollision())
                {
                    // Update position and break the loop so the arrow is not deleted until one of those conditions is true
                    p.Move();
                    break;
                }

                else if (p.PaddleCollision(paddle))
                {
                    //Remove a life from the player if an arrow hits them
                    lives--;

                    if (lives == 0)
                    {
                        OnEnd();
                    }
                }

                // Remove the arrow if it has reached its target
                projectiles.Remove(p);
                return;
            }


            // Check for collision with top and side walls
            ball.WallCollision(this);

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

            // Check if ball collides with a mob and kill it if so
            KillMobs();

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

        private void KillMobs()
        {
            for (int i = 0; i < mobs.Count; i++)
            {
                if (ball.Collision(mobs[i].Rect))
                {
                    mobs.RemoveAt(i);
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
            int totalHeight = Bricks.numRows * (Bricks.height + Bricks.spacing);

            for (int row = 0; row < Bricks.numRows; row++)
            {
                for (int col = 0; col < Bricks.numCols; col++)
                {
                    int x = col * (Bricks.width + Bricks.spacing) + 2; // Offset from side
                    int y = this.Height - totalHeight + row * (Bricks.height + Bricks.spacing) - 10; // Spawn from bottom

                    bricks.Add(new Bricks(x, y, Bricks.width, Bricks.height));
                }
            }
        }

        public void ApplyPowerUps(string type)
        {
            if (type == "ExtraLife") lives++;
            else if (type == "SpeedBoost") paddle.speed += 2;
            else if (type == "BigPaddle") paddle.width += 20;
            else if (type == "Bullet")
            {
                bounce = false;
                BulletBallTimer = 200;

            }

        }

        public void SpawnMobs()
        {
            MobBlock m;

            int totalHeight = Bricks.numRows * (Bricks.height + Bricks.spacing);

            for (int i = 0; i < levelMobCount; i++)
            {
                int x = randGen.Next(0, Bricks.numCols) * (Bricks.width + Bricks.spacing) + 2;
                int y = this.Height - totalHeight + randGen.Next(0, Bricks.numRows) * (Bricks.height + Bricks.spacing) - 10;

                while (mobs.Any(s => s.x == x && s.y == y))
                {
                    x = randGen.Next(0, Bricks.numCols) * (Bricks.width + Bricks.spacing) + 2;
                    y = this.Height - totalHeight + randGen.Next(0, Bricks.numRows) * (Bricks.height + Bricks.spacing) - 10;
                }


                int mob = randGen.Next(0, MobBlock.mobTypes.Length);

                switch (MobBlock.mobTypes[mob])
                {
                    case "skeleton":
                        m = new Skeleton(x, y);
                        break;

                    case "zombie":
                        m = new Zombie(x, y);
                        break;

                    default:
                        m = new Skeleton(x, y);
                        break;
                }

                mobs.Add(m);
            }
        }


        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // draws power ups
            foreach (Powers p in powerUps)
            {
                e.Graphics.FillEllipse(p.color, p.x, p.y, p.size, p.size);
            }

            // Draws Blocks
            foreach (Bricks b in bricks)
            {
                e.Graphics.DrawImage(Properties.Resources.Cobblestone, b.Rect);
            }

            // Draw projectiles launched at player
            foreach (Projectile proj in projectiles)
            {
                if (proj.image == "arrow")
                {
                    Arrow a = (Arrow)proj;
                    a.GetArrowBody();

                    e.Graphics.FillPolygon(new SolidBrush(proj.color), a.points);
                }

                if (proj.image == "slimeball")
                {
                    ZombieSpit s = (ZombieSpit)proj;
                    e.Graphics.FillEllipse(new SolidBrush(s.color), s.x, s.y, s.diameter, s.diameter);
                }
            }

            // Draw mobs over their blocks
            foreach (MobBlock m in mobs)
            {
                e.Graphics.FillRectangle(new SolidBrush(m.mobColor), m.Rect);
            }

            // Draws ball
            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
