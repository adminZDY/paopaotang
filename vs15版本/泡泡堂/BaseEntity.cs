using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    #region 人物移动代码和绘图代码
    
    /// <summary>
    /// 游戏中所有元素的基类（抽象类）
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 表示元素的X坐标（以像素为单位）
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 表示元素的Y坐标（以像素为单位）
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 该元素的绘制方法（抽象类）
        /// </summary>
        /// <param name="g">封装一个GDI+ 绘图图面不能被继承的类</param>
        public abstract void Draw(Graphics g);
    }

    #endregion
}
