using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    public enum PrizeType
    {
        /// <summary>
        /// 生命值
        /// </summary>
        AddLife,    //增加生命
        /// <summary>
        /// 速度
        /// </summary>
        AddSpeed,   //增加速度
        /// <summary>
        /// 炸弹数
        /// </summary>
        AddBomb,    //增加炸弹
        /// <summary>
        /// 炸弹爆炸格数
        /// </summary>
        AddPower    //增强炸弹威力
    }

    /// <summary>
    /// 道具类
    /// </summary>
    public class Prize:BaseEntity
    {
        //定义道具枚举
        public PrizeType prizeType;
        //是否已经拾取
        public bool IsPick = false;
        //声明一个资源集合
        private Bitmap[] bmpPrize = new Bitmap[UtilityResource.PrizeFrames];

        /// <summary>
        /// 道具构造函数
        /// </summary>
        /// <param name="type"></param>
        public Prize(PrizeType type)
        {
            bmpPrize = InitResoure.CreateInstance().InitGameGood(UtilityResource.PrizeValue,
                UtilityResource.PrizeFrames, new Size(UtilityResource.PrizeWidth, UtilityResource.PrizeHeight));
            //设置道具类型
            this.prizeType = type;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            //道具的类型下标
            int Frame = 0;
            //判断道具类型
            switch (prizeType)
            {
                case PrizeType.AddBomb:
                    Frame = 0;
                    break;
                case PrizeType.AddPower:
                    Frame = 1;
                    break;
                case PrizeType.AddLife:
                    Frame = 2;
                    break;
                case PrizeType.AddSpeed:
                    Frame = 3;
                    break;
            }
            //绘图
            g.DrawImage(bmpPrize[Frame], X, Y, UtilityResource.GridSize, UtilityResource.GridSize);
        }
    }
}
