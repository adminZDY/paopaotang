using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 泡泡堂
{
    public partial class GameMainMenu : Form
    {
        public GameMainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始游戏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBeginGame_Click(object sender, EventArgs e)
        {
            //隐藏本窗体
            this.Hide();
            泡泡堂总窗体 gamemain = new 泡泡堂总窗体(this);
            gamemain.StartPosition = FormStartPosition.CenterScreen;
            gamemain.ShowDialog();
        }

        /// <summary>
        /// 游戏说明按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("游戏规则：\n玩家按“↑”上，“↓”下，“←”左，“→”右，对人物进行移动");
        }
        
        /// <summary>
        /// 更多游戏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("更多游戏，请关注泡泡堂官网");
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你是否想要退出？","关闭提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
