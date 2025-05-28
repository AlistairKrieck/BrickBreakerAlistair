/*  Created by: Alistair, Naz, Spencer, Silas, and Jayden
 *  Project: The Best Brick Breaker
 *  Date: May 27 2025
 *  
 *  To be played on 125% resolution
 *  Any other will cause the bricks not to load properly!
 *  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        //TODO
        /*
         * If we had extra time:
         * Optimize for performance
         * Comment everything
         * Find out why the nether level is so slow compared to everything else
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
        public static int maxLives = 5;

        // Stores the remaining lives the player has
        public static int lives = 5;

        // Stores the extra lives the player has
        public static int extraLives = 0;

        // Stores the players score
        public static int points = 0;

        // Set of all levels
        // Temporarily only include first and final levels for demonstration
        // To fix readd commented levels between 0 and 4
        public static string[] levels = new string[2] { "level0", "level4" }; // "level1", "level2", "level3", 

        // Current level as a position in the levels array
        int level = 0;

        // Paddle and Ball objects
        public static Paddle paddle;
        public static Ball ball;

        // Relates brick type to relevant image for convenience 
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
             { "blaze", Properties.Resources.blazeEnemyImage},
             { "ghastPlayer", Properties.Resources.ghastPlayer },
             { "deepslateTile", Properties.Resources.deepslateBrickBlock},
             { "obsidian", Properties.Resources.obsidianBlock},
             { "netherack", Properties.Resources.netherraackBlock},
             { "magma", Properties.Resources.magmaBlock},
             { "netherGold", Properties.Resources.netherGoldBlock},
             { "netherite", Properties.Resources.netheriteOreBlock},
             { "quartz", Properties.Resources.quartzOreBlock}
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
        public static int arrowSpeed = 10;

        // Variables to define a zombie spit object
        public static int spitSpeed = 8;
        public static int spitDiameter = 20;

        // Variables to define a fireball object
        public static int fireBallSpeed = 12;
        public static int fireBallDiameter = 20;

        // Object to load each new level from XML files
        LevelLoader levelLoader = new LevelLoader();

        // Starting y speed for ball
        int ballStartSpeed = 12;

        #endregion

        public GameScreen()
        {
            InitializeComponent();

            // Update labels to show default values
            scoreLabel.Text = $"Score: {points}";

            // Set all variables to their starting values and objects to starting positions
            OnStart();
            points = 0;

            // Load level 0
            level = 2;
            LoadLevel(level);
        }


        public void OnStart()
        {
            //set life counter
            lives = maxLives;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = escapeKeyDown = spaceKeyDown = tabKeyDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 10;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = 10 + paddleHeight;
            int paddleSpeed = 15;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = paddle.height + 20;

            // Creates a new ball
            int xSpeed = 0;
            int ySpeed = ballStartSpeed;
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
                if (randGen.Next(0, 500) < 1)
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

                        // Create a new fireball object and add it to the list of projectiles
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
                    TakeDamage();

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
                TakeDamage();

                points -= 10;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = paddle.y + ball.size;
                ball.xSpeed = 0;
                ball.ySpeed = ballStartSpeed;
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

            // Update score counter
            scoreLabel.Text = $"Score: {points}";

            #endregion

            #region Load Next Level

            // If all five levels are won, open win screen
            if (level > 4)
            {
                // Add 500 point for winning
                points += 500;

                // Update high score on win
                CheckHighScore();

                // Go to the win screen
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

                //TODO
                //Remove this line, it is only there for demonstration purposes
                level = 4;

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

        // Draws hearts to the screen based on the players remaining health
        private void UpdateHearts(PaintEventArgs e)
        {
            // Horizontal distance between hearts
            int heartSpacing = 10;

            // Distance between the left of the screen and the leftmost heart
            int horizSpacing = 50;

            // Distance between the top of the screen and the hearts
            int vertSpacing = 30;

            int heartSize = 40;

            // Draw maxLives worth of hearts
            for (int i = 0; i < maxLives; i++)
            {
                // Position the hearts in the top left corner with some margin
                int x = horizSpacing + i * (heartSize + heartSpacing);
                int y = vertSpacing;

                // Draw a red heart for each life the player has left, and a gray heart for each life the player has below max health
                Image image = i < lives ? Properties.Resources.minecraftHeartImage : Properties.Resources.emptyHeartImage;

                // Draw the heart to the screen
                e.Graphics.DrawImage(image, x, y, heartSize, heartSize);
            }

            // Draw extra (gold) hearts
            for (int i = 0; i < extraLives; i++)
            {
                // Position the extra hearts in the left of the red hearts
                int x = (lives + i) * (heartSize + horizSpacing);
                int y = vertSpacing;

                // Draws a golden heart for each health above maxLives (gotten from power ups)
                Image image = Properties.Resources.goldenHeartImage;

                // Draw the heart to the screen
                e.Graphics.DrawImage(image, x, y, heartSize, heartSize);
            }
        }

        // Method to remove health, play damage sound, and check if the player has died
        public void TakeDamage()
        {
            // Remove extra lives (lives above maxLives count from power ups) before removing regular lives
            if (extraLives > 0)
            {
                extraLives--;
            }

            // Remove lives if there are no extra lives and the player is not dead
            else if (lives > 0)
            {
                lives--;
            }

            // Play damage sound effect
            SoundPlayer player = new SoundPlayer(Properties.Resources.paddleHit);
            player.Play();

            // End the game and go to death screen if the player has 0 or less lives
            if (lives <= 0)
            {
                // Stop the game timer to prevent crashes when switching screens
                gameTimer.Enabled = false;

                // Run the OnEnd method
                OnEnd();
            }
        }

        // Saves the players high score and goes to the death screen
        public void OnEnd()
        {
            // Update high score on death
            CheckHighScore();

            // Go to the game over screen
            Form1.ChangeScreen(this, new GameOverScreen());
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
                            ball.xSpeed = 7;
                        }
                        else
                        {
                            ball.xSpeed = -7;
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

            // Change screen background to level background and play music
            switch (levelNum)
            {
                case 0:
                    this.BackgroundImage = Properties.Resources.level0Background;
                    Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Sweden.mp3"));
                    Form1.backgroundPlayer.Play();
                    break;

                case 1:
                    this.BackgroundImage = Properties.Resources.level1Background;
                    Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Otherside.mp3"));
                    Form1.backgroundPlayer.Play();
                    break;

                case 2:
                    this.BackgroundImage = Properties.Resources.level2Background;
                    Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Infinite Amethyst.mp3"));
                    Form1.backgroundPlayer.Play();
                    break;

                case 3:
                    this.BackgroundImage = Properties.Resources.level3Background;
                    Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Ancestry.mp3"));
                    Form1.backgroundPlayer.Play();
                    break;

                case 4:
                    this.BackgroundImage = Properties.Resources.level4Background;
                    Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Pigstep.mp3"));
                    Form1.backgroundPlayer.Play();
                    break;
            }
        }


        public void ApplyPowerUps(string type)
        {
            if (type == "ExtraLife")
            {
                if (lives < maxLives) lives++;
                else extraLives++;
            }
            else if (type == "SpeedBoost") paddle.speed += 2;
            else if (type == "BigPaddle") paddle.width += 20;
            else if (type == "Bullet")
            {
                bounce = false;
                BulletBallTimer = 200;
            }
        }

        private Image GetBreakOverlay(int maxHp, int currentHp)
        {
            // Detirmines Overlay based on max hp of brick
            int stage = maxHp - currentHp;

            if (maxHp == 5)
            {
                if (stage == 1) return Properties.Resources.SmallBreak;
                if (stage == 2) return Properties.Resources.SmallmedBreak;
                if (stage == 3) return Properties.Resources.BigmedBreak;
                if (stage == 4) return Properties.Resources.BigBreak;
            }
            else if (maxHp == 4)
            {
                if (stage == 1) return Properties.Resources.SmallBreak;
                if (stage == 2) return Properties.Resources.SmallmedBreak;
                if (stage == 3) return Properties.Resources.BigBreak;
            }
            else if (maxHp == 3)
            {
                if (stage == 1) return Properties.Resources.SmallmedBreak;
                if (stage == 2) return Properties.Resources.BigBreak;
            }
            else if (maxHp == 2)
            {
                if (stage == 1) return Properties.Resources.BigBreak;
            }

            return null;
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            UpdateHearts(e);

            // Draws paddle
            e.Graphics.DrawImage(brickImages["ghastPlayer"], paddle.x, paddle.y, paddle.width, paddle.height);

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
                    // Draw brick image
                    e.Graphics.DrawImage(b.image, b.rect);

                    // Draw break overlay if needed
                    Image breakOverlay = GetBreakOverlay(b.maxHp, b.hp);
                    if (breakOverlay != null)
                    {
                        e.Graphics.DrawImage(breakOverlay, b.rect);
                    }
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

                if (proj is FireBall)
                {
                    // Create a new fireball object
                    FireBall f = (FireBall)proj;

                    // Draw fireball to the screen
                    e.Graphics.FillEllipse(f.projBrush, f.x, f.y, f.diameter, f.diameter);
                }
            }

            // Draws ball
            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
