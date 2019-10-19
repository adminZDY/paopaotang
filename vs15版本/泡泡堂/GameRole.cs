using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    #region 方向枚举

    /// <summary>
    /// 定义方向枚举
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// 静止
        /// </summary>
        Static,
        /// <summary>
        /// 向左
        /// </summary>
        Left,//向左
        /// <summary>
        /// 向上
        /// </summary>
        Up,//向上
        /// <summary>
        /// 向右
        /// </summary>
        Right,//向右
        /// <summary>
        /// 向下
        /// </summary>
        Down//向下
    }

    #endregion

    /// <summary>
    /// 游戏角色基类
    /// </summary>
    public class GameRole:BaseEntity
    {
        /// <summary>
        /// 构造函数：初始化游戏角色
        /// </summary>
        /// <param name="role"></param>
        public GameRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                //角色名称
                this.Role = role;
                //创建游戏角色
                CreateGameRole(role);
            }
        }
        //公共属性【角色类型、移动方向、生命力、移动速度、记录桢顺颂商祺】
        #region 定义角色公共属性
      
        /// <summary>
        /// 方向的枚举
        /// </summary>
        public Direction direction;

        /// <summary>
        /// 角色名称（玩家和敌人）
        /// </summary>
        public string Role;

        /// <summary>
        /// 生命值
        /// </summary>
        public int Life;

        /// <summary>
        /// 速度
        /// </summary>
        public int Speed = 1;

        /// <summary>
        /// 记录桢（根据角色移动方位改变）
        /// </summary>
        private int Frame = 0;

        #endregion

        //创建游戏角色位图二维数组，保存角色行走方向图
        protected Bitmap[][] bitmaps = new Bitmap[UtilityResource.RoleDirection][]
        {
            new  Bitmap[UtilityResource.RoleStep],//下
            new  Bitmap[UtilityResource.RoleStep],//左
            new  Bitmap[UtilityResource.RoleStep],//右
            new  Bitmap[UtilityResource.RoleStep]//上
        };

        /// <summary>
        /// 初始化游戏角色对象
        /// </summary>
        /// <param name="role"></param>
        public void CreateGameRole(string role)
        { 
            //初始化游戏角色二维数组
            bitmaps = InitResoure.CreateInstance().InitGameRole(role);
        }

        /// <summary>
        /// 角色移动
        /// </summary>
        public virtual void Move()
        {
            switch (direction)
            {
                case Direction.Left:
                    this.X -= this.Speed;break;
                case Direction .Right:
                    this.X += this.Speed; break;
                case Direction.Down:
                    this.Y += this.Speed; break;
                case Direction.Up:
                    this.Y -= this.Speed; break;
                case Direction.Static:
                    break;
            }
        }

        /// <summary>
        /// 记录桢
        /// </summary>
        public void RecordFrame()
        {
            switch (direction)
            {
                case Direction.Down:
                    this.Frame = 0;
                    break;
                case Direction.Left:
                    this.Frame = 1;
                    break;
                case Direction.Right:
                    this.Frame = 2;
                    break;
                case Direction.Up:
                    this.Frame = 3;
                    break;
                case Direction.Static:
                    break;
            }
        }

        private int i = 0;//列索引
        /// <summary>
        /// 绘制游戏中人物对象（方法重写）
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(System.Drawing.Graphics g)
        {
            switch (direction)
            {
                case Direction.Down:
                case Direction.Up:
                case Direction.Left:
                case Direction.Right:
                    //!!!不能写（i+= 1），要写i= i+1
                    i =i+ 1 < UtilityResource.RoleStep ? i + 1 : 0;
                    break;
                case Direction.Static: i = 0; 
                    break;
            }
            //绘制图形
            g.DrawImage(bitmaps[Frame][i], this.X, this.Y, UtilityResource.GridSize,
                UtilityResource.GridSize);
        }
     }
}
