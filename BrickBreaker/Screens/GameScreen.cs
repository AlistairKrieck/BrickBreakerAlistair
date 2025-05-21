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
        //TODO
        /*
         * New block images
         * UI design
         * Powerups come from ores
         * Level switching
         * (High)score tracking and saving
         * Blaze mob
         * Damage indicator on blocks
         * Sound effects and bg music
         * 
         */
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, escapeKeyDown, spaceKeyDown, tabKeyDown;

        // Game values
        public static int screenHeight;
        public static int screenWidth;

        Random randGen = new Random();
        public int direction;

        bool bounce = true;
        int BulletBallTimer = 0;
        public static int lives = 3;
        public static int points = 0;

        public static string[] levels = new string[3] { "level1", "level2", "level3" };
        int level;


        // Paddle and Ball objects
        public static Paddle paddle;
        public static Ball ball;

        public static Dictionary<string, Image> brickImages = new Dictionary<string, Image>()
        {
             { "grass", Properties.Resources.grassBlock },
             { "dirt", Properties.Resources.dirtBlock },
             { "stone", Properties.Resources.stoneBlock },
             { "andesite", Properties.Resources.andesiteBlock },
             { "granite", Properties.Resources.graniteBlock },
             { "coal", Properties.Resources.coalOreBlock },
             { "iron", Properties.Resources.ironOreBlock },
             { "copper", Properties.Resources.copperOreBlock },
             { "deepslate", Properties.Resources.deepslateBlock },
             { "deepslateCoal", Properties.Resources.deepslateCoalOreBlock },
             { "deepslateDiamond", Properties.Resources.deepslateDiamondOreBlock },
             { "deepslateEmerald", Properties.Resources.deepslateEmeraldOreBlock },
             { "deepslateGold", Properties.Resources.deepslateGoldOreBlock },
             { "deepslateIron", Properties.Resources.deepslateIronOreBlock },
             { "deepslateLapis", Properties.Resources.deepslateLapisOreBlock },
             { "deepslateRedstone", Properties.Resources.deepslateRedstoneOreBlock },
             { "skeleton", Properties.Resources.skeletonEnemyImage },
             { "zombie", Properties.Resources.zombieEnemyImage },
             { "ghastPlayer", Properties.Resources.ghastPlayer }
        };

        List<Powers> powerUps = new List<Powers>();

        List<Bricks> bricks = new List<Bricks>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);


        List<Projectile> projectiles = new List<Projectile>();


        int levelMobCount = 3;

        public static int arrowHeight = 20;
        public static int arrowWidth = 5;
        public static int arrowSpeed = 5;

        public static int spitSpeed = 4;
        public static int spitDiameter = 20;

        LevelLoader levelLoader = new LevelLoader();
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            screenHeight = this.Height;
            screenWidth = this.Width;

            OnStart();

            // Load level 0
            level = 1;
            LoadLevel(level);
        }


        public void OnStart()
        {
            //set life counter
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = escapeKeyDown = spaceKeyDown = tabKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 60;
            int paddleHeight = 10;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = 10 + paddleHeight;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = paddle.height + 20;

            // Creates a new ball
            int xSpeed = 0;
            int ySpeed = 3;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            bricks.Clear();
            powerUps.Clear();
            projectiles.Clear();
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
                case Keys.Tab:
                    tabKeyDown = true;
                    if (gameTimer.Enabled == true) gameTimer.Enabled = false;
                    else if (gameTimer.Enabled == false) gameTimer.Enabled = true;
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
                case Keys.Tab:
                    tabKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region Run Game

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

            foreach (Bricks m in bricks)
            {

                if (randGen.Next(0, 600) < 1)
                {
                    if (m is Skeleton)
                    {
                        Skeleton s = (Skeleton)m;
                        projectiles.Add(s.AttackPlayer());
                    }

                    if (m is Zombie)
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
                }
                else if (p.PaddleCollision(paddle))
                {
                    //Remove a life from the player if a projectile hits them
                    lives--;
                    projectiles.Remove(p);

                    if (lives == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
                else
                {
                    // Remove the projectile if it has reached its target
                    projectiles.Remove(p);
                    break;
                }
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
                ball.xSpeed = 0;
                ball.ySpeed = 3;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }

                gameTimer.Enabled = false;
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            //ball brick collision
            CheckBallBlockCollision();

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

            #endregion

            #region Load Next Level

            // If all five levels are won, open win screen
            if (level > 4)
            {
                Form1.ChangeScreen(this, new WinScreen());
            }

            // If level has been cleared, load next level
            else if (bricks.Count == 0)
            {
                gameTimer.Enabled = false;

                OnStart();

                level++;

                LoadLevel(level);
            }

            #endregion

            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void CheckBallBlockCollision()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                direction = randGen.Next(1, 3);

                if (ball.Collision(bricks[i].rect))
                {
                    if (ball.xSpeed == 0)
                    {
                        if (direction == 1)
                        {
                            ball.xSpeed = 2;
                        }
                        else
                        {
                            ball.xSpeed = -2;
                        }
                    }

                    if (ball.x + ball.size < bricks[i].rect.X + 5 || ball.x > bricks[i].rect.X + 35)
                    {
                        ball.xSpeed *= -1;
                    }

                    // Remove 1 hp from a brick whenever it is hit
                    bricks[i].TakeDamage();

                    // If brick health is 0, destroy the brick
                    if (bricks[i].hp == 0)
                    {
                        // Spawn a random powerup whenever an ore block is broken
                        if (Bricks.ores.Contains(bricks[i].brickType))
                        {
                            SpawnPowerUp(i);
                        }

                        // Remove brick from list
                        bricks.RemoveAt(i);
                    }

                    if (bounce == true)
                    {
                        ball.ySpeed = ball.ySpeed * -1;
                    }

                    // Exit loop after hitting one brick
                    break;
                }
            }
        }


        public void SpawnPowerUp(int i)
        {
            string[] powerUpTypes = { "ExtraLife", "SpeedBoost", "BigPaddle", "Bullet" };
            string selectedPowerUp = powerUpTypes[randGen.Next(powerUpTypes.Length)];

            powerUps.Add(new Powers(bricks[i].rect.X + Bricks.width / 2, bricks[i].rect.Y, selectedPowerUp));
        }


        public void LoadLevel(int levelNum)
        {
            // Get the list of bricks from the relevant XML file
            bricks = levelLoader.LoadLevel(levelNum);

            // Change screen background to level background
            switch (levelNum)
            {
                case 0:
                    this.BackgroundImage = Properties.Resources.level0Background;
                    break;

                case 1:
                    this.BackgroundImage = Properties.Resources.level1Background;
                    break;

                case 2:
                    this.BackgroundImage = Properties.Resources.level2Background;
                    break;

                    //case 3:
                    //    this.BackgroundImage = Properties.Resources.level3Background;
                    //    break;

                    //case 4:
                    //    this.BackgroundImage = Properties.Resources.level4Background;
                    //    break;
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


        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws power-ups
            foreach (Powers p in powerUps)
            {
                e.Graphics.FillEllipse(p.color, p.x, p.y, p.size, p.size);
            }

            // Draws Bricks with appropriate images
            foreach (Bricks b in bricks)
            {
                if (b.image != null)
                {
                    e.Graphics.DrawImage(b.image, b.rect);
                }
                else
                {
                    // Fallback to a white rectangle if no image found
                    e.Graphics.FillRectangle(Brushes.White, b.rect);
                }
            }

            // Draw projectiles launched at player
            foreach (Projectile proj in projectiles)
            {
                if (proj.image == "arrow")
                {
                    Arrow a = (Arrow)proj;
                    a.GetArrowBody();

                    e.Graphics.FillPolygon(a.projBrush, a.points);
                }

                if (proj.image == "slimeball")
                {
                    ZombieSpit s = (ZombieSpit)proj;
                    e.Graphics.FillEllipse(s.projBrush, s.x, s.y, s.diameter, s.diameter);
                }
            }

            // Draws ball
            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
