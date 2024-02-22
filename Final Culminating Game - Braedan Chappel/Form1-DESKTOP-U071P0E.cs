using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Final_Culminating_Game___Braedan_Chappel
{

    //final culminating game - Braedan Chappel

    //- Gravity
    //- Shooting Elemental weapons, shotguns
    //- pickups
    //- music
    //- multiple levels/ eng game
    //- Many Enemies
    //- walls and ladders, lifts, platforms
    //- doors with key cards
    //- low poly textures
    //- UI
    //- proper settings
    //- use of lists, arrays, sprites,
    //Custom App Icon

    public partial class Form1 : Form
    {
        //Player Sprite
        Image imgSprite = Properties.Resources.Player;
        int count, row, col, totalRows, totalCols, spriteWidth, spriteHeight;
        int spriteVel;
        bool goLeft, goRight;
        int PlayerHealth = 100; //player health
        int spriteLocationX = 25;
        int spriteLocationY = 950;

        //Player Death
        Image imgDeadPlayer;
        int DeadPlayerNumber = 1;
        int TotalPlayerDeadImage = 3;
        //bool isVisible = true;
        Rectangle rDeadPlayer;



        // Enemy1 (Original)
        Image imgEnemy = Properties.Resources.Enemy;
        int count2, row2, col2;
        int rows = 6, cols = 5;
        int EnemyWidth, EnemyHeight;
        int EnemyHealth = 150;

        //Enemy1 Death Animation Sprite
        Image imgEnemy1Death = Properties.Resources.Animation;
        int count3, row3, col3;
        int rows3 = 1, cols3 = 6;
        int Animation1Width, Animation1Height;
        int Enemy1Vel = 15;
        

        //Enemy 2 - HellKnight
        int HellKnightNum = 1;
        int HellKnightImage;
        Image imgHellKnight;
        bool isHellKnightDead = false;
        Rectangle rHellKnight;  
        int HellKnightHealth = 200;
        

        int hellknightLocationX = 1000; //stores location in a variable
        int hellknightlocationY = 50;
        
        bool isSeekingPlayer = false;
        bool Attack = false;
        bool idle = true;

        bool KeyDisplay = false;
        bool isKeyCardCollected = false;


        int hellKnightVelocity = 8;
        
        Rectangle rightDetection;

        Random rnd = new Random();

        Rectangle rSprite, rEnemy, rAnimation1;

        //Bullet       
        bool shootLeft = false, shootRight = true;
        List<Rectangle> r = new List<Rectangle>();
        List<int> bulletxVel = new List<int>();


        //Gravity 
        double g = 9.8; //gravity
        double t = 0;   //time
        double v2;      //velocity after time
        double v1;      //initial velocity

        int SpriteSize = 80;


        //Runtime
        bool isDead = false;
        bool isAlive = true;
        bool isGameOver = false;
        bool isGameWin = false;
        bool isPlayerAlive = true;

        bool isRight;
        bool isLeft;

        bool load2 = false;

        int points = 0;
        int bulletDamage = 10;
        int damage = 10;

        //Map & Level
        Rectangle rFloor;
        Rectangle[] rPlatform = new Rectangle[30];

        Rectangle rYellowKeyCard;
        Image imgYellowKeyCard = Properties.Resources.YellowKey;

        Rectangle rExitSign;
        Image imgExit = Properties.Resources.Exit;

        Rectangle rTeleporter;
        Image imgTeleporter = Properties.Resources.Teleporter;

        Rectangle rTeleporter2;
        Image imgTeleporter2 = Properties.Resources.Teleporter;

        SoundPlayer Plasma = new SoundPlayer(Properties.Resources.Plasma);
        SoundPlayer Death = new SoundPlayer(Properties.Resources.Death);

        int faceUINum = 1;
        int faceUI = 3;

        Rectangle rFace;
        Image imgFace = Properties.Resources._1001;

        Rectangle rCheckPoint;
        Image imgCheckpoint = Properties.Resources.CheckPoint;



        //Game Logo (DOOM)
        Image imgLogo = Properties.Resources.Logo;


        public Form1()
        {
            InitializeComponent();

            //Player Sprite
            totalCols = 7;
            totalRows = 4;
            spriteWidth = imgSprite.Width / totalCols;
            spriteHeight = imgSprite.Height / totalRows;
            rSprite = new Rectangle(spriteLocationX, spriteLocationY, SpriteSize, SpriteSize); //50, 1000
            spriteVel = 20;

            //Enemy Sprite
            EnemyWidth = imgEnemy.Width / cols;
            EnemyHeight = imgEnemy.Height / rows;
            rEnemy = new Rectangle(1300, 490, EnemyWidth, EnemyHeight);

            //Death animation
            Animation1Width = imgEnemy1Death.Width / cols3;
            Animation1Height = imgEnemy1Death.Height / rows3;
            rAnimation1 = new Rectangle(1300, 543, Animation1Width, Animation1Height); //X value stays static then selected randomly (think inital spawn location,
            //Hitbox
            rightDetection = new Rectangle(250, 100, 1000, 20);

            //Map & Level

            rFloor = new Rectangle(1234, 1020, 284, 20); //floor of the map

            rYellowKeyCard = new Rectangle(225, 475, 30, 40); //Yellow Key Card;

            //Walls
            rPlatform[0] = new Rectangle(0, 1021, 526, 20);
            rPlatform[1] = new Rectangle(506, 805, 20, 235);
            rPlatform[2] = new Rectangle(506, 794, 223, 20);
            rPlatform[3] = new Rectangle(709, 794, 20, 247);
            rPlatform[4] = new Rectangle(709, 1021, 526, 20);
            rPlatform[5] = new Rectangle(1215, 175, 20, 866);
            rPlatform[6] = new Rectangle(203, 175, 1032, 20);
            rPlatform[7] = new Rectangle(0, 526, 385, 20);
            rPlatform[8] = new Rectangle(365, 458, 20, 88);
            rPlatform[10] = new Rectangle(1500, 956, 20, 85);
            rPlatform[11] = new Rectangle(1508, 956, 397, 20);
            rPlatform[12] = new Rectangle(1572, 175, 350, 20);

            //Door
            rPlatform[17] = new Rectangle(203, -600, 215, 20); 

            //Slabs
            rPlatform[9] = new Rectangle(784, 794, 100, 10);
            rPlatform[13] = new Rectangle(1022, 647, 100, 10);
            rPlatform[14] = new Rectangle(784, 482, 100, 10);
            rPlatform[15] = new Rectangle(629, 555, 100, 10);
            rPlatform[16] = new Rectangle(423, 429, 100, 10);
            rPlatform[18] = new Rectangle(1572, 175, 20, 639);
            rPlatform[19] = new Rectangle(423, 429, 100, 10);

            //Hell Knight
            rHellKnight = new Rectangle(hellknightLocationX, hellknightlocationY, 200, 150);
            imgHellKnight = Properties.Resources.LeftRun1;

            rDeadPlayer = new Rectangle(spriteLocationX, spriteLocationY, SpriteSize, SpriteSize);
            imgDeadPlayer = Properties.Resources.Frame1;

            rightDetection = new Rectangle(250, 160, 1000, 5);

            rFace = new Rectangle(1795, 30, 100, 125);

            rTeleporter = new Rectangle(450, 971, 50, 50);
            rTeleporter2 = new Rectangle(50, 477, 50, 50);

            rExitSign = new Rectangle(1780, 800, 60, 25);

            rCheckPoint = new Rectangle(1780, 860, 70, 100);
        }

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            if (isDead == true)
            {
                row3 = count3 / cols3;    //returns the integer only (no remainder)
                col3 = count3 % cols3;    //returns the remainder only (no integer)dd

                if (count3 >= rows3 * cols3)
                {
                    count3 = 0;
                }

                col3 = count3 % cols3;

                count3 += 1;
            }
       
            this.Refresh();
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            KeyDisplay = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            tmrGravity.Start();

            //enables full screen on start DO NOT USE breakpoint when code is active
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void Runtime_Tick(object sender, EventArgs e)
        {
            LevelLoader.Stop();
        }

        private void LevelLoader_Tick(object sender, EventArgs e)
        {
            //if (load2 == true)
            //{
            //    Form1 level1 = new Form1();
            //    Form2 level2 = new Form2();

            //    level2.Show();

            //    this.Hide();
            //}
;

            
        }

        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            row2 = count2 / cols;    //returns the integer only (no remainder)
            col2 = count2 % cols;    //returns the remainder only (no integer)dd

            if (count2 >= rows * cols)
            {
                count2 = 0;
            }

            col2 = count2 % cols;

            count2 += 1;


            this.Refresh();
        }

        private void tmrUI_Tick(object sender, EventArgs e)
        {
            if (PlayerHealth <= 100 && PlayerHealth >= 80)
            {
                switch (faceUINum) 
                {
                    case 1:
                        imgFace = Properties.Resources._1001;
                        break;
                    case 2:
                        imgFace = Properties.Resources._1002;
                        break;
                    case 3:
                        imgFace = Properties.Resources._1003;                        
                        break;
                }
            }

            if (PlayerHealth <= 79 && PlayerHealth >= 60)
            {
                switch (faceUINum) 
                {
                    case 1:
                        imgFace = Properties.Resources._801;
                        break;
                    case 2:
                        imgFace = Properties.Resources._802;
                        break;
                    case 3:
                        imgFace = Properties.Resources._803;
                        break;
                }
            }

            if (PlayerHealth <= 59 && PlayerHealth >= 40)
            {
                switch (faceUINum)
                {
                    case 1:
                        imgFace = Properties.Resources._601;
                        break;
                    case 2:
                        imgFace = Properties.Resources._602;
                        break;
                    case 3:
                        imgFace = Properties.Resources._603;
                        break;
                }
            }

            if (PlayerHealth <= 39 && PlayerHealth >= 20)
            {

                switch (faceUINum)
                {
                    case 1:
                        imgFace = Properties.Resources._401;
                        break;
                    case 2:
                        imgFace = Properties.Resources._402;
                        break;
                    case 3:
                        imgFace = Properties.Resources._403;
                        break;
                }
            }

            if (PlayerHealth <= 19 && PlayerHealth >= 1)
            {

                switch (faceUINum)
                {
                    case 1:
                        imgFace = Properties.Resources._201;
                        break;
                    case 2:
                        imgFace = Properties.Resources._202;
                        break;
                    case 3:
                        imgFace = Properties.Resources._203;
                        break;
                }
            }

            faceUINum += 1;

            if (faceUINum > faceUI)
            {
                faceUINum = 1;
            }

            this.Refresh();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            rDeadPlayer.Location = rSprite.Location; //sets the location of the death animation to the location of the sprite.

            for (int x = 0; x < r.Count; x++)
            {
                if (r[x].IntersectsWith(rEnemy))
                {
                    EnemyHealth -= bulletDamage;

                    rDeadPlayer.Location = new Point(1200, 500);
                    
                    AnimationEngine.Start();
                }

                if (r[x].IntersectsWith(rHellKnight))
                {
                    HellKnightHealth -= bulletDamage;
                    HellKnightImage = 9;
                }
            }

            if(rSprite.IntersectsWith(rCheckPoint))
            {
                load2 = true;

                //rSprite.Location = new Point(500, 500);
            }


            if (rSprite.IntersectsWith(rYellowKeyCard))
            {
                rYellowKeyCard.X = 1600;
                rYellowKeyCard.Y = 1000;

                isKeyCardCollected = true;
                KeyDisplay = true;

                delayTimer.Start();
            }

            if (rSprite.IntersectsWith(rTeleporter))
            {
                v1 = -40;
                tmrGravity.Start();
            }

            if (rSprite.IntersectsWith(rTeleporter2))
            {
                v1 = -45;
                tmrGravity.Start();
            }

            if (rEnemy.IntersectsWith(rSprite) && isAlive == true)
            {
                PlayerHealth -= 1;
            }

            if (EnemyHealth == 0)
            {
                tmrAnimation.Enabled = true;
                count3 = 0;
                isDead = true;
                isAlive = false;
                Death.Play();
                points += 50;
            }

            if (HellKnightHealth <= 0)
            {
                isHellKnightDead = true;

            }

            if (count3 == 6)
            {
                tmrAnimation.Stop();
            }

            if (isAlive == true)
            {
                if (rSprite.Location.X > rEnemy.Location.X)
                {
                    isLeft = true;
                    isRight = false;
                }

                if (rSprite.Location.X < rEnemy.Location.X)
                {
                    isRight = true;
                    isLeft = false;
                }

                if (rSprite.Location.X > rHellKnight.Location.X)
                {
                    isLeft = true;
                    isRight = false;
                }

                if (rSprite.Location.X < rHellKnight.Location.X)
                {
                    isRight = true;
                    isLeft = false;
                }
            }

            if (PlayerHealth <= 0)
            {
                isGameOver = true;                
            }

            for (int i = 0; i < 30; i++)
            {
                if (rSprite.IntersectsWith(rPlatform[i]))
                {
                    if (goLeft == true && rSprite.Left <= rPlatform[i].Right && rSprite.Left > rPlatform[i].Left)
                    {
                        rSprite.X += spriteVel;
                        tmrSprite.Stop();
                    }

                    if (goRight == true && rSprite.Right >= rPlatform[i].Left && rSprite.Left < rPlatform[i].Left)
                    {
                        rSprite.X -= spriteVel;
                        tmrSprite.Stop();
                    }
                }
            }

            if (isHellKnightDead == false)
            {
                if (rSprite.IntersectsWith(rightDetection))
                {
                    isSeekingPlayer = true;

                    rPlatform[17].Location = new Point(0, 175);

                }
            }

            if (isSeekingPlayer == true)
            {
                rHellKnight.X -= hellKnightVelocity;

                if (rHellKnight.IntersectsWith(rSprite))
                {
                    Attack = true;
                    hellKnightVelocity = 0;

                    if (isHellKnightDead == false)
                    {                        
                        PlayerHealth = 0;

                        isPlayerAlive = false;
                    }

                    if (isHellKnightDead == false)
                    {
                        rHellKnight.X = rSprite.X;
                    }

                    if (PlayerHealth == 0)
                    {
                        if (isHellKnightDead == false)
                        {                           
                            spriteVel = 0;
                        }
                    }                                        
                }
            }
        }
        
        private void AnimationEngine_Tick(object sender, EventArgs e)
        {
            //controls other animations for other needed events
            if (isPlayerAlive == false)
            {

                switch (DeadPlayerNumber) //imgDeadPlayer
                {
                    case 1:
                        imgDeadPlayer = Properties.Resources.Frame1;
                        break;
                    case 2:
                        imgDeadPlayer = Properties.Resources.Frame2;
                        break;
                    case 3:
                        imgDeadPlayer = Properties.Resources.Frame3; 
                        AnimationEngine.Stop();
                        break;
                }
            }

            DeadPlayerNumber += 1;

            if (DeadPlayerNumber > TotalPlayerDeadImage)
            {
                DeadPlayerNumber = 1;
            }

            this.Refresh();
        }

        private void tmrSpriteController_Tick(object sender, EventArgs e)
        {
            if (idle == true)
            {
                HellKnightImage = 10;

                switch (HellKnightNum)
                {
                    case 1:
                        imgHellKnight = Properties.Resources.LeftIdle1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.LeftIdle2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.LeftIdle3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.LeftIdle4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.LeftIdle5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.LeftIdle6;
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.LeftIdle7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.LeftIdle8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.LeftIdle9;
                        break;
                    case 10:
                        imgHellKnight = Properties.Resources.LeftIdle10;
                        break;
                }
            }           

            if (isSeekingPlayer == true)
            {
                HellKnightImage = 11;
                tmrSpriteController.Interval = 75;

                switch (HellKnightNum)
                {
                    case 1:
                        imgHellKnight = Properties.Resources.LeftRun1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.LeftRun2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.LeftRun3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.LeftRun4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.LeftRun5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.LeftRun6;
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.LeftRun7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.LeftRun8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.LeftRun9;
                        break;
                    case 10:
                        imgHellKnight = Properties.Resources.LeftRun10;
                        break;
                    case 11:
                        imgHellKnight = Properties.Resources.LeftRun11;                                                
                        break;
                }
                #region ATTACK ANIMATION CODE
                if (Attack == true)
                {                 
                    HellKnightImage = 53;
                    switch (HellKnightNum)
                    {
                        case 1:
                            imgHellKnight = Properties.Resources._0070;
                            break;
                        case 2:
                            imgHellKnight = Properties.Resources._0072;
                            break;
                        case 3:
                            imgHellKnight = Properties.Resources._0074;
                            break;
                        case 4:
                            imgHellKnight = Properties.Resources._0076;
                            break;
                        case 5:
                            imgHellKnight = Properties.Resources._0078;
                            break;
                        case 6:
                            imgHellKnight = Properties.Resources._0080;
                            break;
                        case 7:
                            imgHellKnight = Properties.Resources._0082;
                            break;
                        case 8:
                            imgHellKnight = Properties.Resources._0084;
                            break;
                        case 9:
                            imgHellKnight = Properties.Resources._0086;
                            break;
                        case 10:
                            imgHellKnight = Properties.Resources._0088;
                            break;
                        case 11:
                            imgHellKnight = Properties.Resources._0090;
                            break;
                        case 12:
                            imgHellKnight = Properties.Resources._0092;
                            break;
                        case 13:
                            imgHellKnight = Properties.Resources._0094;                            
                            break;
                        case 14:
                            imgHellKnight = Properties.Resources._0096;
                            break;
                        case 15:
                            imgHellKnight = Properties.Resources._0098;
                            break;
                        case 16:
                            imgHellKnight = Properties.Resources._0100;
                            break;
                        case 17:
                            imgHellKnight = Properties.Resources._0102;
                            break;
                        case 18:
                            imgHellKnight = Properties.Resources._0104;
                            break;
                        case 19:
                            imgHellKnight = Properties.Resources._0106;
                            break;
                        case 20:
                            imgHellKnight = Properties.Resources._0108;
                            break;
                        case 21:
                            imgHellKnight = Properties.Resources._0110;
                            break;
                        case 22:
                            imgHellKnight = Properties.Resources._0112;
                            break;
                        case 23:
                            imgHellKnight = Properties.Resources._0114;
                            break;
                        case 24:
                            imgHellKnight = Properties.Resources._0116;
                            break;
                        case 25:
                            imgHellKnight = Properties.Resources._0118;
                            break;
                        case 26:
                            imgHellKnight = Properties.Resources._0120;
                            break;
                        case 27:
                            imgHellKnight = Properties.Resources._0122;
                            break;
                        case 28:
                            imgHellKnight = Properties.Resources._0124;
                            break;
                        case 29:
                            imgHellKnight = Properties.Resources._0126;
                            break;
                        case 30:
                            imgHellKnight = Properties.Resources._0128;
                            break;
                        case 31:
                            imgHellKnight = Properties.Resources._0130;
                            break;
                        case 32:
                            imgHellKnight = Properties.Resources._0132;
                            break;
                        case 33:
                            imgHellKnight = Properties.Resources._0134;
                            break;
                        case 34:
                            imgHellKnight = Properties.Resources._0136;
                            break;
                        case 35:
                            imgHellKnight = Properties.Resources._0138;
                            break;
                        case 36:
                            imgHellKnight = Properties.Resources._0140;
                            break;
                        case 37:
                            imgHellKnight = Properties.Resources._0142;
                            break;
                        case 38:
                            imgHellKnight = Properties.Resources._0144;
                            break;
                        case 39:
                            imgHellKnight = Properties.Resources._0146;
                            break;
                        case 40:
                            imgHellKnight = Properties.Resources._0148;
                            break;
                        case 41:
                            imgHellKnight = Properties.Resources._0150;
                            break;
                        case 42:
                            imgHellKnight = Properties.Resources._0152;
                            break;
                        case 43:
                            imgHellKnight = Properties.Resources._0154;
                            break;
                        case 44:
                            imgHellKnight = Properties.Resources._0156;
                            break;
                        case 45:
                            imgHellKnight = Properties.Resources._0158;
                            break;
                        case 46:
                            imgHellKnight = Properties.Resources._0160;
                            break;
                        case 47:
                            imgHellKnight = Properties.Resources._0162;
                            break;
                        case 48:
                            imgHellKnight = Properties.Resources._0164;
                            break;
                        case 49:
                            imgHellKnight = Properties.Resources._0166;
                            break;
                        case 50:
                            imgHellKnight = Properties.Resources._0168;
                            break;
                        case 51:
                            imgHellKnight = Properties.Resources._0170;
                            break;
                        case 52:
                            imgHellKnight = Properties.Resources._0172;
                            break;
                        case 53:
                            imgHellKnight = Properties.Resources._0174;

                            tmrSpriteController.Stop();
                            break;
                            
                    }
                }
                
                #endregion
            }


            if (isHellKnightDead == true)
            {
                tmrSpriteController.Interval = 75;
                hellKnightVelocity = 0;
                HellKnightImage = 9;
                switch (HellKnightNum)
                {
                    case 1:
                        imgHellKnight = Properties.Resources.Dead1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.Dead2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.Dead3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.Dead4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.Dead5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.Dead6;
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.Dead7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.Dead8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.Dead9;
                        tmrSpriteController.Stop();
                        break;
                }
            }

            if (PlayerHealth <= 0)
            {

                switch (faceUINum)
                {
                    case 1:
                        imgFace = Properties.Resources.DEADPLAYER;
                        break;

                }
            }


            faceUINum += 1;

            if (faceUINum > faceUI)
            {
                faceUINum = 1;
            }



            HellKnightNum += 1; // repeat the animation

            if (HellKnightNum > HellKnightImage)
            {
                HellKnightNum = 1;
            }

            this.Refresh();
        }

        private void tmrSprite_Tick(object sender, EventArgs e)
        {

            if (goLeft == true)
            {
                rSprite.X -= spriteVel;
            }

            if (goRight == true)
            {
                rSprite.X += spriteVel;
            }


            if (count >= (totalRows * totalCols))
            {
                count = 0;
            }

            col = count % totalCols;

            count += 1;

            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                //spriteVel = 25;
                goLeft = true;
                row = 3;
                tmrSprite.Start();
                shootLeft = true;
                shootRight = false;
            }

            if (e.KeyData == Keys.D)
            {
                //spriteVel = 25;
                goRight = true;
                row = 2;
                tmrSprite.Start();
                shootRight = true;
                shootLeft = false;
            }

            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyData == Keys.H)
            {
                PlayerHealth -= 5;
            }

            //level selector
            if (e.KeyData == Keys.F)
            {
                if (load2 == true)
                {
                    Form1 level1 = new Form1();
                    Form2 level2 = new Form2();

                    level2.Show();
               
                    this.Hide();
                }             
            }


            if (e.KeyData == Keys.Space)
            {                
                v1 = -30; //Increase Jump Height

                tmrGravity.Start();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.A)
            {
                goLeft = false;
                tmrSprite.Stop();
            }

            if (e.KeyData == Keys.D)
            {
                goRight = false;
                tmrSprite.Stop();
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //Collision Bar (HitBox)
            e.Graphics.FillRectangle(Brushes.LimeGreen, rightDetection);

            //Items
            e.Graphics.DrawImage(imgYellowKeyCard, rYellowKeyCard); //Yellow Keycard

            //Map
            e.Graphics.DrawImage(imgExit, rExitSign);

            for (int x = 0; x < r.Count; x++)
            {
                e.Graphics.FillEllipse(Brushes.Red, r[x]); //Bullet

                if (isRight == true)
                {
                    if (r[x].Location.X > rEnemy.Location.X)
                    {
                        e.Graphics.FillEllipse(Brushes.Black, r[x]);
                    }


                    if (isHellKnightDead == false)
                    {
                        if (r[x].Location.X > rHellKnight.Location.X)
                        {
                            e.Graphics.FillEllipse(Brushes.Black, r[x]);
                        }

                    }

                }

                if (isLeft == true)
                {
                    if (r[x].Location.X < rEnemy.Location.X)
                    {
                        e.Graphics.FillEllipse(Brushes.Black, r[x]);
                    }

                    if (isHellKnightDead == false)
                    {
                        if (r[x].Location.X < rHellKnight.Location.X)
                        {
                            e.Graphics.FillEllipse(Brushes.Black, r[x]);
                        }

                    }

                }
            }

            if (isAlive == true)
            {
                e.Graphics.DrawImage(imgEnemy, rEnemy, new RectangleF(col2 * EnemyWidth, row2 * EnemyHeight, EnemyWidth, EnemyHeight), GraphicsUnit.Pixel);
                e.Graphics.DrawString(EnemyHealth + " Enemy Health".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red, rEnemy.X, rEnemy.Y - 50);
            }

            if (isDead == true) //Does death animation
            {
                e.Graphics.DrawImage(imgEnemy1Death, rAnimation1, new RectangleF(col3 * Animation1Width, row3 * Animation1Height, Animation1Width, Animation1Height), GraphicsUnit.Pixel);
            }

            //Player
            if (PlayerHealth > 0)
            {
                if (KeyDisplay == true)
                {
                    e.Graphics.DrawString(" Yellow Key Card Aquired".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Yellow, rSprite.X + 50, rSprite.Y - 80);
                }
                e.Graphics.DrawString(PlayerHealth + " HP".ToString(), new System.Drawing.Font("Arial", 12), Brushes.Blue, rSprite.X + 15, rSprite.Y - 25);

                e.Graphics.DrawImage(imgSprite, rSprite, new RectangleF(col * spriteWidth, row * spriteHeight, spriteWidth, spriteHeight), GraphicsUnit.Pixel);
            }

            //Map & Level
            e.Graphics.FillRectangle(Brushes.Red, rFloor);

            for (int d = 0; d < 30; d++)
            {
                e.Graphics.FillRectangle(Brushes.Blue, rPlatform[d]);
            }

            //Text and UI
            if (isGameOver == true)
            {
                e.Graphics.DrawString("You Died".ToString(), new System.Drawing.Font("Arial", 32), Brushes.Red, this.Width / 2 - 89, 215);
            }

            if (isGameWin == true)
            {
                e.Graphics.DrawString("You Win, Score: " + points.ToString(), new System.Drawing.Font("Arial", 32), Brushes.LimeGreen, this.Width / 2 - 169, 240);
            }

            e.Graphics.DrawString("Score: " + points.ToString(), new System.Drawing.Font("Arial", 16), Brushes.LimeGreen, 1800, 0);

            //Hell Knight
            if (HellKnightHealth > 0 )
            {
                e.Graphics.DrawString(HellKnightHealth + " Hell Knight".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red,rHellKnight.X , rHellKnight.Y);                
            }

            e.Graphics.DrawImage(imgHellKnight, rHellKnight);
            e.Graphics.DrawImage(imgYellowKeyCard, rYellowKeyCard);
            e.Graphics.DrawImage(imgFace, rFace);


            if (isPlayerAlive == false)
            {                
                e.Graphics.DrawImage(imgDeadPlayer, rDeadPlayer);
            }

            e.Graphics.DrawImage(imgTeleporter, rTeleporter);
            e.Graphics.DrawImage(imgTeleporter2, rTeleporter2);
            e.Graphics.DrawImage(imgCheckpoint, rCheckPoint);


            if (load2 == true)
            {
                e.Graphics.DrawString(" Press F Load Level 2".ToString(), new System.Drawing.Font("Arial", 40), Brushes.Yellow, this.Width/2 -290 , 10);
            }

            //e.Graphics.DrawString(" Press F Load Level 2".ToString(), new System.Drawing.Font("Arial", 40), Brushes.Yellow, this.Width / 2 - 290, 10);

        }

        private void MoveProjectile()
        {  
                //shooting code
            {
                for (int i = 0; i < r.Count; i++)
                {
                    Rectangle rr = r[i];

                    rr.X += bulletxVel[i];

                    r[i] = rr;
                }
            }

        }

        private void tmrProjectile_Tick(object sender, EventArgs e)
        {
            MoveProjectile();

            this.Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (shootLeft == true)
                {
                    r.Add(new Rectangle(rSprite.X + 50, rSprite.Y + 22, 5, 5));
                    bulletxVel.Add(-45);
                    Plasma.Play();
                }
                if (shootRight == true)
                {
                    r.Add(new Rectangle(rSprite.X + 50, rSprite.Y + 22, 5, 5));
                    bulletxVel.Add(45);
                    Plasma.Play();
                }

                tmrProjectile.Start();
            }
        }

        private void tmrGravity_Tick(object sender, EventArgs e)
        {
            this.Refresh();

            t += 0.20;              //increment time during fall/rise 

            v2 = (v1 + (g * t));    //physics formula - ball velocity changes due to gravity (g) 

            rSprite.Y += (int)v2;     //move the ball

            //when the ball hits the ground...
            if (rSprite.Bottom > rFloor.Top)
            {           
                //reset the time
                t = 0;

                tmrGravity.Stop();
                {
                    if (rSprite.IntersectsWith(rFloor))
                    {                    
                        rSprite.Location = new Point(100, 950);                                                                  
                    }
                }
            }

            for (int x = 0; x < 30; x++)    //collision loop
            {
                if (rSprite.IntersectsWith(rPlatform[x]))
                {
                    // lands on top
                    if (rSprite.Bottom >= rPlatform[x].Top && rSprite.Top <= rPlatform[x].Top && rSprite.Right >= rPlatform[x].Left && rSprite.Left <= rPlatform[x].Right)
                    {
                        rSprite.Y = rPlatform[x].Top - SpriteSize;   //keep the ball ABOVE the ground

                        v1 = 0;  //bounce to gradual stop
                        t = 0;

                        this.Refresh();
                    }
                    // hits from bottom
                    else if (rSprite.Bottom >= rPlatform[x].Bottom && rSprite.Top >= rPlatform[x].Top && rSprite.Right >= rPlatform[x].Left && rSprite.Left <= rPlatform[x].Right)
                    {
                        v1 = 0;

                        this.Refresh();
                    }

                    // other instances of collision (right/left)
                    else
                    {
                        v1 = 0;                                          
                    }

                }
            }
        }
    }
}
