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
    //- music (by aidan)
    //- multiple levels/ eng game
    //- Many Enemies
    //- walls and ladders, lifts, platforms
    //- doors with key cards
    //- low poly textures
    //- UI
    //- proper settings
    //- use of lists, arrays, sprites, 

    public partial class Form2 : Form
    {
        //Player Sprite
        Image imgSprite = Properties.Resources.Player;
        int count, row, col, totalRows, totalCols, spriteWidth, spriteHeight;
        int spriteVel;
        bool goLeft, goRight;
        int PlayerHealth = 100; //player health
        int spriteLocationX = 25;
        int spriteLocationY = 950;
        int SpriteSize = 80; //Size of Sprite

        //Player Death
        Image imgDeadPlayer;
        int DeadPlayerNumber = 1;
        int TotalPlayerDeadImage = 3;
        //bool isVisible = true;
        Rectangle rDeadPlayer;

        //Enemy 1 - Cacodemon
        int CacodemonNum = 1;
        int CacodemonImage = 30;
        Image imgCacoDemon;
        bool isCacoDemonDead = false;
        Rectangle rCacoDemon;
        int CacoDemonHealth = 100;
        int CacoDemonX = 1800;
        int CacoDemonY = 200;
        int DemonDeathVel = 10;

        //Enemy1 Velocitys
        int DemonXVel = 4;
        int DemonYVel = 4;
        

        //Enemy 2 - HellKnight
        int HellKnightNum = 1;
        int HellKnightImage = 11;
        Image imgHellKnight;
        bool isHellKnightDead = false;
        Rectangle rHellKnight;
        int HellKnightHealth = 200;
        int hellknightLocationX = 2000; //Hell Knight X-Location
        int hellknightlocationY = 897; //Hell Knight Y-Location
        int hellKnightVelocity = 8;
        bool isSeekingPlayer = false;
        bool Attack = false;
        bool idle = true;


        //Key Cards
        bool KeyDisplay = false;       
       
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
        bool isAlive = true;
        bool isGameOver = false;
        bool isGameWin = false;
        bool isPlayerAlive = true;
        bool isLeft;
        bool isRight;
        bool Load3 = false;
        bool isAbleToShoot = true;


        int points = 0;
        

        int platformVel = 2;

        //Map & Level
        Rectangle rFloor;
        Rectangle[] rPlatform = new Rectangle[30];
        Rectangle rRedKeyCard;

        //Jump Pads
        Rectangle rTeleporter;
        Image imgTeleporter = Properties.Resources.Teleporter;

        Rectangle rTeleporter2;
        Image imgTeleporter2 = Properties.Resources.Teleporter;

        //Sound
        SoundPlayer Plasma = new SoundPlayer(Properties.Resources.Plasma);
        SoundPlayer Death = new SoundPlayer(Properties.Resources.Death);

        //Face UI
        int faceUINum = 1;
        int faceUI = 3;
        Rectangle rFace;
        Image imgFace = Properties.Resources._1001;

        //Red Keycard
        Image imgRedKeyCard = Properties.Resources.RedKey;



        Image imgCheckpoint = Properties.Resources.CheckPoint;
        Rectangle rCheckPoint;

        Image imgLogo = Properties.Resources.Logo;

        public Form2()
        {
            InitializeComponent();

            //Player Sprite
            totalCols = 7;
            totalRows = 4;
            spriteWidth = imgSprite.Width / totalCols;
            spriteHeight = imgSprite.Height / totalRows;
            rSprite = new Rectangle(spriteLocationX, spriteLocationY, SpriteSize, SpriteSize); //50, 1000
            spriteVel = 20;
          
            //Hitbox
            rightDetection = new Rectangle(250, 100, 1000, 20);

            //Map & Level

            rFloor = new Rectangle(1234, 1020, 0, 0); //floor of the map

            rRedKeyCard = new Rectangle(225, 140, 30, 40); //Yellow Key Card;

            //Walls
            rPlatform[0] = new Rectangle(0, 1021, 1920, 20); //pb1
            rPlatform[1] = new Rectangle(196, 944, 110, 10); //pb15
            rPlatform[2] = new Rectangle(427, 827, 130, 10); //pb16
            rPlatform[3] = new Rectangle(557, 712, 20, 329); //pb2
            rPlatform[4] = new Rectangle(557, 712, 577, 20); //pb3
            rPlatform[5] = new Rectangle(1114, 184, 20, 548); //pb9
            rPlatform[6] = new Rectangle(0, 426, 577, 20); //pb4
            rPlatform[7] = new Rectangle(557, 184, 20, 262); //pb5
            rPlatform[8] = new Rectangle(172, 184, 221, 20); //pb6
            rPlatform[10] = new Rectangle(373, 0, 20, 204); //pb7 (moving object)
            rPlatform[11] = new Rectangle(1508, 956, 0, 0); //pb8 (sliding object) NOT IN USE YET
            rPlatform[12] = new Rectangle(1114, 184, 221, 20); //pb10
            rPlatform[20] = new Rectangle(1329, 184, 20, 330);//pb20

            //Door
            rPlatform[17] = new Rectangle(203, -600, 0, 0); //215 20


            rPlatform[9] = new Rectangle(1350, 337, 221, 10); //pb12
            rPlatform[13] = new Rectangle(1682, 526, 221, 10); //pb13
            rPlatform[14] = new Rectangle(1370, 712, 533, 20); //pb11
            rPlatform[15] = new Rectangle(667, 184, 150, 10); //Slider Platform
            rPlatform[16] = new Rectangle(1114, 0, 20, 204); //Wall removed when KeyCard Collected


            rPlatform[18] = new Rectangle(0, 0, 10, 1080); //Left Wall
            rPlatform[19] = new Rectangle(1910, 12, 10, 1029); //Rigth Wall

            //Hell Knight
            rHellKnight = new Rectangle(hellknightLocationX, hellknightlocationY, 200, 150);
            imgHellKnight = Properties.Resources.LeftRun1;

            //CacoDemon
            rCacoDemon = new Rectangle(CacoDemonX, CacoDemonY, 70, 70);
            imgCacoDemon = Properties.Resources.Frame1;

            //Dead Player
            rDeadPlayer = new Rectangle(spriteLocationX, spriteLocationY, SpriteSize, SpriteSize);
            imgDeadPlayer = Properties.Resources.DeadPlayer1;

            //Hit Detection Box
            rightDetection = new Rectangle(900, 1000, 1000, 5);

            rFace = new Rectangle(1795, 30, 100, 125);

            rTeleporter = new Rectangle(800, 660, 50, 50);
            rTeleporter2 = new Rectangle(50, 376, 50, 50);

            rCheckPoint = new Rectangle(600, 925, 70, 100);
            

        }

        public void tmrAnimation1_Tick(object sender, EventArgs e)
        {       
            switch (CacodemonNum)
            {
                case 1:
                     imgCacoDemon = Properties.Resources.Death1;
                     break;
                case 2:
                     imgCacoDemon = Properties.Resources.Death2;
                     break;
               case 3:
                     imgCacoDemon = Properties.Resources.Death3;
                     break;
               case 4:
                     imgCacoDemon = Properties.Resources.Death4;
                     break;
               case 5:
                     imgCacoDemon = Properties.Resources.Death5;
                     break;
               case 6:
                     imgCacoDemon = Properties.Resources.Death6;
                     tmrAnimation1.Enabled = false;
                     break;
            }
            
            CacodemonNum += 1;

            if (CacodemonNum > CacodemonImage)
            {
                CacodemonNum = 1;
            }

            this.Refresh();
        }

        public void delayTimer1_Tick(object sender, EventArgs e)
        {
            KeyDisplay = false;
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            //enables full screen on start DO NOT USE breakpoint when code is active
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public void tmrEnemy1_Tick(object sender, EventArgs e)
        {        
                switch (CacodemonNum)
                {
                    case 1:
                        imgCacoDemon = Properties.Resources.Frame1;
                        break;
                    case 2:
                        imgCacoDemon = Properties.Resources.Frame2;
                        break;
                    case 3:
                        imgCacoDemon = Properties.Resources.Frame3;
                        break;
                    case 4:
                        imgCacoDemon = Properties.Resources.Frame4;
                        break;
                    case 5:
                        imgCacoDemon = Properties.Resources.Frame5;
                        break;
                    case 6:
                        imgCacoDemon = Properties.Resources.Frame6;
                        break;
                    case 7:
                        imgCacoDemon = Properties.Resources.Frame7;
                        break;
                    case 8:
                        imgCacoDemon = Properties.Resources.Frame8;
                        break;
                    case 9:
                        imgCacoDemon = Properties.Resources.Frame9;
                        break;
                    case 10:
                        imgCacoDemon = Properties.Resources.Frame10;
                        break;
                    case 11:
                        imgCacoDemon = Properties.Resources.Frame11;
                        break;
                    case 12:
                        imgCacoDemon = Properties.Resources.Frame12;
                        break;
                    case 13:
                        imgCacoDemon = Properties.Resources.Frame13;
                        break;
                    case 14:
                        imgCacoDemon = Properties.Resources.Frame14;
                        break;
                    case 15:
                        imgCacoDemon = Properties.Resources.Frame15;
                        break;
                    case 16:
                        imgCacoDemon = Properties.Resources.Frame16;
                        break;
                    case 17:
                        imgCacoDemon = Properties.Resources.Frame17;
                        break;
                    case 18:
                        imgCacoDemon = Properties.Resources.Frame18;
                        break;
                    case 19:
                        imgCacoDemon = Properties.Resources.Frame19;
                        break;
                    case 20:
                        imgCacoDemon = Properties.Resources.Frame20;
                        break;
                    case 21:
                        imgCacoDemon = Properties.Resources.Frame21;
                        break;
                    case 22:
                        imgCacoDemon = Properties.Resources.Frame22;
                        break;
                    case 23:
                        imgCacoDemon = Properties.Resources.Frame23;
                        break;
                    case 24:
                        imgCacoDemon = Properties.Resources.Frame24;
                        break;
                    case 25:
                        imgCacoDemon = Properties.Resources.Frame25;
                        break;
                    case 26:
                        imgCacoDemon = Properties.Resources.Frame26;
                        break;
                    case 27:
                        imgCacoDemon = Properties.Resources.Frame27;
                        break;
                    case 28:
                        imgCacoDemon = Properties.Resources.Frame28;
                        break;
                    case 29:
                        imgCacoDemon = Properties.Resources.Frame29;
                        break;
                    case 30:
                        imgCacoDemon = Properties.Resources.Frame30;
                        break;
                }

            CacodemonNum += 1;

            if (CacodemonNum > CacodemonImage)
            {
                CacodemonNum = 1;
            }


            this.Refresh();
           
        }

        private void tmrUI1_Tick(object sender, EventArgs e)
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
        
        private void GameTimer1_Tick(object sender, EventArgs e)
        {
            rDeadPlayer.Location = rSprite.Location; //sets the location of the death animation to the location of the sprite.

            for (int x = 0; x < r.Count; x++)
            {
                if (r[x].IntersectsWith(rCacoDemon))                {
                    if (isCacoDemonDead == false)
                    {
                        CacoDemonHealth -= 10;

                        if (CacoDemonHealth <= 0)
                        {
                            isCacoDemonDead = true;

                            DemonXVel = 0;

                            tmrEnemy1.Stop();
                            tmrAnimation1.Start();
                        }

                        CacodemonImage = 9;
                    }

                }

                if (r[x].IntersectsWith(rHellKnight))
                {
                    HellKnightHealth -= 10;
                    HellKnightImage = 9;
                }
            }

            if (isCacoDemonDead == true)
            {
                DemonXVel = 0;
                DemonYVel = 0;

                rCacoDemon.Y += DemonDeathVel;

                for (int i = 0; i < 30; i++)
                {
                    if (rCacoDemon.IntersectsWith(rPlatform[i]))
                    {
                        DemonDeathVel = 0;
                    }
                }
            }



            //Platform
            rPlatform[15].X += platformVel;

            rCacoDemon.X -= DemonXVel;
            rCacoDemon.Y += DemonYVel;
            if (isCacoDemonDead == false)
            {
                if(rCacoDemon.IntersectsWith(rPlatform[14]))
                {
                    DemonXVel *= -1;
                    DemonYVel *= -1;
                }

                if (rCacoDemon.IntersectsWith(rPlatform[19]))
                {
                    DemonXVel *= -1;
                    DemonYVel *= -1;
                }

                if (rPlatform[15].IntersectsWith(rPlatform[7]))
                {
                    platformVel += 1;
                }

                if (rPlatform[15].IntersectsWith(rPlatform[12]))
                {
                    platformVel *= -1;
                }
            }
            

            if (rSprite.IntersectsWith(rRedKeyCard))
            {
                rRedKeyCard.X = 1600;
                rRedKeyCard.Y = 1000;
                
                KeyDisplay = true;

                rPlatform[10].Location = new Point(373, 184);
                rPlatform[10].Size = new Size(204, 20);

                rPlatform[16].Location = new Point(0, -2000);

                DelayTimer1.Start();
            }

            if (rSprite.IntersectsWith(rTeleporter))
            {
                v1 = -50;
                tmrGravity1.Start();
            }

            if (rSprite.IntersectsWith(rTeleporter2))
            {
                v1 = -35;
                tmrGravity1.Start();
            }

            if (rCacoDemon.IntersectsWith(rSprite) && isCacoDemonDead == false)
            {
                PlayerHealth -= 1;
            }

            if (HellKnightHealth == 0)
            {
                isHellKnightDead = true;

                tmrSpriteController1.Stop();
                tmrSpriteController1.Interval = 200;
                tmrSpriteController1.Start();
            }

            #region What Side the Bullet is on
            if (isAlive == true)
            {
                if (rSprite.Location.X > rCacoDemon.Location.X)
                {
                    isLeft = true;
                    isRight = false;
                }

                if (rSprite.Location.X < rCacoDemon.Location.X)
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
            #endregion 

            if (PlayerHealth <= 0)
            {
                isAbleToShoot = false;
                isGameOver = true;
                isPlayerAlive = false;
                tmrSprite1.Stop();
            }

            for (int i = 0; i < 30; i++)
            {
                if (rSprite.IntersectsWith(rPlatform[i]))
                {
                    if (goLeft == true && rSprite.Left <= rPlatform[i].Right && rSprite.Left > rPlatform[i].Left)
                    {
                        rSprite.X += spriteVel;
                        tmrSprite1.Stop();
                    }

                    if (goRight == true && rSprite.Right >= rPlatform[i].Left && rSprite.Left < rPlatform[i].Left)
                    {
                        rSprite.X -= spriteVel;
                        tmrSprite1.Stop();
                    }
                }
            }

            if(rSprite.IntersectsWith(rCheckPoint))
            {
                Load3 = true;
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
                rHellKnight.X -= hellKnightVelocity; //Moves the enemy to the right

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

        private void tmrAnimationEngine1_Tick(object sender, EventArgs e)
        {
            //controls other animations for other needed events
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
                        tmrAnimationEngine1.Stop();
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

        private void tmrSpriteController1_Tick(object sender, EventArgs e)
        {
            if (idle == true)
            {
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
                tmrSpriteController1.Interval = 75;

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

                if (Attack == true)
                {
                    switch (HellKnightNum)
                    {
                        case 1:
                            imgHellKnight = Properties.Resources.leftAttack1;
                            break;
                        case 2:
                            imgHellKnight = Properties.Resources.leftAttack2;
                            break;
                        case 3:
                            imgHellKnight = Properties.Resources.leftAttack3;
                            break;
                        case 4:
                            imgHellKnight = Properties.Resources.leftAttack4;
                            break;
                        case 5:
                            imgHellKnight = Properties.Resources.leftAttack5;
                            break;
                        case 6:
                            imgHellKnight = Properties.Resources.leftAttack6;
                            break;
                        case 7:
                            imgHellKnight = Properties.Resources.leftAttack7;
                            break;
                        case 8:
                            imgHellKnight = Properties.Resources.leftAttack8;
                            break;
                        case 9:
                            imgHellKnight = Properties.Resources.leftAttack9;
                            break;
                        case 10:
                            imgHellKnight = Properties.Resources.leftAttack10;
                            break;
                        case 11:
                            imgHellKnight = Properties.Resources.leftAttack11;
                            break;
                        case 12:
                            imgHellKnight = Properties.Resources.leftAttack12;
                            break;
                        case 13:
                            imgHellKnight = Properties.Resources.leftAttack13;
                            break;
                    }
                }
            }

            if (isHellKnightDead == true)
            {
                tmrSpriteController1.Interval = 75;
                hellKnightVelocity = 0;
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
                        tmrSpriteController1.Stop();
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

            //
            faceUINum += 1;

            if (faceUINum > faceUI)
            {
                faceUINum = 1;
            }

            //HellKnight

            HellKnightNum += 1; // repeat the animation

            if (HellKnightNum > HellKnightImage)
            {
                HellKnightNum = 1;
            }

            this.Refresh();
        }

        private void tmrSprite1_Tick(object sender, EventArgs e)
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

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                //spriteVel = 25;
                goLeft = true;
                row = 3;
                tmrSprite1.Start();
                shootLeft = true;
                shootRight = false;
            }

            if (e.KeyData == Keys.D)
            {
                //spriteVel = 25;
                goRight = true;
                row = 2;
                tmrSprite1.Start();
                shootRight = true;
                shootLeft = false;
            }

            if (e.KeyData == Keys.Escape)   
            {
                Application.Exit();
            }

            if (e.KeyData == Keys.H)
            {
                //PlayerHealth -= 5;

            }

            if (e.KeyData == Keys.F)
            {
                if (Load3 == true)
                {
                    //Form2 level2 = new Form2();
                    //Form3 level3 = new Form3();

                    //level3.Show();

                    //this.Hide();
                }


                Form2 level2 = new Form2();
                Form3 level3 = new Form3();

                level3.Show();

                this.Hide();
            }




            

            if (e.KeyData == Keys.Space)
            {
                v1 = -30; //Increase Jump Height

                tmrGravity1.Start();
            }

        }        

         private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                goLeft = false;
                tmrSprite1.Stop();
            }

            if (e.KeyData == Keys.D)
            {
                goRight = false;
                tmrSprite1.Stop();
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {

            //Collision Bar (HitBox)
            e.Graphics.FillRectangle(Brushes.Black, rightDetection);

            e.Graphics.DrawImage(imgCheckpoint, rCheckPoint);


            //Items
            e.Graphics.DrawImage(imgRedKeyCard, rRedKeyCard); //Yellow Keycard

            for (int x = 0; x < r.Count; x++)
            {
                e.Graphics.FillEllipse(Brushes.Red, r[x]); //Bullet

                if (isRight == true)
                {
                    if (r[x].Location.X > rCacoDemon.Location.X)
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
                    if (r[x].Location.X < rCacoDemon.Location.X)
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

            
           
            

            //Player
            if (PlayerHealth > 0)
            {
                if (KeyDisplay == true)
                {
                    e.Graphics.DrawString(" Red Key Card Aquired".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red, rSprite.X + 50, rSprite.Y - 80);
                }
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

                e.Graphics.FillRectangle(Brushes.OrangeRed, rPlatform[15]);
                e.Graphics.FillRectangle(Brushes.OrangeRed, rPlatform[9]);
                e.Graphics.FillRectangle(Brushes.OrangeRed, rPlatform[13]);
                e.Graphics.FillRectangle(Brushes.OrangeRed, rPlatform[1]);
                e.Graphics.FillRectangle(Brushes.OrangeRed, rPlatform[2]);

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

            //Hell Knight
            if (HellKnightHealth > 0)
            {
                e.Graphics.DrawString(HellKnightHealth + " Hell Knight".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red, rHellKnight.X, rHellKnight.Y);
            }

            e.Graphics.DrawImage(imgHellKnight, rHellKnight);

            if (Load3 == true)
            {
                e.Graphics.DrawString("Press F to Continue".ToString(), new System.Drawing.Font("Arial", 40), Brushes.Yellow, this.Width / 2 - 280, 10);
            }

            e.Graphics.DrawImage(imgCacoDemon, rCacoDemon);

            if (isCacoDemonDead == false)
            {
                e.Graphics.DrawString(CacoDemonHealth + " Enemy Health".ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red, rCacoDemon.X, rCacoDemon.Y - 50);
            }
            

            e.Graphics.DrawImage(imgRedKeyCard, rRedKeyCard);
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

        private void tmrProjectile1_Tick(object sender, EventArgs e)
        {
            MoveProjectile();

            this.Refresh();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if(isAbleToShoot == true)
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

                    tmrProjectile1.Start();
                }
            }

            
        }

        private void tmrGravity1_Tick(object sender, EventArgs e)
        {
        if (isPlayerAlive == true)
            {            
            this.Refresh();

            t += 0.20;              //increment time during fall/rise 

            v2 = (v1 + (g * t));    //Physics Formula 

            rSprite.Y += (int)v2;     //move the Player

            //g //Gravity Factor
            //t //Time
            //v2 //Velocity After Time
            //v1; //Initial Velocity

            if (rSprite.Bottom > rFloor.Top)
            {
                //reset the time
                t = 0;

                tmrGravity1.Stop();
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
