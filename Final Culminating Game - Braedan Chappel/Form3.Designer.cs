namespace Final_Culminating_Game___Braedan_Chappel
{
    partial class Form3
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
            this.tmrProjectile2 = new System.Windows.Forms.Timer(this.components);
            this.tmrSprite2 = new System.Windows.Forms.Timer(this.components);
            this.tmrEnemy2 = new System.Windows.Forms.Timer(this.components);
            this.GameTimer2 = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimation2 = new System.Windows.Forms.Timer(this.components);
            this.tmrSpriteController2 = new System.Windows.Forms.Timer(this.components);
            this.tmrGravity2 = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimationEngine2 = new System.Windows.Forms.Timer(this.components);
            this.delayTimer2 = new System.Windows.Forms.Timer(this.components);
            this.tmrUI3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrProjectile2
            // 
            this.tmrProjectile2.Enabled = true;
            this.tmrProjectile2.Interval = 20;
            this.tmrProjectile2.Tick += new System.EventHandler(this.tmrProjectile2_Tick);
            // 
            // tmrSprite2
            // 
            this.tmrSprite2.Interval = 40;
            this.tmrSprite2.Tick += new System.EventHandler(this.tmrSprite2_Tick);
            // 
            // tmrEnemy2
            // 
            this.tmrEnemy2.Interval = 150;
            // 
            // GameTimer2
            // 
            this.GameTimer2.Enabled = true;
            this.GameTimer2.Interval = 10;
            this.GameTimer2.Tick += new System.EventHandler(this.GameTimer2_Tick);
            // 
            // tmrAnimation2
            // 
            this.tmrAnimation2.Interval = 200;
            this.tmrAnimation2.Tick += new System.EventHandler(this.tmrAnimation2_Tick);
            // 
            // tmrSpriteController2
            // 
            this.tmrSpriteController2.Enabled = true;
            this.tmrSpriteController2.Interval = 150;
            this.tmrSpriteController2.Tick += new System.EventHandler(this.tmrSpriteController2_Tick);
            // 
            // tmrGravity2
            // 
            this.tmrGravity2.Enabled = true;
            this.tmrGravity2.Interval = 1;
            this.tmrGravity2.Tick += new System.EventHandler(this.tmrGravity2_Tick);
            // 
            // tmrAnimationEngine2
            // 
            this.tmrAnimationEngine2.Enabled = true;
            this.tmrAnimationEngine2.Interval = 300;
            this.tmrAnimationEngine2.Tick += new System.EventHandler(this.tmrAnimationEngine2_Tick);
            // 
            // delayTimer2
            // 
            this.delayTimer2.Enabled = true;
            this.delayTimer2.Interval = 1250;
            this.delayTimer2.Tick += new System.EventHandler(this.delayTimer2_Tick);
            // 
            // tmrUI3
            // 
            this.tmrUI3.Enabled = true;
            this.tmrUI3.Interval = 1000;
            this.tmrUI3.Tick += new System.EventHandler(this.tmrUI3_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form3_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form3_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrProjectile2;
        private System.Windows.Forms.Timer tmrSprite2;
        private System.Windows.Forms.Timer tmrEnemy2;
        private System.Windows.Forms.Timer GameTimer2;
        private System.Windows.Forms.Timer tmrAnimation2;
        private System.Windows.Forms.Timer tmrSpriteController2;
        private System.Windows.Forms.Timer tmrGravity2;
        private System.Windows.Forms.Timer tmrAnimationEngine2;
        private System.Windows.Forms.Timer delayTimer2;
        private System.Windows.Forms.Timer tmrUI3;
    }
}