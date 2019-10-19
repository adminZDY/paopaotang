using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 泡泡堂
{
    /// <summary>
    /// 敌人类
    /// </summary>
    public class Enemy : GameRole
    {
        public Enemy():base(UtilityResource.EnemyValue)
        {

        }
        public Enemy(string role):base(role)
        { 
        
        }

        /// <summary>
        /// 敌人移动
        /// </summary>
        public override void Move()
        {
            base.Move();
            base.RecordFrame();
        }
    }
}
