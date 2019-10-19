using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    /// <summary>
    /// 火焰类
    /// </summary>
    public class Fire : BaseEntity
    {
        //延迟时间
        public int DelayTime = 5;
        //设置火花对象
        Bitmap[] bmpFile = new Bitmap[UtilityResource.FireFrames];
        
        /// <summary>
        /// 构造时创建图形
        /// </summary>
        public Fire()
        {
            bmpFile = InitResoure.CreateInstance().InitGameGood(UtilityResource.FireValue,
                UtilityResource.FireFrames, new Size(UtilityResource.FireWidth, UtilityResource.FireHeigth));
        }

        private int i = 0;

        /// <summary>
        /// 绘制方法重写
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(System.Drawing.Graphics g)
        {
            i=i+1 < UtilityResource.FireFrames ? i+1 : 0;
            
            g.DrawImage(bmpFile[i], X, Y, UtilityResource.GridSize, UtilityResource.GridSize);
        }
    }
}
