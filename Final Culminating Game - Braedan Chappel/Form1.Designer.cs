namespace Final_Culminating_Game___Braedan_Chappel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrProjectile = new System.Windows.Forms.Timer(this.components);
            this.tmrSprite = new System.Windows.Forms.Timer(this.components);
            this.tmrEnemy = new System.Windows.Forms.Timer(this.components);
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimation = new System.Windows.Forms.Timer(this.components);
            this.tmrSpriteController = new System.Windows.Forms.Timer(this.components);
            this.tmrGravity = new System.Windows.Forms.Timer(this.components);
            this.AnimationEngine = new System.Windows.Forms.Timer(this.components);
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrUI = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrProjectile
            // 
            this.tmrProjectile.Enabled = true;
            this.tmrProjectile.Interval = 20;
            this.tmrProjectile.Tick += new System.EventHandler(this.tmrProjectile_Tick);
            // 
            // tmrSprite
            // 
            this.tmrSprite.Interval = 40;
            this.tmrSprite.Tick += new System.EventHandler(this.tmrSprite_Tick);
            // 
            // tmrEnemy
            // 
            this.tmrEnemy.Enabled = true;
            this.tmrEnemy.Interval = 500;
            this.tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // tmrAnimation
            // 
            this.tmrAnimation.Interval = 125;
            this.tmrAnimation.Tick += new System.EventHandler(this.tmrAnimation_Tick);
            // 
            // tmrSpriteController
            // 
            this.tmrSpriteController.Enabled = true;
            this.tmrSpriteController.Interval = 150;
            this.tmrSpriteController.Tick += new System.EventHandler(this.tmrSpriteController_Tick);
            // 
            // tmrGravity
            // 
            this.tmrGravity.Enabled = true;
            this.tmrGravity.Interval = 1;
            this.tmrGravity.Tick += new System.EventHandler(this.tmrGravity_Tick);
            // 
            // AnimationEngine
            // 
            this.AnimationEngine.Enabled = true;
            this.AnimationEngine.Interval = 200;
            this.AnimationEngine.Tick += new System.EventHandler(this.AnimationEngine_Tick);
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 2000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // tmrUI
            // 
            this.tmrUI.Enabled = true;
            this.tmrUI.Interval = 1000;
            this.tmrUI.Tick += new System.EventHandler(this.tmrUI_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1059, 601);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrProjectile;
        private System.Windows.Forms.Timer tmrSprite;
        private System.Windows.Forms.Timer tmrEnemy;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer tmrAnimation;
        private System.Windows.Forms.Timer tmrSpriteController;
        private System.Windows.Forms.Timer tmrGravity;
        private System.Windows.Forms.Timer AnimationEngine;
        private System.Windows.Forms.Timer delayTimer;
        private System.Windows.Forms.Timer tmrUI;
    }
}

