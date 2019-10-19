namespace 泡泡堂
{
    partial class 泡泡堂总窗体
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BombNum = new System.Windows.Forms.Label();
            this.StopGame = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrizeNum = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HeroLifeNum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.enemyNum = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.StopGame);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(720, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 758);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "游戏信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BombNum);
            this.panel2.Location = new System.Drawing.Point(29, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 138);
            this.panel2.TabIndex = 17;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox4.BackgroundImage = global::泡泡堂.Properties.Resources.Bomb;
            this.pictureBox4.Location = new System.Drawing.Point(58, 43);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 55);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "可放炸弹数";
            // 
            // BombNum
            // 
            this.BombNum.AutoSize = true;
            this.BombNum.Location = new System.Drawing.Point(67, 101);
            this.BombNum.Name = "BombNum";
            this.BombNum.Size = new System.Drawing.Size(31, 19);
            this.BombNum.TabIndex = 6;
            this.BombNum.Text = "X1";
            // 
            // StopGame
            // 
            this.StopGame.Location = new System.Drawing.Point(69, 695);
            this.StopGame.Name = "StopGame";
            this.StopGame.Size = new System.Drawing.Size(88, 26);
            this.StopGame.TabIndex = 5;
            this.StopGame.Text = "暂停";
            this.StopGame.UseVisualStyleBackColor = true;
            this.StopGame.Click += new System.EventHandler(this.StopGame_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.PrizeNum);
            this.panel3.Location = new System.Drawing.Point(29, 201);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 138);
            this.panel3.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::泡泡堂.Properties.Resources.Prize;
            this.pictureBox2.Location = new System.Drawing.Point(57, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 51);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "道具数量";
            // 
            // PrizeNum
            // 
            this.PrizeNum.AutoSize = true;
            this.PrizeNum.Location = new System.Drawing.Point(67, 99);
            this.PrizeNum.Name = "PrizeNum";
            this.PrizeNum.Size = new System.Drawing.Size(31, 19);
            this.PrizeNum.TabIndex = 7;
            this.PrizeNum.Text = "X5";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.HeroLifeNum);
            this.panel4.Location = new System.Drawing.Point(29, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(163, 138);
            this.panel4.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::泡泡堂.Properties.Resources.Hero;
            this.pictureBox1.Location = new System.Drawing.Point(49, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 69);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "人物生命值";
            // 
            // HeroLifeNum
            // 
            this.HeroLifeNum.AutoSize = true;
            this.HeroLifeNum.Location = new System.Drawing.Point(67, 114);
            this.HeroLifeNum.Name = "HeroLifeNum";
            this.HeroLifeNum.Size = new System.Drawing.Size(31, 19);
            this.HeroLifeNum.TabIndex = 9;
            this.HeroLifeNum.Text = "X5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.enemyNum);
            this.panel1.Location = new System.Drawing.Point(29, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 155);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "敌人数量";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::泡泡堂.Properties.Resources.Enemy;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox3.Location = new System.Drawing.Point(53, 38);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 66);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // enemyNum
            // 
            this.enemyNum.AutoSize = true;
            this.enemyNum.Location = new System.Drawing.Point(61, 107);
            this.enemyNum.Name = "enemyNum";
            this.enemyNum.Size = new System.Drawing.Size(42, 19);
            this.enemyNum.TabIndex = 15;
            this.enemyNum.Text = "X10";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // 泡泡堂总窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::泡泡堂.Properties.Resources._323029;
            this.ClientSize = new System.Drawing.Size(934, 749);
            this.Controls.Add(this.groupBox1);
            this.Name = "泡泡堂总窗体";
            this.Text = "泡泡堂";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameMain_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.泡泡堂总窗体_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.泡泡堂总窗体_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.泡泡堂总窗体_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StopGame;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label HeroLifeNum;
        private System.Windows.Forms.Label PrizeNum;
        private System.Windows.Forms.Label BombNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label enemyNum;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer GameTimer;



    }
}