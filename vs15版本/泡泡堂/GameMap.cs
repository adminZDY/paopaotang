using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    #region 游戏地图类
    
    //地图格式
    public enum GridType
    {
        /// <summary>
        /// 空地
        /// </summary>
        Empty,//空地
        /// <summary>
        /// 土墙
        /// </summary>
        Stone,//石墙
        /// <summary>
        /// 石墙
        /// </summary>
        Soil,//土墙
        /// <summary>
        /// 地板
        /// </summary>
        Floor,//地板
        /// <summary>
        /// 炸弹
        /// </summary>
        Bomb//炸弹
    }

    /// <summary>
    /// 游戏地图类
    /// </summary>
    public class GameMap : BaseEntity
    {
        //定义地图行
        public int Rows = UtilityResource.MapRows;
        //定义地图列
        public int Cols = UtilityResource.MapCols;
        //定义地图格式枚举数组
        public GridType[,] Grids;

        //石墙图片数组
        private Bitmap[] bmpsStone = new Bitmap[UtilityResource.StoneWallFrames];
        //地板图片数组
        private Bitmap[] bmpsFloor = new Bitmap[UtilityResource.FloorFrames];

        //定义随机数对象
        private Random random = new Random();
        //定义石墙和地板产生的随机数变量
        private int stones = 0;
        private int floors = 0;

        /// <summary>
        /// 初始化地图
        /// </summary>
        /// <param name="rows">格子行数</param>
        /// <param name="cols">格子列数</param>
        public GameMap(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            //初始化格式（Cols：X坐标，Rows：Y坐标）
            Grids = new GridType[Cols, Rows];

            //创建石墙图片
            bmpsStone = InitResoure.CreateInstance().InitGameGood(UtilityResource.StoneWallValue,
                UtilityResource.StoneWallFrames, new Size(UtilityResource.StoneWallWidth, UtilityResource.StoneWallHeight));

            //创建地板图片
            bmpsFloor = InitResoure.CreateInstance().InitGameGood(UtilityResource.FloorValue,
                UtilityResource.FloorFrames, new Size(UtilityResource.FloorWidth, UtilityResource.FloorHeight));

            //随机产生地面
            floors = random.Next(0, UtilityResource.FloorFrames);

            //建立原始地图
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    //默认为空地
                    Grids[x, y] = GridType.Empty;
                    //随机产生地图（随机数从1开始的目的就是防止第一个单元格被填充）
                    int i = random.Next(1, Cols - 1);
                    int j = random.Next(1, Rows - 1);
                    //随机产生石墙（先产生石墙占位，然后再产生其他的物体）
                    if (Grids[i, j] != GridType.Stone)
                    {
                        Grids[i, j] = GridType.Stone;
                    }
                }
            }
        }

        //定义记录随机产生石墙下标的数组
        private List<int> stoneType = new List<int>();
        /// <summary>
        /// 随机产生地图的地板
        /// </summary>
        public void RandStooneType()
        {
            for (int x = 0; x < Cols; x++)
			{
			     for (int y = 0; y < Rows; y++)
                 {
                     stones = random.Next(0, UtilityResource.StoneWallFrames);
                     stoneType.Add(stones);
                 }
			}
        }

        //标记地图是否第一次绘制
        private bool isCreate = true;

        /// <summary>
        /// 绘制地图代码
        /// </summary>
        /// <param name="g"></param>
        public override void  Draw(System.Drawing.Graphics g)
        {
 	        //第一次绘制需要用产生石墙的方法
            if (isCreate)
	        {
                RandStooneType();
                isCreate = false;
	        }

            //绘制地图中每个单元格的元素
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    //首先绘制地图
                    g.DrawImage(bmpsFloor[floors], x * (UtilityResource.FloorWidth / UtilityResource.FloorFrames),
                        y * (UtilityResource.FloorHeight), UtilityResource.FloorWidth / UtilityResource.FloorFrames,
                        UtilityResource.FloorHeight);
                    //如果是石墙，就在地图上添加石墙
                    if (Grids[x,y] == GridType.Stone)
                    {
                        g.DrawImage(bmpsStone[stoneType[x * Rows + y]], x * (UtilityResource.StoneWallWidth / UtilityResource.StoneWallFrames),
                            y * (UtilityResource.StoneWallHeight), UtilityResource.StoneWallWidth / UtilityResource.StoneWallFrames,
                            UtilityResource.StoneWallHeight);
                    }
                }
            }
        }

        #region 判断是否四周环绕的石墙
      
        /// <summary>
        /// 判断是否四周环绕的石墙
        /// </summary>
        /// <param name="curCol">当前X坐标</param>
        /// <param name="curRow">当前Y坐标</param>
        /// <returns></returns>
        public bool DeleteAroundStone(int curCol, int curRow)
        {
            int count = 0;
            for (int x = curCol; x < curCol++; x++)
            {
                for (int y = curRow - 1; y < curRow++; y++)
                {
                    if (Grids[x,y] == GridType.Stone)
                    {
                        count++;                    
                    }
                }
            }
            if (count >= 4)
            { 
                return false;
            }
            return true;
        }

        #endregion

    }

    #endregion
}