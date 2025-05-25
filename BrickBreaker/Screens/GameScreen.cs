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
         * UI design
         * Damage indicator on blocks
         * Sound effects and bg music
         * 
         */

        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, escapeKeyDown, spaceKeyDown, tabKeyDown;

        // Game values
        Random randGen = new Random();

        public int direction;

        bool bounce = true;
        int BulletBallTimer = 0;

        // Stores the remaining lives the player has
        public static int lives = 5;

        // Stores the players score
        public static int points = 0;

        // Set of all levels
        public static string[] levels = new string[3] { "level0", "level1", "level2" };

        // Current level as a position in the levels array
        int level;

        // Paddle and Ball objects
        public static Paddle paddle;
        public static Ball ball;

        // Relates block type to relevant image 
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



        // List of power ups to be moved
        List<Powers> powerUps = new List<Powers>();

        // List of all bricks in a level
        List<Bricks> bricks = new List<Bricks>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);

        // List of projectiles fired by mobs at player
        List<Projectile> projectiles = new List<Projectile>();

        // Variables to define an arrow object
        public static int arrowHeight = 20;
        public static int arrowWidth = 5;
        public static int arrowSpeed = 5;

        // Variables to define a zombie spit object
        public static int spitSpeed = 4;
        public static int spitDiameter = 20;

        // Variables to define a fireball object
        public static int fireBallSpeed = 6;
        public static int fireBallDiameter = 15;

        // Object to load each new level from XML files
        LevelLoader levelLoader = new LevelLoader();

        #endregion

        public GameScreen()
        {
            InitializeComponent();

            // Update labels to show default values
            scoreLabel.Text = $"{points}";
            livesLabel.Text = $"{lives}";

            // Set all variables to their starting values and objects to starting positions
            OnStart();
            points = 0;

            // Load level 0
            level = 0;
            LoadLevel(level);
        }


        public void OnStart()
        {
            //set life counter
            lives = 1;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = escapeKeyDown = spaceKeyDown = tabKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 10;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = 10 + paddleHeight;
            int paddleSpeed = 10;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = paddle.height + 20;

            // Creates a new ball
            int xSpeed = 0;
            int ySpeed = 3;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            // Empty object lists to prevent objects from remaining after a level is cleared
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

            // Have each enemy attempt to attack the player with their method of choice
            foreach (Bricks m in bricks)
            {
                // Some chance each frame that each enemy will attack
                if (randGen.Next(0, 600) < 1)
                {
                    if (m is Skeleton)
                    {
                        // Create new skeleton to allow attacking
                        Skeleton s = (Skeleton)m;

                        // Create a new arrow object and add it to the list of projectiles
                        projectiles.Add(s.AttackPlayer());
                    }

                    if (m is Zombie)
                    {
                        // Create new zomnie to allow attacking
                        Zombie z = (Zombie)m;

                        // Create a new spit object and add it to the list of projectiles
                        projectiles.Add(z.AttackPlayer());
                    }

                    if (m is Blaze)
                    {
                        // Create new zomnie to allow attacking
                        Blaze b = (Blaze)m;

                        // Create a new spit object and add it to the list of projectiles
                        projectiles.Add(b.AttackPlayer());
                    }
                }
            }


            // Move all arrows and delete them on collision with player or top wall
            foreach (Projectile p in projectiles)
            {
                // Update the arrows position if it has not hit the player or the top wall
                if (!p.PaddleCollision(paddle) && !p.TopCollision())
                {
                    // Update position
                    p.Move();
                }

                // Remove the projectile if it has reached its target
                else if (p.PaddleCollision(paddle))
                {
                    // Remove a life and 10 points from the player if a projectile hits them
                    lives--;
                    points -= 10;

                    // Remove projectile to prevent it from taking multiple lives at once
                    projectiles.Remove(p);

                    // Move onto next projectile
                    break;
                }

                // Remove the projectile if it hits the top wall
                else
                {
                    projectiles.Remove(p);

                    //Move onto next projectile
                    break;
                }
            }


            // Check for ball hitting top of screen
            if (ball.TopCollision(this))
            {
                // Pause the game
                gameTimer.Enabled = false;

                // Remove a life and 10 points if the player misses the ball
                lives--;
                points -= 10;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = paddle.y + ball.size;
                ball.xSpeed = 0;
                ball.ySpeed = 3;
            }

            // If the player dies, end the game
            if (lives == 0)
            {
                gameTimer.Enabled = false;
                OnEnd();
            }


            // Check for collision with bottom and side walls
            ball.WallCollision(this);

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // See if ball collides with any bricks, and damage them and reflect ball accordingly
            CheckBallBlockCollision();

            // Move and apply power ups
            foreach (Powers p in powerUps)
            {
                p.Move();

                // Create rectangles to allow checking intersection
                Rectangle paddleRect = new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);
                Rectangle powerRect = new Rectangle(p.x, p.y, p.size, p.size);

                // If paddle collides with power up, apply the effect and remove it from the list
                if (paddleRect.IntersectsWith(powerRect))
                {
                    // Apply the power up's effects
                    ApplyPowerUps(p.type);

                    // Remove it from the list
                    powerUps.Remove(p);

                    // Move onto next power up
                    break;
                }

                // If powerups pass the player without being caught, remove them from the list
                else if (p.y <= 0)
                {
                    // Remove it from the list
                    powerUps.Remove(p);

                    // Move onto next power up
                    break;
                }
            }

            if (bounce == false)
            {
                BulletBallTimer--;
                if (BulletBallTimer <= 0) bounce = true;
            }

            // Update life counter
            livesLabel.Text = $"{lives}";
            scoreLabel.Text = $"{points}";

            #endregion

            #region Load Next Level

            // If all five levels are won, open win screen
            if (level > 4)
            {
                // Add 500 point for winning
                points += 500;

                // Update high score on win
                CheckHighScore();

                Form1.ChangeScreen(this, new WinScreen());
            }

            // If level has been cleared, load next level
            else if (bricks.Count == 0)
            {
                // Pause the game
                gameTimer.Enabled = false;

                // Reset all variables, postions, and lists
                OnStart();

                // Update level by 1
                level++;

                // Add 100 points for clearing a level
                points += 100;

                // Update high score on level clear
                CheckHighScore();

                // Load next level
                LoadLevel(level);
            }

            #endregion

            // Redraw the screen
            Refresh();
        }

        // If current points are greater than this player's high score, update high score to new value
        private static void CheckHighScore()
        {
            if (points > Form1.player.score)
            {
                Form1.player.score = points;
                Form1.player.UpdatePlayerScore();
            }
        }

        public void OnEnd()
        {
            // Update high score on death
            CheckHighScore();

            // Goes to the game over screen
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void CheckBallBlockCollision()
        {
            foreach (Bricks b in bricks)
            {
                direction = randGen.Next(1, 3);

                if (ball.Collision(b.rect))
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.brickCollision);
                    player.Play();

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

                    if (ball.x + ball.size < b.rect.X + 5 || ball.x > b.rect.X + 35)
                    {
                        ball.xSpeed *= -1;
                    }

                    // Remove 1 hp from a brick whenever it is hit
                    b.TakeDamage();

                    // Add 1 point for each damage dealt to a block
                    points++;

                    // If brick health is 0, destroy the brick
                    if (b.hp <= 0)
                    {
                        // Spawn a random powerup whenever an ore block is broken
                        if (Bricks.ores.Contains(b.brickType))
                        {
                            SpawnPowerUp(b);

                            // Add 5 points for breaking an ore block (3 plus the 2 below)
                            points += 3;
                        }
                        if (Bricks.mobs.Contains(b.brickType))
                        {
                            SpawnPowerUp(b);

                            // Add 5 points for breaking an ore block (3 plus the 2 below)
                            points += 5;
                        }

                        // Add 2 points for breaking a block
                        points += 2;

                        // Remove brick from list
                        bricks.Remove(b);
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

        // Spawn a random power up
        public void SpawnPowerUp(Bricks b)
        {
            string[] powerUpTypes = { "ExtraLife", "SpeedBoost", "BigPaddle", "Bullet" };
            string selectedPowerUp = powerUpTypes[randGen.Next(powerUpTypes.Length)];

            powerUps.Add(new Powers(b.rect.X + Bricks.width / 2, b.rect.Y, selectedPowerUp));
        }

        // Load level from an XML file using a level loader object
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
                if (proj is Arrow)
                {
                    // Create a new arrow
                    Arrow a = (Arrow)proj;

                    // Get the corners of the arrow to allow it to face at angles
                    a.GetArrowBody();

                    // Draw arrow to the screen
                    e.Graphics.FillPolygon(a.projBrush, a.points);
                }

                if (proj is ZombieSpit)
                {
                    // Create a new spit object
                    ZombieSpit s = (ZombieSpit)proj;

                    // Draw spit to the screen
                    e.Graphics.FillEllipse(s.projBrush, s.x, s.y, s.diameter, s.diameter);
                }
            }

            // Draws ball
            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
