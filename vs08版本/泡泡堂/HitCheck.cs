using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 泡泡堂
{
    /// <summary>
    /// 碰撞检测类
    /// </summary>
    public class HitCheck
    {
        /// <summary>
        /// 判断物体是否相交【判断两个矩形是否相交，矩形相交则碰撞】
        /// </summary>
        /// <param name="x1">对象1X坐标</param>
        /// <param name="y1">对象1Y坐标</param>
        /// <param name="x2">对象2X坐标</param>
        /// <param name="y2">对象2Y坐标</param>
        /// <returns></returns>
        public static bool IsIntersect(int x1, int y1, int x2, int y2)
        {
            Rectangle r1 = new Rectangle(x1, y1, UtilityResource.GridSize, UtilityResource.GridSize);
            Rectangle r2 = new Rectangle(x2, y2, UtilityResource.GridSize, UtilityResource.GridSize);
            //判断对象是否相交
            if (r1.IntersectsWith(r2))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 深度相交【减少两个矩形交互点的范围】
        /// </summary>
        /// <param name="x1">角色/敌人X坐标</param>
        /// <param name="y1">角色/敌人Y坐标</param>
        /// <param name="x2">火焰X坐标</param>
        /// <param name="y2">火焰Y坐标</param>
        /// <returns></returns>
        public static bool IsIntersectDeep(int x1, int y1, int x2, int y2)
        {
            Rectangle r1 = new Rectangle(x1, y1, UtilityResource.GridSize, UtilityResource.GridSize);
            Rectangle r2 = new Rectangle(x2, y2, UtilityResource.GridSize, UtilityResource.GridSize);
            //判断对象是否相交
            if (r1.IntersectsWith(r2))
            {
                return true;
            }
            return false;
        }
    }
}
