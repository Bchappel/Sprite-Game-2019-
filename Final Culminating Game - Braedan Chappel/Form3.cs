using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Final_Culminating_Game___Braedan_Chappel
{
    public partial class Form3 : Form
    {
        Image imgSprite = Properties.Resources.Player;
        int count, row, col, totalRows, totalCols, spriteWidth, spriteHeight;
        int spriteVel;
        bool goLeft, goRight;
        int PlayerHealth = 100; //player health
        int spriteLocationX = 25;
        int spriteLocationY = 800;
        int SpriteSize = 80; //Size of Sprite

        //Player Death
        Image imgDeadPlayer;
        int DeadPlayerNumber = 1;
        int TotalPlayerDeadImage = 3;
        //bool isVisible = true;
        Rectangle rDeadPlayer;

        //Boss
        int HellKnightNum = 1;
        int HellKnightImage = 14;
        Image imgHellKnight;
        bool isHellKnightDead = false;
        Rectangle rHellKnight;
        int HellKnightHealth = 1000;
        int hellknightLocationX = 1300; //Boss X-Location
        int hellknightlocationY = 810; //Boss Y-Location 920
        int hellKnightVelocity = 8;


        //Boss Entity States
        bool isSeekingPlayer = false;
        bool RightAttack = false;
        bool LeftAttack = false;
        bool idle = true;
        bool isLeft;
        bool isRight;
        int AttackAnimationNum = 1;
        int AttackAnimationImage = 64;


        bool PlayerOnLeftSide = false;
        bool PlayerOnRightSide = false;

        bool isAbove = false;

        bool Run = true;

        Rectangle rSprite, rightDetection;

        //Bullet
        bool shootLeft = false, shootRight = true;
        List<Rectangle> r = new List<Rectangle>();
        List<int> bulletxVel = new List<int>();
        List<int> bulletyVel = new List<int>();


        //Gravity - Sprite
        double g = 9.8; //Gravity Factor
        double t = 0;   //Time
        double v2;      //Velocity After Time
        double v1;      //Initial Velocity

        //Runtime   
        bool isGameOver = false;
        bool isGameWin = false;
        bool isPlayerAlive = true;
        bool StopAnimation;
        bool isAbleToShoot = true;
        
        int points = 0;
        int platformVel = 5;

        //Map & Level
        Rectangle rFloor;
        Rectangle[] rPlatform = new Rectangle[30];       

        //Jump Pads
        Rectangle rTeleporter;
        Image imgTeleporter = Properties.Resources.Teleporter;

        Rectangle rTeleporter2;
        Image imgTeleporter2 = Properties.Resources.Teleporter;

        //Sound
        SoundPlayer Plasma = new SoundPlayer(Properties.Resources.Plasma);
        SoundPlayer Death = new SoundPlayer(Properties.Resources.Death);

        int CacodemonNum = 1;
        int CacodemonImage = 21;

        int BossXVel = 5;



        //Face UI
        int faceUINum = 1;
        int faceUI = 3;
        Rectangle rFace;             
        Image imgFace = Properties.Resources._1001;


        //Other
        Image imgLogo = Properties.Resources.Logo;

        public Form3()
        {
            InitializeComponent();

            //Player Sprite
            totalCols = 7;
            totalRows = 4;
            spriteWidth = imgSprite.Width / totalCols;
            spriteHeight = imgSprite.Height / totalRows;
            rSprite = new Rectangle(spriteLocationX, spriteLocationY, SpriteSize, SpriteSize); //50, 1000
            spriteVel = 20;

            //Map & Level

            rFloor = new Rectangle(1234, 1020, 0, 0); //floor of the map

            //Walls
            rPlatform[0] = new Rectangle(0, 1021, 1920, 20); //pb1
            rPlatform[1] = new Rectangle(211, 844, 20, 197); //pb2
            rPlatform[2] = new Rectangle(1681, 844, 20, 197); //pb3
            rPlatform[3] = new Rectangle(1681, 844, 231, 20); //pb4
            rPlatform[4] = new Rectangle(0, 844, 231, 20); //pb5
            rPlatform[5] = new Rectangle(467, 472, 1000, 20); //pb6 middle long platform
            rPlatform[6] = new Rectangle(467, 240, 202, 20); //pb7 top left platform
            rPlatform[7] = new Rectangle(1265, 240, 202, 20); //pb8 top right platform

            rPlatform[18] = new Rectangle(0, 0, 10, 1080); //Left Wall
            rPlatform[19] = new Rectangle(1910, 12, 10, 1029); //Rigth Wall
   
            //Hell Knight
            rHellKnight = new Rectangle(hellknightLocationX, hellknightlocationY, 130, 208); //65,104
            imgHellKnight = Properties.Resources.LeftBossIdle1;

            //Dead Player
            rDeadPlayer = new Rectangle(spriteLocationX, spriteLocationY, SpriteSize, SpriteSize);
            imgDeadPlayer = Properties.Resources.DeadPlayer1;

            //Hit Detection Box
            rightDetection = new Rectangle(200, 800, 1500, 400);

            rFace = new Rectangle(1795, 30, 100, 125);

            rTeleporter = new Rectangle(340, 972, 50, 50); //bottom jump pad
            rTeleporter2 = new Rectangle(940, 504, 50, 50); //top jump pad

        }

        private void tmrAnimation2_Tick(object sender, EventArgs e)
        {
            if (PlayerOnLeftSide == true)
            {
                switch (CacodemonNum)
                {
                    case 1:               
                        imgHellKnight = Properties.Resources.LeftBossDeath1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.LeftBossDeath2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.LeftBossDeath3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.LeftBossDeath4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.LeftBossDeath5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.LeftBossDeath6;                                
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.LeftBossDeath7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.LeftBossDeath8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.LeftBossDeath9;
                        break;
                    case 10:
                        imgHellKnight = Properties.Resources.LeftBossDeath10;
                        break;
                    case 11:
                        imgHellKnight = Properties.Resources.LeftBossDeath11;
                        break;
                    case 12:
                        imgHellKnight = Properties.Resources.LeftBossDeath12;
                        break;
                    case 13:
                        imgHellKnight = Properties.Resources.LeftBossDeath13;
                        break;
                    case 14:
                        imgHellKnight = Properties.Resources.LeftBossDeath14;
                        break;
                    case 15:
                        imgHellKnight = Properties.Resources.LeftBossDeath15;
                        break;
                    case 16:
                        imgHellKnight = Properties.Resources.LeftBossDeath16;
                        break;
                    case 17:
                        imgHellKnight = Properties.Resources.LeftBossDeath17;
                        break;
                    case 18:
                        imgHellKnight = Properties.Resources.LeftBossDeath18F;
                        break;
                    case 19:
                        imgHellKnight = Properties.Resources.LeftBossDeath19F;
                        break;
                    case 20:
                        imgHellKnight = Properties.Resources.LeftBossDeath20F;
                        break;
                    case 21:
                        imgHellKnight = Properties.Resources.LeftBossDeath21F;

                        tmrAnimation2.Stop();
                        tmrSprite2.Stop();
                        StopAnimation = true;
                        break;
                }
            }

            if (PlayerOnRightSide  == true)
            {
                switch (CacodemonNum)
                {
                    case 1:
                        imgHellKnight = Properties.Resources.RightBossDeath1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.RightBossDeath2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.RightBossDeath3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.RightBossDeath4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.RightBossDeath5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.RightBossDeath6;
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.RightBossDeath7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.RightBossDeath8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.RightBossDeath9;
                        break;
                    case 10:
                        imgHellKnight = Properties.Resources.RightBossDeath10;
                        break;
                    case 11:
                        imgHellKnight = Properties.Resources.RightBossDeath11;
                        break;
                    case 12:
                        imgHellKnight = Properties.Resources.RightBossDeath12;
                        break;
                    case 13:
                        imgHellKnight = Properties.Resources.RightBossDeath13;
                        break;
                    case 14:
                        imgHellKnight = Properties.Resources.RightBossDeath14;
                        break;
                    case 15:
                        imgHellKnight = Properties.Resources.RightBossDeath15;
                        break;
                    case 16:
                        imgHellKnight = Properties.Resources.RightBossDeath16;
                        break;
                    case 17:
                        imgHellKnight = Properties.Resources.RightBossDeath17;
                        break;
                    case 18:
                        imgHellKnight = Properties.Resources.RightBossDeath18F;
                        break;
                    case 19:
                        imgHellKnight = Properties.Resources.RightBossDeath19F;
                        break;
                    case 20:
                        imgHellKnight = Properties.Resources.RightBossDeath20F;
                        break;
                    case 21:
                        imgHellKnight = Properties.Resources.RightBossDeath21F;
                        tmrAnimation2.Stop();
                        tmrSprite2.Stop();
                        StopAnimation = true;
                        break;
                }
           
            }

            CacodemonNum += 1;

            if (CacodemonNum > CacodemonImage)
            {
                CacodemonNum = 1;
            }

            this.Refresh();
        }

        private void delayTimer2_Tick(object sender, EventArgs e)
        {
            rTeleporter2.Y = rPlatform[5].Y - 45;

            //Moves the platforms down;
            rPlatform[5].Y += 4;
            rPlatform[6].Y += 4;
            rPlatform[7].Y += 4;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            rTeleporter2.Y = rPlatform[5].Y - 49;

            //enables full screen on start DO NOT USE breakpoint when code is active
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        
        private void tmrUI3_Tick(object sender, EventArgs e)
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
        
        private void GameTimer2_Tick(object sender, EventArgs e)
        {
            rDeadPlayer.Location = rSprite.Location; //sets the location of the death animation to the location of the sprite.
                        
            for (int x = 0; x < r.Count; x++)
            {
                if (r[x].IntersectsWith(rHellKnight))
                {
                    HellKnightHealth -= 10;
                }
            }

            if (HellKnightHealth <= 0)
            {
                Run = false;
                isHellKnightDead = true;

                tmrAnimation2.Start();
                tmrSpriteController2.Stop();

                if (StopAnimation == true)
                {
                    tmrAnimation2.Stop();
                    tmrSpriteController2.Stop();
                }

                hellKnightVelocity = 0;
            }


            //Area Detection (AI Pathfinding)

            if (rSprite.X <= rHellKnight.X && rSprite.Y >= rHellKnight.Y) //if Player is to the left of the boss
            {

                PlayerOnLeftSide = true;

                if (rHellKnight.IntersectsWith(rSprite))
                {
                    isSeekingPlayer = false;                   

                    if (PlayerHealth == 0)
                    {
                        if (isHellKnightDead == false)
                        {
                            spriteVel = 0;
                        }
                    }

                    LeftAttack = true;
                    RightAttack = false;
                    Run = false;

                }


                if (isSeekingPlayer == true)
                {
                    if (isHellKnightDead == false)
                    {
                        isLeft = true;
                        isRight = false;
                        isAbove = false;
                        rHellKnight.X -= BossXVel;
                    }

                }
            }




            if (rSprite.X >= rHellKnight.X && rSprite.Y >= rHellKnight.Y) //if Player is to the Right of the boss
            {

                PlayerOnRightSide = true;

                if (rHellKnight.IntersectsWith(rSprite))
                {

                    isSeekingPlayer = false;
                    

                    if (PlayerHealth == 0)
                    {
                        if (isHellKnightDead == false)
                        {
                            spriteVel = 0;
                        }
                    }

                    RightAttack = true;
                    LeftAttack = false;
                    Run = false;

                }


                if (isSeekingPlayer == true)
                {

                    if (isHellKnightDead == false)
                    {
                        isRight = true;
                        isLeft = false;
                        isAbove = false;
                        rHellKnight.X += BossXVel;
                    }
                }
            }

            if (isHellKnightDead == false && rSprite.IntersectsWith(rHellKnight))
            {
                PlayerHealth = 0;
                isPlayerAlive = false;
            }

            if (rSprite.Y <= rHellKnight.Y) //if Player is above the boss
            {
                idle = true;
                isAbove = true;
                isRight = false;
                isLeft = false;
                hellKnightVelocity = 0;
                isSeekingPlayer = false;             
            }

            if (isSeekingPlayer == false)
            {
                hellKnightVelocity = 0;
            }

            
            //Intersects with teleporter
            if (rSprite.IntersectsWith(rTeleporter))
            {
                v1 = -50;
                tmrGravity2.Start();
                
            }
            if (rSprite.IntersectsWith(rTeleporter2))
            {
                v1 = -50;
                tmrGravity2.Start();
            }

            if (PlayerHealth <= 0)    
            {
                isGameOver = true;
                isPlayerAlive = false;
                isAbleToShoot = false;
                tmrSprite2.Stop();
            }

            for (int i = 0; i < 30; i++)
            {
                if (rSprite.IntersectsWith(rPlatform[i]))
                {
                    if (goLeft == true && rSprite.Left <= rPlatform[i].Right && rSprite.Left > rPlatform[i].Left)
                    {
                        rSprite.X += spriteVel;
                        tmrSprite2.Stop();
                    }

                    if (goRight == true && rSprite.Right >= rPlatform[i].Left && rSprite.Left < rPlatform[i].Left)
                    {
                        rSprite.X -= spriteVel;
                        tmrSprite2.Stop();
                    }
                }
            }

            if (isHellKnightDead == false)
            {
                if (rSprite.IntersectsWith(rightDetection))
                {
                    isSeekingPlayer = true;                    
                }
            }

            if (isSeekingPlayer == true)
            {
                
            }
        }

        private void tmrAnimationEngine2_Tick(object sender, EventArgs e)
        {
            //Controls the Dead Player Animation
            if (isPlayerAlive == false)
            {
                switch (DeadPlayerNumber) //imgDeadPlayer
                {
                    case 1:
                        imgDeadPlayer = Properties.Resources.DeadPlayer1;
                        break;
                    case 2:
                        imgDeadPlayer = Properties.Resources.DeadPlayer2;
                        break;
                    case 3:
                        imgDeadPlayer = Properties.Resources.DeadPlayer3;
                        tmrAnimationEngine2.Stop(); //Stops the timer when the animation concludes
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

        private void tmrSpriteController2_Tick(object sender, EventArgs e)
        {

            if (Run == true)
            {

                if (isSeekingPlayer == false) //If not looking for player it is in an idle state
                {
                    switch (HellKnightNum)
                    {
                        case 1:
                            imgHellKnight = Properties.Resources.LeftBossIdle1;
                            break;
                        case 2:
                            imgHellKnight = Properties.Resources.LeftBossIdle2;
                            break;
                        case 3:
                            imgHellKnight = Properties.Resources.LeftBossIdle3;
                            break;
                        case 4:
                            imgHellKnight = Properties.Resources.LeftBossIdle4;
                            break;
                        case 5:
                            imgHellKnight = Properties.Resources.LeftBossIdle5;
                            break;
                        case 6:
                            imgHellKnight = Properties.Resources.LeftBossIdle6;
                            break;
                        case 7:
                            imgHellKnight = Properties.Resources.LeftBossIdle7;
                            break;
                        case 8:
                            imgHellKnight = Properties.Resources.LeftBossIdle8;
                            break;
                        case 9:
                            imgHellKnight = Properties.Resources.LeftBossIdle9;
                            break;
                        case 10:
                            imgHellKnight = Properties.Resources.LeftBossIdle10;
                            break;
                    }
                }

                if (isLeft == true)
                {
                    if (isSeekingPlayer == true)
                    {
                        tmrSpriteController2.Interval = 75;

                        switch (HellKnightNum)
                        {
                            case 1:
                                imgHellKnight = Properties.Resources.LeftBossRun1;
                                break;
                            case 2:
                                imgHellKnight = Properties.Resources.LeftBossRun2;
                                break;
                            case 3:
                                imgHellKnight = Properties.Resources.LeftBossRun3;
                                break;
                            case 4:
                                imgHellKnight = Properties.Resources.LeftBossRun4;
                                break;
                            case 5:
                                imgHellKnight = Properties.Resources.LeftBossRun5;
                                break;
                            case 6:
                                imgHellKnight = Properties.Resources.LeftBossRun6;
                                break;
                            case 7:
                                imgHellKnight = Properties.Resources.LeftBossRun7;
                                break;
                            case 8:
                                imgHellKnight = Properties.Resources.LeftBossRun8;
                                break;
                            case 9:
                                imgHellKnight = Properties.Resources.LeftBossRun9;
                                break;
                            case 10:
                                imgHellKnight = Properties.Resources.LeftBossRun10;
                                break;
                            case 11:
                                imgHellKnight = Properties.Resources.LeftBossRun11;
                                break;
                            case 12:
                                imgHellKnight = Properties.Resources.LeftBossRun12;
                                break;
                            case 13:
                                imgHellKnight = Properties.Resources.LeftBossRun13;
                                break;
                            case 14:
                                imgHellKnight = Properties.Resources.LeftBossRun14;
                                break;
                        }
                    }
                }

                if (isRight == true)
                {
                    tmrSpriteController2.Interval = 75;

                    switch (HellKnightNum)
                    {
                        case 1:
                            imgHellKnight = Properties.Resources.RightBossRun1;
                            break;
                        case 2:
                            imgHellKnight = Properties.Resources.RightBossRun2;
                            break;
                        case 3:
                            imgHellKnight = Properties.Resources.RightBossRun3;
                            break;
                        case 4:
                            imgHellKnight = Properties.Resources.RightBossRun4;
                            break;
                        case 5:
                            imgHellKnight = Properties.Resources.RightBossRun5;
                            break;
                        case 6:
                            imgHellKnight = Properties.Resources.RightBossRun6;
                            break;
                        case 7:
                            imgHellKnight = Properties.Resources.RightBossRun7;
                            break;
                        case 8:
                            imgHellKnight = Properties.Resources.RightBossRun8;
                            break;
                        case 9:
                            imgHellKnight = Properties.Resources.RightBossRun9;
                            break;
                        case 10:
                            imgHellKnight = Properties.Resources.RightBossRun10;
                            break;
                        case 11:
                            imgHellKnight = Properties.Resources.RightBossRun11;
                            break;
                        case 12:
                            imgHellKnight = Properties.Resources.RightBossRun12;
                            break;
                        case 13:
                            imgHellKnight = Properties.Resources.RightBossRun13;
                            break;
                    }
                }
            }


            if (LeftAttack == true)
            {
                
                switch (AttackAnimationNum)
                {
                    case 1:
                        imgHellKnight = Properties.Resources.LeftBossAttack1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.LeftBossAttack2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.LeftBossAttack3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.LeftBossAttack4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.LeftBossAttack5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.LeftBossAttack6;
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.LeftBossAttack7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.LeftBossAttack8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.LeftBossAttack9;
                        break;
                    case 10:
                        imgHellKnight = Properties.Resources.LeftBossAttack10;
                        break;
                    case 11:
                        imgHellKnight = Properties.Resources.LeftBossAttack11;
                        break;
                    case 12:
                        imgHellKnight = Properties.Resources.LeftBossAttack12;
                        break;
                    case 13:
                        imgHellKnight = Properties.Resources.LeftBossAttack13;
                        break;
                    case 14:
                        imgHellKnight = Properties.Resources.LeftBossAttack14;
                        break;
                    case 15:
                        imgHellKnight = Properties.Resources.LeftBossAttack15;
                        break;
                    case 16:
                        imgHellKnight = Properties.Resources.LeftBossAttack16;
                        break;
                    case 17:
                        imgHellKnight = Properties.Resources.LeftBossAttack17;
                        break;
                    case 18:
                        imgHellKnight = Properties.Resources.LeftBossAttack18;
                        break;
                    case 19:
                        imgHellKnight = Properties.Resources.LeftBossAttack19;
                        break;
                    case 20:
                        imgHellKnight = Properties.Resources.LeftBossAttack20;
                        break;
                    case 21:
                        imgHellKnight = Properties.Resources.LeftBossAttack21;
                        break;
                    case 22:
                        imgHellKnight = Properties.Resources.LeftBossAttack22;
                        break;
                    case 23:
                        imgHellKnight = Properties.Resources.LeftBossAttack23;
                        break;
                    case 24:
                        imgHellKnight = Properties.Resources.LeftBossAttack24;
                        break;
                    case 25:
                        imgHellKnight = Properties.Resources.LeftBossAttack25;
                        break;
                    case 26:
                        imgHellKnight = Properties.Resources.LeftBossAttack26;
                        break;
                    case 27:
                        imgHellKnight = Properties.Resources.LeftBossAttack27;
                        break;
                    case 28:
                        imgHellKnight = Properties.Resources.LeftBossAttack28;
                        break;
                    case 29:
                        imgHellKnight = Properties.Resources.LeftBossAttack29;
                        break;
                    case 30:
                        imgHellKnight = Properties.Resources.LeftBossAttack30;
                        break;
                    case 31:
                        imgHellKnight = Properties.Resources.LeftBossAttack31;
                        break;
                    case 32:
                        imgHellKnight = Properties.Resources.LeftBossAttack32;
                        break;
                    case 33:
                        imgHellKnight = Properties.Resources.LeftBossAttack33;
                        break;
                    case 34:
                        imgHellKnight = Properties.Resources.LeftBossAttack34;
                        break;
                    case 35:
                        imgHellKnight = Properties.Resources.LeftBossAttack35;
                        break;
                    case 36:
                        imgHellKnight = Properties.Resources.LeftBossAttack36;
                        break;
                    case 37:
                        imgHellKnight = Properties.Resources.LeftBossAttack37;
                        break;
                    case 38:
                        imgHellKnight = Properties.Resources.LeftBossAttack38;
                        break;
                    case 39:
                        imgHellKnight = Properties.Resources.LeftBossAttack39;
                        break;
                    case 40:
                        imgHellKnight = Properties.Resources.LeftBossAttack30;
                        break;
                    case 41:
                        imgHellKnight = Properties.Resources.LeftBossAttack41;
                        break;
                    case 42:
                        imgHellKnight = Properties.Resources.LeftBossAttack42;
                        break;
                    case 43:
                        imgHellKnight = Properties.Resources.LeftBossAttack43;
                        break;
                    case 44:
                        imgHellKnight = Properties.Resources.LeftBossAttack44;
                        break;
                    case 45:
                        imgHellKnight = Properties.Resources.LeftBossAttack45;
                        break;
                    case 46:
                        imgHellKnight = Properties.Resources.LeftBossAttack46;
                        break;
                    case 47:
                        imgHellKnight = Properties.Resources.LeftBossAttack47;
                        break;
                    case 48:
                        imgHellKnight = Properties.Resources.LeftBossAttack48;
                        break;
                    case 49:
                        imgHellKnight = Properties.Resources.LeftBossAttack49;
                        break;
                    case 50:
                        imgHellKnight = Properties.Resources.LeftBossAttack50;
                        break;
                    case 51:
                        imgHellKnight = Properties.Resources.LeftBossAttack51;
                        break;
                    case 52:
                        imgHellKnight = Properties.Resources.LeftBossAttack52;
                        break;
                    case 53:
                        imgHellKnight = Properties.Resources.LeftBossAttack53;
                        break;
                    case 54:
                        imgHellKnight = Properties.Resources.LeftBossAttack54;
                        break;
                    case 55:
                        imgHellKnight = Properties.Resources.LeftBossAttack55;
                        break;
                    case 56:
                        imgHellKnight = Properties.Resources.LeftBossAttack56;
                        break;
                    case 57:
                        imgHellKnight = Properties.Resources.LeftBossAttack57;
                        break;
                    case 58:
                        imgHellKnight = Properties.Resources.LeftBossAttack58;
                        break;
                    case 59:
                        imgHellKnight = Properties.Resources.LeftBossAttack59;
                        break;
                    case 60:
                        imgHellKnight = Properties.Resources.LeftBossAttack60;
                        break;
                    case 61:
                        imgHellKnight = Properties.Resources.LeftBossAttack61;
                        break;
                    case 62:
                        imgHellKnight = Properties.Resources.LeftBossAttack62;
                        break;
                    case 63:
                        imgHellKnight = Properties.Resources.LeftBossAttack63;
                        break;
                    case 64:
                        imgHellKnight = Properties.Resources.LeftBossAttack64;
                        tmrSpriteController2.Enabled = false;
                        break;
                }            
               
                AttackAnimationNum += 1;

                if (AttackAnimationNum > AttackAnimationImage)
                {

                    AttackAnimationNum = 1;

                }

            }


            if (RightAttack == true)
            {

                switch (AttackAnimationNum)
                {
                    case 1:
                        imgHellKnight = Properties.Resources.RightBossAttack1;
                        break;
                    case 2:
                        imgHellKnight = Properties.Resources.RightBossAttack2;
                        break;
                    case 3:
                        imgHellKnight = Properties.Resources.RightBossAttack3;
                        break;
                    case 4:
                        imgHellKnight = Properties.Resources.RightBossAttack4;
                        break;
                    case 5:
                        imgHellKnight = Properties.Resources.RightBossAttack5;
                        break;
                    case 6:
                        imgHellKnight = Properties.Resources.RightBossAttack6;
                        break;
                    case 7:
                        imgHellKnight = Properties.Resources.RightBossAttack7;
                        break;
                    case 8:
                        imgHellKnight = Properties.Resources.RightBossAttack8;
                        break;
                    case 9:
                        imgHellKnight = Properties.Resources.RightBossAttack9;
                        break;
                    case 10:
                        imgHellKnight = Properties.Resources.RightBossAttack10;
                        break;
                    case 11:
                        imgHellKnight = Properties.Resources.RightBossAttack11;
                        break;
                    case 12:
                        imgHellKnight = Properties.Resources.RightBossAttack12;
                        break;
                    case 13:
                        imgHellKnight = Properties.Resources.RightBossAttack13;
                        break;
                    case 14:
                        imgHellKnight = Properties.Resources.RightBossAttack14;
                        break;
                    case 15:
                        imgHellKnight = Properties.Resources.RightBossAttack15;
                        break;
                    case 16:
                        imgHellKnight = Properties.Resources.RightBossAttack16;
                        break;
                    case 17:
                        imgHellKnight = Properties.Resources.RightBossAttack17;
                        break;
                    case 18:
                        imgHellKnight = Properties.Resources.RightBossAttack18;
                        break;
                    case 19:
                        imgHellKnight = Properties.Resources.RightBossAttack19;
                        break;
                    case 20:
                        imgHellKnight = Properties.Resources.RightBossAttack20;
                        break;
                    case 21:
                        imgHellKnight = Properties.Resources.RightBossAttack21;
                        break;
                    case 22:
                        imgHellKnight = Properties.Resources.RightBossAttack22;
                        break;
                    case 23:
                        imgHellKnight = Properties.Resources.RightBossAttack23;
                        break;
                    case 24:
                        imgHellKnight = Properties.Resources.RightBossAttack24;
                        break;
                    case 25:
                        imgHellKnight = Properties.Resources.RightBossAttack25;
                        break;
                    case 26:
                        imgHellKnight = Properties.Resources.RightBossAttack26;
                        break;
                    case 27:
                        imgHellKnight = Properties.Resources.RightBossAttack27;
                        break;
                    case 28:
                        imgHellKnight = Properties.Resources.RightBossAttack28;
                        break;
                    case 29:
                        imgHellKnight = Properties.Resources.RightBossAttack29;
                        break;
                    case 30:
                        imgHellKnight = Properties.Resources.RightBossAttack30;
                        break;
                    case 31:
                        imgHellKnight = Properties.Resources.RightBossAttack31;
                        break;
                    case 32:
                        imgHellKnight = Properties.Resources.RightBossAttack32;
                        break;
                    case 33:
                        imgHellKnight = Properties.Resources.RightBossAttack33;
                        break;
                    case 34:
                        imgHellKnight = Properties.Resources.RightBossAttack34;
                        break;
                    case 35:
                        imgHellKnight = Properties.Resources.RightBossAttack35;
                        break;
                    case 36:
                        imgHellKnight = Properties.Resources.RightBossAttack36;
                        break;
                    case 37:
                        imgHellKnight = Properties.Resources.RightBossAttack37;
                        break;
                    case 38:
                        imgHellKnight = Properties.Resources.RightBossAttack38;
                        break;
                    case 39:
                        imgHellKnight = Properties.Resources.RightBossAttack39;
                        break;
                    case 40:
                        imgHellKnight = Properties.Resources.RightBossAttack30;
                        break;
                    case 41:
                        imgHellKnight = Properties.Resources.RightBossAttack41;
                        break;
                    case 42:
                        imgHellKnight = Properties.Resources.RightBossAttack42;
                        break;
                    case 43:
                        imgHellKnight = Properties.Resources.RightBossAttack43;
                        break;
                    case 44:
                        imgHellKnight = Properties.Resources.RightBossAttack44;
                        break;
                    case 45:
                        imgHellKnight = Properties.Resources.RightBossAttack45;
                        break;
                    case 46:
                        imgHellKnight = Properties.Resources.RightBossAttack46;
                        break;
                    case 47:
                        imgHellKnight = Properties.Resources.RightBossAttack47;
                        break;
                    case 48:
                        imgHellKnight = Properties.Resources.RightBossAttack48;
                        break;
                    case 49:
                        imgHellKnight = Properties.Resources.RightBossAttack49;
                        break;
                    case 50:
                        imgHellKnight = Properties.Resources.RightBossAttack50;
                        break;
                    case 51:
                        imgHellKnight = Properties.Resources.RightBossAttack51;
                        break;
                    case 52:
                        imgHellKnight = Properties.Resources.RightBossAttack52;
                        break;
                    case 53:
                        imgHellKnight = Properties.Resources.RightBossAttack53;
                        break;
                    case 54:
                        imgHellKnight = Properties.Resources.RightBossAttack54;
                        break;
                    case 55:
                        imgHellKnight = Properties.Resources.RightBossAttack55;
                        break;
                    case 56:
                        imgHellKnight = Properties.Resources.RightBossAttack56;
                        break;
                    case 57:
                        imgHellKnight = Properties.Resources.RightBossAttack57;
                        break;
                    case 58:
                        imgHellKnight = Properties.Resources.RightBossAttack58;
                        break;
                    case 59:
                        imgHellKnight = Properties.Resources.RightBossAttack59;
                        break;
                    case 60:
                        imgHellKnight = Properties.Resources.RightBossAttack60;
                        break;
                    case 61:
                        imgHellKnight = Properties.Resources.RightBossAttack61;
                        break;
                    case 62:
                        imgHellKnight = Properties.Resources.RightBossAttack62;
                        break;
                    case 63:
                        imgHellKnight = Properties.Resources.RightBossAttack63;
                        break;
                    case 64:
                        imgHellKnight = Properties.Resources.RightBossAttack64;
                        tmrSpriteController2.Enabled = false;
                        break;
                }

                AttackAnimationNum += 1;

                if (AttackAnimationNum > AttackAnimationImage)
                {
                    AttackAnimationNum = 1;
                }

            }




            //Boss

            HellKnightNum += 1;

            if (HellKnightNum > HellKnightImage)
            {
                HellKnightNum = 1;
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



            this.Refresh();
        }

        private void tmrSprite2_Tick(object sender, EventArgs e)
        {
            //Player Sprite Controller

            if (goLeft == true)
            {
                rSprite.X -= spriteVel; //Moves Sprite Left
            }

            if (goRight == true)
            {
                rSprite.X += spriteVel; //Moves Sprite Right
            }


            if (count >= (totalRows * totalCols))
            {
                count = 0;
            }

            col = count % totalCols;

            count += 1;

            this.Refresh();
        }

        private void tmrEnemy2_Tick(object sender, EventArgs e)
        {

        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                //spriteVel = 25;
                goLeft = true;
                row = 3;
                tmrSprite2.Start();
                shootLeft = true;
                shootRight = false;
            }

            if (e.KeyData == Keys.D)
            {
                //spriteVel = 25;
                goRight = true;
                row = 2;
                tmrSprite2.Start();
                shootRight = true;
                shootLeft = false;
            }

            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyData == Keys.H)
            {
                

            }

            if (e.KeyData == Keys.Space)
            {
                v1 = -30; //Increase Jump Height

                tmrGravity2.Start();
            }
        }

        private void Form3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                goLeft = false;
                tmrSprite2.Stop();
            }

            if (e.KeyData == Keys.D)
            {
                goRight = false;
                tmrSprite2.Stop();
            }
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            //Collision Bar (HitBox)
            e.Graphics.FillRectangle(Brushes.Black, rightDetection);

            for (int x = 0; x < r.Count; x++)
            {
                e.Graphics.FillEllipse(Brushes.Red, r[x]); //Bullet

                if (isRight == true)
                {





                }

                if (isLeft == true)
                {





                }
            }

            //Player
            if (PlayerHealth > 0)
            {
                e.Graphics.DrawString(PlayerHealth + " HP".ToString(), new System.Drawing.Font("Arial", 12), Brushes.Blue, rSprite.X + 15, rSprite.Y - 25);

                e.Graphics.DrawImage(imgSprite, rSprite, new RectangleF(col * spriteWidth, row * spriteHeight, spriteWidth, spriteHeight), GraphicsUnit.Pixel);
            }

            //Map & Level
            e.Graphics.FillRectangle(Brushes.Red, rFloor);

            for (int d = 0; d < 30; d++)
            {
                e.Graphics.FillRectangle(Brushes.Blue, rPlatform[d]);

                e.Graphics.FillRectangle(Brushes.Black, rPlatform[18]);
                e.Graphics.FillRectangle(Brushes.Black, rPlatform[19]);
            }

            //Text and UI
            if (isGameOver == true)
            {
                e.Graphics.DrawString("You Died (ESC to Quit)".ToString(), new System.Drawing.Font("Arial", 32), Brushes.Red, this.Width / 2 - 280, 215);
            }

            if (isGameWin == true)
            {
                e.Graphics.DrawString("You Win, Score: " + points.ToString(), new System.Drawing.Font("Arial", 32), Brushes.LimeGreen, this.Width / 2 - 169, 240);
            }

            e.Graphics.DrawString("Score: " + points.ToString(), new System.Drawing.Font("Arial", 16), Brushes.LimeGreen, 1800, 0);

            //Boss
            if (HellKnightHealth > 0)
            {
                e.Graphics.DrawString(HellKnightHealth + " Hell Knight".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red, rHellKnight.X, rHellKnight.Y-120);
            }


            //Boss Image
            e.Graphics.DrawImage(imgHellKnight, rHellKnight);
            
            //Player UI Face
            e.Graphics.DrawImage(imgFace, rFace);


            if (isPlayerAlive == false)
            {
                e.Graphics.DrawImage(imgDeadPlayer, rDeadPlayer);
            }

            e.Graphics.DrawImage(imgTeleporter, rTeleporter);
            e.Graphics.DrawImage(imgTeleporter2, rTeleporter2);

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

        private void tmrProjectile2_Tick(object sender, EventArgs e)
        {
            MoveProjectile();

            this.Refresh();
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {

            if (isAbleToShoot == true)
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

                    tmrProjectile2.Start();
                }
            }
        }
            

        private void tmrGravity2_Tick(object sender, EventArgs e)
        {
            if (isPlayerAlive == true)
            {
                this.Refresh();

                t += 0.20;              //increment time during fall/rise 

                v2 = (v1 + (g * t));    //Physics Formula 

                rSprite.Y += (int)v2;     //move the Player

                //g = Gravity Factor
                //t = Time
                //v2 = Velocity After Time
                //v1 = Initial Velocity

                if (rSprite.Bottom > rFloor.Top)
                {
                    //reset the time
                    t = 0;

                    tmrGravity2.Stop();
                    {
                        if (rSprite.IntersectsWith(rFloor))
                        {
                            //rSprite.Location = new Point(100, 950);
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
}
