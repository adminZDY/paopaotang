using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 泡泡堂
{
    /// <summary>
    /// 资源文件定义类
    /// </summary>
    public class UtilityResource
    {
        #region 资源文件尺寸
        //资源大小（玩家和敌人的原始图片大小）
        public static int ResourceWidth = 256;
        public static int ResourceHeight = 256;

        //图像大小（玩家和敌人的实际游戏图片大小）
        public static int BitmapWidth = 64;
        public static int BitmapHeight = 64;

        //炸弹大小
        public static int BombWidth = 144;
        public static int BombHeight = 48;

        //火焰大小
        public static int FireWidth = 240;
        public static int FireHeigth = 48;

        //地板大小
        public static int FloorWidth = 192;
        public static int FloorHeight = 48;

        //土墙大小（可以被炸弹炸掉）
        public static int SoilWallWidth = 48;
        public static int SoilWallHeight = 48;

        //石墙大小（坚固不可摧毁）
        public static int StoneWallWidth = 240;
        public static int StoneWallHeight = 48;

        //道具（奖品）大小
        public static int PrizeWidth = 192;
        public static int PrizeHeight = 48;
        #endregion

        #region 资源文件动画帧数
        //火焰帧数（图片组成元素个数）
        public static int FireFrames = 5;
        //炸弹帧数
        public static int BombFrames = 3;
        //地板帧数
        public static int FloorFrames = 4;
        //土墙帧数
        public static int SoilWailFrames = 1;
        //石墙帧数
        public static int StoneWallFrames = 5;
        //道具（奖品）帧数
        public static int PrizeFrames = 4;
        #endregion

        #region 资源文件访问值

        /// <summary>
        /// 炸弹资源值
        /// </summary>
        public static string BombValue = "Bomb";

        /// <summary>
        /// 火焰资源值
        /// </summary>
        public static string FireValue = "Fire";

        /// <summary>
        /// 玩家资源值
        /// </summary>
        public static string HeroValue = "Hero";

        /// <summary>
        /// 敌人资源值
        /// </summary>
        public static string EnemyValue = "Enemy";

        /// <summary>
        /// 土墙资源值
        /// </summary>
        public static string SoilWallValue = "SoilWall";

        /// <summary>
        /// 石墙资源值
        /// </summary>
        public static string StoneWallValue = "StoneWall";

        /// <summary>
        /// 地板资源值
        /// </summary>
        public static string FloorValue = "Floor";

        /// <summary>
        /// 道具（奖品）资源值
        /// </summary>
        public static string PrizeValue = "Prize";
        #endregion

        #region 游戏地图尺寸
        //网格大小（宽度和高度均为48像素）
        public static int GridSize = 48;
        //游戏地图尺寸
        public static int MapRows = 15;
        public static int MapCols = 15;
        #endregion

        #region 角色移动动作
        //角色移动方位数（上、下、左、右）
        public const int RoleDirection = 4;
        //角色完成单方向一套动作需要的步数
        public const int RoleStep = 4;
        #endregion
    }
}
