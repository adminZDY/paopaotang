using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    /// <summary>
    /// 炸弹类
    /// </summary>
    public class Bomb:BaseEntity
    {
        //设置炸弹延迟时间为50毫秒
        public int DelayTime = 50;
        Bitmap[] bmps = new Bitmap[UtilityResource.BombFrames];

        public Bomb()
        { 
            //初始化炸弹
            bmps = InitResoure.CreateInstance().InitGameGood(UtilityResource.BombValue,
                UtilityResource.BombFrames, new Size(UtilityResource.BombWidth, UtilityResource.BombHeight));
        }

        private int i = 0;
        public override void Draw(System.Drawing.Graphics g)
        {
           //实现炸弹动画效果
            i= i+1 < UtilityResource.BombFrames ? i+1 : 0;
            g.DrawImage(bmps[i], X, Y, UtilityResource.GridSize, UtilityResource.GridSize);
        }
    }
}
