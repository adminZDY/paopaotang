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
    public partial class 泡泡堂总窗体 : Form
    {
        public 泡泡堂总窗体()
        {
            InitializeComponent();
        }

        private void GameMain_KeyDown(object sender, KeyEventArgs e)
        {
            //键盘按下
            Keyboard.CreateInstance().KeyDown(e.KeyCode);
        }

        private void GameMain_KeyUp(object sender, KeyEventArgs e)
        {
            //键盘按上
            Keyboard.CreateInstance().KeyUp(e.KeyCode);
        }
    }
}
