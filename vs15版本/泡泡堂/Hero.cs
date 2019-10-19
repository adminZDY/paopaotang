using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 泡泡堂
{
    /// <summary>
    /// 游戏主角（主角类继承了游戏角色基类）
    /// </summary>
    public class Hero:GameRole
    {
        //静态属性和方法不能被继承
        //构造函数不能被继承
        //所以使用base关键字调用父类的构造函数或方法。
        public Hero()
            : base(UtilityResource.HeroValue)
        { 
            
        }

        //基类构造函数：初始化游戏角色
        public Hero(string role)
            : base(role)
        { 
        
        }

        /// <summary>
        /// 主角移动（if语句：防止角色超出临界点）
        /// </summary>
        /// <param name="isMove"></param>
        public void Move(bool isMove)
        {
            if (isMove)
            {
                base.Move();
                base.RecordFrame();
            }
            else
            {
                base.RecordFrame();
            }
        }
    }
}
