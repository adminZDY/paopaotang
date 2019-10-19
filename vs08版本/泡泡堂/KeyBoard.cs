using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 泡泡堂
{
    //键盘事件【通过集合判断玩家按下哪些键。通过KeyDown和KeyUp控制集合中的键。IsKeyDown方法判断某个键是否按下】
    #region 键盘事件
    
    /// <summary>
    /// 键盘事件类
    /// </summary>
    public class Keyboard
    {
        private static Keyboard instrance;

        //键盘按下事件的集合
        private List<Keys> keys = new List<Keys>();

        //构造函数
        public Keyboard()
        {
            //按下事件的集合清空
            keys.Clear();
        }

        /// <summary>
        /// 创建键盘类实例
        /// </summary>
        /// <returns></returns>
        public static Keyboard CreateInstance()
        {
            if (instrance == null)
            {
                instrance = new Keyboard();
            }
            return instrance;
        }

        /// <summary>
        /// 判断键是否被按下
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key)
        {
            return keys.Contains(key);
        }

        /// <summary>
        /// 键盘按下的键的集合
        /// </summary>
        /// <param name="key"></param>
        public void KeyDown(Keys key)
        {
            if (!keys.Contains(key))
            {
                keys.Add(key);
            }
        }

        /// <summary>
        /// 移除键盘按起的键（防止按键后角色一直移动）
        /// </summary>
        /// <param name="key"></param>
        public void KeyUp(Keys key)
        {
            if (keys.Contains(key))
            {
                keys.Remove(key);
            }
        }
    }

    #endregion
}
