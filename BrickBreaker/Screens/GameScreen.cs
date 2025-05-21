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
        Boolean leftArrowDown, rightArrowDown, escapeKeyDown, spaceKeyDown, tabKeyDowm;

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
        int xSpeed = 0;
        int ySpeed = 3;


        // Paddle and Ball objects
        public static Paddle paddle;
        public static Ball ball;

        // Enum for Brick Types
        public enum BrickType
        {      
            Grass,
            Dirt,
            Stone,
            Deepslate,
            Bedrock,
        }

        Dictionary<BrickType, Image> brickImages = new Dictionary<BrickType, Image>()
        {
            { BrickType.Stone, Properties.Resources.stoneBlock },
            { BrickType.Grass, Properties.Resources.grassBlock },
            { BrickType.Dirt, Properties.Resources.dirtBlock },
            { BrickType.Deepslate, Properties.Resources.deepslate },
            { BrickType.Bedrock, Properties.Resources.bedrockpng },

        };


        List<Powers> powerUps = new List<Powers>();
        public static List<Block> blocks = new List<Block>();
        List<Bricks> bricks = new List<Bricks>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);


        List<MobBlock> mobs = new List<MobBlock>();

        Image brickImage = Properties.Resources.Cobblestone;

        List<Projectile> projectiles = new List<Projectile>();

        List<MobBlock> mobs = new List<MobBlock>();

        int levelMobCount = 3;

        public static int arrowHeight = 20;
        public static int arrowWidth = 5;
        public static int arrowSpeed = 8;

        public static int spitSpeed = 7;
        public static int spitDiameter = 20;

        Level levelLoader = new Level();
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
            //CreateBricks();

            LoadLevel("level1");

            // spawn mobs
            SpawnMobs();


            //set all button presses to false.
            leftArrowDown = rightArrowDown = escapeKeyDown = spaceKeyDown = tabKeyDowm = false;

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
            int xSpeed = 0;
            int ySpeed = 3;
            int ballSize = 20;
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
                case Keys.Tab:
                    tabKeyDowm = true;
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
                    tabKeyDowm = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

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

            foreach (Block m in blocks)
            {
                if (randGen.Next(0, 1000) < 1)
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
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Dock = DockStyle.Fill;

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        private void CheckBallBlockCollision()
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (ball.Collision(blocks[i].Rect))
                {
                    if (ball.xSpeed == 0)
                    {
                        ball.xSpeed = 3;
                    }

                    if (ball.x < 202 || ball.x > 652)
                    {
                        ball.xSpeed = ball.xSpeed * -1;
                    }
                    bool destroyed = bricks[i].TakeDamage();

                    if (destroyed)
                    {
                        BricksDestroyed(i);
                        bricks.RemoveAt(i);
                    }
                    if (bounce == true)
                    {
                        ball.ySpeed = ball.ySpeed * -1;
                    }

                    break; // Exit loop after hitting one brick
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

        public void LoadLevel(string levelNum)
        {
            blocks = levelLoader.LoadLevel(levelNum);
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

            for (int i = 0; i < levelMobCount; i++)
            {
                //select a random index within the list of blocks
                int index = randGen.Next(0, blocks.Count);

                while (mobs.Any(s => s.x == blocks[index].x && s.y == blocks[index].y))
                {
                    index = randGen.Next(0, blocks.Count);
                }

                m = new MobBlock(blocks[index].x, blocks[index].y);

                int mob = randGen.Next(0, MobBlock.mobTypes.Length);

                switch (MobBlock.mobTypes[mob])
                {
                    case "skeleton":
                        m = new Skeleton(m.x, m.y);
                        blocks[index] = m;
                        break;

                    case "zombie":
                        m = new Zombie(m.x, m.y);
                        blocks[index] = m;
                        break;

                    default:
                        m = new Skeleton(m.x, m.y);
                        blocks[index] = m;
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

            // Draws power-ups
            foreach (Powers p in powerUps)
            {
                e.Graphics.FillEllipse(p.color, p.x, p.y, p.size, p.size);
            }

            // Draws Bricks with appropriate images
            foreach (Bricks b in bricks)
            {
                if (b.Image != null)
                {
                    e.Graphics.DrawImage(b.Image, b.Rect);
                }
                else
                {
                    // Fallback to a white rectangle if no image found
                    e.Graphics.FillRectangle(Brushes.White, b.Rect);
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
