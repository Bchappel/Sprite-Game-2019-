namespace Final_Culminating_Game___Braedan_Chappel
{
    partial class Form2
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
            this.tmrProjectile1 = new System.Windows.Forms.Timer(this.components);
            this.tmrSprite1 = new System.Windows.Forms.Timer(this.components);
            this.tmrEnemy1 = new System.Windows.Forms.Timer(this.components);
            this.GameTimer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimation1 = new System.Windows.Forms.Timer(this.components);
            this.tmrSpriteController1 = new System.Windows.Forms.Timer(this.components);
            this.tmrGravity1 = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimationEngine1 = new System.Windows.Forms.Timer(this.components);
            this.DelayTimer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrUI1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrProjectile1
            // 
            this.tmrProjectile1.Enabled = true;
            this.tmrProjectile1.Interval = 20;
            this.tmrProjectile1.Tick += new System.EventHandler(this.tmrProjectile1_Tick);
            // 
            // tmrSprite1
            // 
            this.tmrSprite1.Interval = 40;
            this.tmrSprite1.Tick += new System.EventHandler(this.tmrSprite1_Tick);
            // 
            // tmrEnemy1
            // 
            this.tmrEnemy1.Enabled = true;
            this.tmrEnemy1.Interval = 500;
            this.tmrEnemy1.Tick += new System.EventHandler(this.tmrEnemy1_Tick);
            // 
            // GameTimer1
            // 
            this.GameTimer1.Enabled = true;
            this.GameTimer1.Interval = 10;
            this.GameTimer1.Tick += new System.EventHandler(this.GameTimer1_Tick);
            // 
            // tmrAnimation1
            // 
            this.tmrAnimation1.Interval = 200;
            this.tmrAnimation1.Tick += new System.EventHandler(this.tmrAnimation1_Tick);
            // 
            // tmrSpriteController1
            // 
            this.tmrSpriteController1.Enabled = true;
            this.tmrSpriteController1.Interval = 150;
            this.tmrSpriteController1.Tick += new System.EventHandler(this.tmrSpriteController1_Tick);
            // 
            // tmrGravity1
            // 
            this.tmrGravity1.Enabled = true;
            this.tmrGravity1.Interval = 1;
            this.tmrGravity1.Tick += new System.EventHandler(this.tmrGravity1_Tick);
            // 
            // tmrAnimationEngine1
            // 
            this.tmrAnimationEngine1.Enabled = true;
            this.tmrAnimationEngine1.Interval = 300;
            this.tmrAnimationEngine1.Tick += new System.EventHandler(this.tmrAnimationEngine1_Tick);
            // 
            // DelayTimer1
            // 
            this.DelayTimer1.Interval = 2000;
            this.DelayTimer1.Tick += new System.EventHandler(this.delayTimer1_Tick);
            // 
            // tmrUI1
            // 
            this.tmrUI1.Enabled = true;
            this.tmrUI1.Interval = 1000;
            this.tmrUI1.Tick += new System.EventHandler(this.tmrUI1_Tick);
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1221, 592);
            this.DoubleBuffered = true;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrProjectile1;
        private System.Windows.Forms.Timer tmrSprite1;
        private System.Windows.Forms.Timer tmrEnemy1;
        private System.Windows.Forms.Timer GameTimer1;
        private System.Windows.Forms.Timer tmrAnimation1;
        private System.Windows.Forms.Timer tmrSpriteController1;
        private System.Windows.Forms.Timer tmrGravity1;
        private System.Windows.Forms.Timer tmrAnimationEngine1;
        private System.Windows.Forms.Timer DelayTimer1;
        private System.Windows.Forms.Timer tmrUI1;
    }
}