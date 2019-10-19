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
    public partial class UserControl1 : UserControl
    {
        //背景音乐
        /// <summary>
        /// 背景音乐对象
        /// </summary>
        SoundPlayer sp;
        public UserControl1()
        {
            InitializeComponent();
            //采用双缓冲，解决角色移动屏幕闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            //绘制游戏角色移动的网格宽度和高度
            this.Width = UtilityResource.MapCols * 48;
            this.Height = UtilityResource.MapRows * 48 + 24;
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
            //更新游戏桢，实现动画
            manager.UpdateGameFrames();
        }
    }
}
