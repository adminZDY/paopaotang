using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace 泡泡堂
{
    public partial class 泡泡堂总窗体 : Form
    {
        GameMainMenu menu = null;
         public 泡泡堂总窗体()
        {
            InitializeComponent();
            //采用双缓冲，解决角色移动屏幕闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
        }
        public 泡泡堂总窗体(GameMainMenu menu)
        {
            InitializeComponent();
            /// <summary>
            /// 背景音乐对象
            /// </summary>
            SoundPlayer sp = null ;
            this.menu = menu;
            //采用双缓冲，解决角色移动屏幕闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            //绘制游戏角色移动的网格宽度和高度
            //this.Width = UtilityResource.MapCols * 48;
            //this.Height = UtilityResource.MapRows * 48 + 24;
            Random random = new Random();
            //音乐
            int num = random.Next(0, 2);
            switch (num)
            {
                case 0:
                    sp = new SoundPlayer(泡泡堂.Properties.Resources.play);
                    sp.PlayLooping();
                    //Properties.Resources.ResourceManager.GetObject(value);
                    //InitResoure.CreateInstance().
                    break;
                case 1:
                    sp = new SoundPlayer(泡泡堂.Properties.Resources.play2);
                    sp.PlayLooping();
                    break;
            }
        }

        //游戏主要逻辑实现类
        /// <summary>
        /// 主要逻辑控制对象
        /// </summary>
        private GameManager manager = new GameManager();

        private void GameMain_Paint(object sender, PaintEventArgs e)
        {
            //绘制游戏
            manager.Draw(e.Graphics);
        }

        /// <summary>
        /// 时间控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //重绘窗体
            this.Invalidate(new Rectangle(0, 0, this.Width, this.Height), true);
            if (this.manager.hero.Life > 0)
            {
                this.HeroLifeNum.Text = "X"+this.manager.hero.Life;
            }
            else
            {
                this.GameTimer.Enabled = false;
                MessageBox.Show("Game Over");
                menu.Show();
                this.Close();
            }
            
            this.PrizeNum.Text = "X" + this.manager.PrizeNumber;
           
            if (this.manager.enemyNumber > 0)
            {
                this.enemyNum.Text = "X" + this.manager.enemyNumber;
            }
            else
            {
                this.GameTimer.Enabled = false;
                MessageBox.Show("成功过关！！！");
                menu.Show();
                this.Close();
            }
            this.BombNum.Text = "X" + this.manager.BombNumber;
            //更新游戏桢，实现动画
            manager.UpdateGameFrames();
        }

        private void 泡泡堂总窗体_KeyDown(object sender, KeyEventArgs e)
        {
            //键盘按下
            Keyboard.CreateInstance().KeyDown(e.KeyCode);
        }

        private void 泡泡堂总窗体_KeyUp(object sender, KeyEventArgs e)
        {
            //键盘按上
            Keyboard.CreateInstance().KeyUp(e.KeyCode);
        }

        private void StopGame_Click(object sender, EventArgs e)
        {
            if (this.GameTimer.Enabled)
            {
                //暂停计时器
                this.StopGame.Text = "继续";
                this.GameTimer.Enabled = false;
            }
            else
            {
                this.StopGame.Text = "暂停";
                this.GameTimer.Enabled = true;
            }
        }

        private void 泡泡堂总窗体_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult result = MessageBox.Show("你是否退出游戏","",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
           e.Cancel = false;
           if (result == DialogResult.OK)
           {
               menu.Show();    
           }
           else
           {
               e.Cancel = true;
           }
        }
    }
}
