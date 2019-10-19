using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    /// <summary>
    /// 土墙类
    /// </summary>
    public class SoilWall:BaseEntity
    {
        //定义土墙图片集合
        private Bitmap[] bmpSoil = new Bitmap[UtilityResource.SoilWailFrames];

        public SoilWall()
        { 
            //创建土墙
            bmpSoil = InitResoure.CreateInstance().InitGameGood(UtilityResource.SoilWallValue,
                UtilityResource.SoilWailFrames, new Size(UtilityResource.SoilWallWidth, UtilityResource.SoilWallHeight));
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            g.DrawImage(bmpSoil[0], X, Y, UtilityResource.SoilWallWidth, UtilityResource.StoneWallHeight);
        }
    }
}
