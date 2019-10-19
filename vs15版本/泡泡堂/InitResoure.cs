using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    /// <summary>
    /// 初始化资源文件类
    /// </summary>
    public class InitResoure
    {
        /// <summary>
        /// 定义一个静态类（名为instance）
        /// </summary>
        private static InitResoure instance;

        /// <summary>
        /// 实例化资源文件类
        /// </summary>
        /// <returns></returns>
        public static InitResoure CreateInstance()
        {
            //如果未实例化（实例化），反之返回（创建好的对象）
            if (instance == null)
            {
                instance = new InitResoure();
            }
            return instance;
        }

        /// <summary>
        /// 初始化游戏角色人物（4*4素材）
        /// </summary>
        /// <param name="value">资源文件值</param>
        /// <returns>角色4个方向走动图</returns>
        public Bitmap[][] InitGameRole(string value)
        { 
            //创建游戏角色位图二维数组
            Bitmap[][] bitmaps = new Bitmap[UtilityResource.RoleDirection][]
            {
                //创建角色移动每个方位都有四个动作
                new Bitmap[UtilityResource.RoleStep],
                new Bitmap[UtilityResource.RoleStep],
                new Bitmap[UtilityResource.RoleStep],
                new Bitmap[UtilityResource.RoleStep]
            };

            //创建单个对象的位图
            Bitmap bitmap = new Bitmap(UtilityResource.BitmapWidth, UtilityResource.BitmapHeight);

            //访问资源文件初始化游戏素材（游戏素材是一张包含角色不同方位、不同动作的图片）
            bitmap = (Bitmap)Properties.Resources.ResourceManager.GetObject(value);

            //通过循环，初始化游戏角色单帧素材（i：行数，j：列数
            //X：图片人物X坐标、Y:图片人物Y坐标）
            for (int y = 0, i = 0; y < UtilityResource.ResourceHeight; y += UtilityResource.BitmapHeight, i++)
            {
                for (int x = 0, j = 0; x < UtilityResource.ResourceWidth; x += UtilityResource.BitmapWidth, j++)
                {
                    //通过指定坐标切割游戏素材，获取游戏角色单帧素材
                    bitmaps[i][j] = bitmap.Clone(new Rectangle(x, y, 
                    UtilityResource.BitmapWidth, UtilityResource.BitmapHeight), 
                    System.Drawing.Imaging.PixelFormat.DontCare);
                }
            }
            return bitmaps;
        }

        /// <summary>
        /// 初始化游戏物品（1*N素材）
        /// </summary>
        /// <param name="value">资源文件值</param>
        /// <param name="frames">图片帧数</param>
        /// <param name="size">图片尺寸</param>
        /// <returns>一次动画需要的桢</returns>
        public Bitmap[] InitGameGood(string value, int frames, Size size)
        {
            Bitmap[] bitmaps = new Bitmap[frames];
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            //访问资源文件初始化游戏素材
            //解决方案中有Properties文件夹中有个Resources东西
            //ResourceManager.GetObject(value)是获取文件名称

            //在解决方案中找Properties中的Resources右键打开
            //点击添加资源右边的下拉按钮，点击添加现有文件（选择好点击确定即可）
            //音乐也是这样弄

            bitmap = (Bitmap)Properties.Resources.ResourceManager.GetObject(value);
            //size.Width/frames;获得每张图片的像素宽度
            for (int i = 0,j=0; i < size.Width; i+=size.Width/frames,j++)
            {
                bitmaps[j] = bitmap.Clone(new Rectangle(i, 0, size.Width / frames, size.Height)
                    , System.Drawing.Imaging.PixelFormat.DontCare);
            }
            return bitmaps;
        }


    }
}
