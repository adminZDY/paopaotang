using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace 泡泡堂
{
    #region 游戏主要逻辑

    /// <summary>
    /// 游戏主要逻辑
    /// </summary>
    public class GameManager
    {
        //游戏主角
        public Hero hero;
        //角色生命值
        int LifeCount = 5;
        //游戏地图
        private GameMap map;
        Random random = new Random();
        //土墙
        private List<SoilWall> soilwall_list = new List<SoilWall>();
        //敌人集合
        private List<Enemy> enemy_list = new List<Enemy>();
        //炸弹集合
        private List<Bomb> bomb_list = new List<Bomb>();
        //炸弹个数
        public int BombNumber = 1;
        //敌人数量
        public int enemyNumber = 5;
        //火花集合
        private List<Fire> fire_list = new List<Fire>();
        //爆炸强度
        int FirePower = 1;
        //初始化奖品数
        public int PrizeNumber = 10;
        //道具（奖品）集合
        private List<Prize> prize_list = new List<Prize>();

        #region 游戏角色绘制和地图绘制（土墙）
        /// <summary>
        /// 构造方法
        /// </summary>
        public GameManager()
        {
            //初始化游戏
            InitGame();
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitGame()
        {
            //实例化游戏主角
            hero = new Hero();
            //主角移动速度
            hero.Speed = 16;
            //主角的生命值
            hero.Life = LifeCount;
            //初始化游戏地图网格
            int cols = UtilityResource.MapCols;//MapCols和MapRows都等于15
            int rows = UtilityResource.MapRows;
            //创建了地图（石墙和地面）
            map = new GameMap(cols,rows);

            #region 土墙

            //初始化土墙
            soilwall_list.Clear();
            //cols*rows;获得地图网格的面积
            for (int i = 0; i < cols * rows; i++)
            {
                //定义随机数
                int x = random.Next(0, cols);
                int y = random.Next(0, rows);
                //防止角色被堵住或者角色在土墙上被创建出来
                if ((x == 0 && y == 0) || (x == 1 && y == 0) || (x == 0 && y == 1))
                {
                    continue;
                }
                //将空地部分设置为土墙
                if (map.Grids[x, y] == GridType.Empty)
                {
                    //创建土墙
                    SoilWall soilWall = new SoilWall();
                    soilWall.X = x * UtilityResource.SoilWallWidth;
                    soilWall.Y = y * UtilityResource.StoneWallHeight;
                    map.Grids[x, y] = GridType.Soil;
                    soilwall_list.Add(soilWall);
                }
            }

            #endregion

            #region 道具

            //初始化奖品集合
            prize_list.Clear();

            //默认设置10个奖品
            for (int i = 0; i < PrizeNumber; i++)
            {
                //奖品出现的位置的随机坐标
                int rCol = random.Next(0, cols);
                int rRow = random.Next(0, rows);

                //奖品应该在箱子中，玩家炸毁箱子就可以获得
                if (map.Grids[rCol, rRow] == GridType.Soil)
                {
                    //定义奖品类型的随机变量
                    int prizetype = random.Next(0, UtilityResource.PrizeFrames);
                    Prize prize = null;
                    switch (prizetype)
                    {
                        case 0:
                            prize = new Prize(PrizeType.AddBomb); break;
                        case 1:
                            prize = new Prize(PrizeType.AddPower); break;
                        case 2:
                            prize = new Prize(PrizeType.AddLife); break;
                        case 3:
                            prize = new Prize(PrizeType.AddSpeed); break;
                    }
                    if (prize != null)
                    {
                        prize.X = rCol * UtilityResource.GridSize;
                        prize.Y = rRow * UtilityResource.GridSize;
                        for (int j = 0; j < prize_list.Count; j++)
                        {
                            //已经加入奖品集合与生存的随机数坐标相同
                            if (prize_list[j].X == prize.X && prize_list[j].Y == prize.Y)
                            {
                                --i; return;
                            }
                        }
                        //保存到奖品集合中
                        prize_list.Add(prize);
                    }
                    else
                    {
                        //重新生成序列，重新循环
                        --i;
                    }
                }
                else
                {
                    //重新生成序列，重新循环
                    --i;
                }
            }
            #endregion

            #region 敌人
            
            //初始化敌人
            //enemy_list.Clear();

            //设置5个敌人
            for (int i = 0; i < enemyNumber; i++)
            {
                //敌人出现的位置的随机坐标
                int rCol = random.Next(2, cols);
                int rRow = random.Next(2, rows);
                //在空地位置创建敌人【有可能第一次就不是空地】
                if (map.Grids[rCol, rRow] == GridType.Empty)
                {
                    //创建敌人
                    Enemy enemy = new Enemy();
                    //设置敌人的初始化移动方向，默认为Left
                    enemy.direction = Direction.Left;
                    //设置敌人的移动速度
                    enemy.Speed = 8;
                    //设置敌人初始化的坐标
                    enemy.X = rCol * UtilityResource.GridSize;
                    enemy.Y = rRow * UtilityResource.GridSize;
                   
                    //让敌人不出现在同个地方
                    for (int j = 0; j < enemy_list.Count; j++)
                    {
                        if (enemy_list[j].X == rCol && enemy_list[j].Y == rRow)
                        {
                            i--;
                            return;
                        }
                    }
                    //添加敌人集合中
                    enemy_list.Add(enemy);
                }
                else
                {
                    //如果当前网格不是空地，就继续找空地，重新生成敌人【或敌人四周都为障碍物】,继续找坐标点
                    i--;
                }
            }
            #endregion

            ///*敌人不出现在空地，重新初始化游戏*/
            //for (int i = 0; i < cols * rows; i++)
            //{
            //    for (int x = 0; x < cols; x++)
            //    {
            //        for (int y = 0; y < rows; y++)
            //        {
            //            for (int j = 0; j < enemy_list.Count; j++)
            //            {
            //                  //将空地部分设置为土墙
            //                if (map.Grids[x, y] == GridType.Empty && HitCheck.IsIntersect(map.X, hero.Y, enemy_list[i].X, enemy_list[i].Y))
            //                {

            //                }
            //            }
            //        }
            //    }
            //}

        }

        /// <summary>
        /// 绘制游戏
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            //1、绘制地图
            map.Draw(g);
           
            //2、绘制土墙
            for (int i = 0; i < soilwall_list.Count; i++)
            {
                soilwall_list[i].Draw(g);
            } //7、绘制奖品
            for (int i = 0; i < prize_list.Count; i++)
            {
                prize_list[i].Draw(g);
            }
            //4、绘制敌人
            for (int i = 0; i < enemy_list.Count; i++)
            {
                enemy_list[i].Draw(g);
            }
            //5、绘制炸弹
            for (int i = 0; i < bomb_list.Count; i++)
            {
                bomb_list[i].Draw(g);
            }
            //6、绘制火焰
            for (int i = 0; i < fire_list.Count; i++)
            {
                fire_list[i].Draw(g);
            }
            //3、绘制玩家
            hero.Draw(g);
            
        }

        #endregion

        #region 键盘事件
        
        /// <summary>
        /// 键盘事件
        /// </summary>
        public void KeyBoardEvent()
        {
            if (Keyboard.CreateInstance().IsKeyDown(Keys.Up))
            {
                hero.direction = Direction.Up;
                hero.Move(IsMove(hero));
            }
            else if(Keyboard.CreateInstance().IsKeyDown(Keys.Left))
            {
                hero.direction = Direction.Left;
                hero.Move(IsMove(hero));
            }
            else if (Keyboard.CreateInstance().IsKeyDown(Keys.Right))
            {
                hero.direction = Direction.Right;
                hero.Move(IsMove(hero));
            }
            else if (Keyboard.CreateInstance().IsKeyDown(Keys.Down))
            {
                hero.direction = Direction.Down;
                hero.Move(IsMove(hero));
            }
            else if (Keyboard.CreateInstance().IsKeyDown(Keys.Space))
            {
                //放置炸弹
                int col = 0;
                int row = 0;

                //放置炸弹时需要调整方位
                AdjustDirection(hero, ref col, ref row);
                if (BombNumber >0 && map.Grids[col,row] != GridType.Bomb)
                {
                    //创建炸弹对象
                    Bomb bomb = new Bomb();
                    //设置炸弹的坐标点
                    bomb.X = col * UtilityResource.GridSize;
                    bomb.Y = row * UtilityResource.GridSize;
                    bomb_list.Add(bomb);
                    //炸弹已经添加
                    map.Grids[col, row] = GridType.Bomb;
                    BombNumber--;
                }
            }
            else
            {
                hero.direction = Direction.Static;
            }
        }


        #endregion

        /// <summary>
        /// 更新游戏桢
        /// </summary>
        public void UpdateGameFrames()
        {
            #region 更新键盘事件
            KeyBoardEvent();
            #endregion

            #region 更新敌人移动
            for (int i = 0; i < enemy_list.Count; i++)
            {
                //判断敌人是否允许移动
                if (IsMove(enemy_list[i]))
                {
                    enemy_list[i].Move();
                }
                else
                {
                    //不能移动，就重新调整方位
                    AutoChangeDirection(enemy_list[i]);
                }
                //如果敌人与主角相交，就进行碰撞检测
                if (HitCheck.IsIntersect(hero.X, hero.Y, enemy_list[i].X, enemy_list[i].Y))
                {
                    //主角生命值降低1次
                    hero.Life -= 1;
                    hero.X = 0;
                    hero.Y = 0;
                }
            }
            #endregion

            #region 更新炸弹爆炸

            for (int i = 0; i < bomb_list.Count; i++)
            {
                //更新爆炸时间
                bomb_list[i].DelayTime--;
                if (bomb_list[i].DelayTime == 0)
                {
                    //调用爆炸的方法
                    CreateBomb(bomb_list[i]);
                    //获得当前炸弹的网格位置
                    int cur_col = bomb_list[i].X / UtilityResource.GridSize;
                    int cur_row = bomb_list[i].Y / UtilityResource.GridSize;
                    //爆炸完成将当前坐标点设置为空地
                    map.Grids[cur_col, cur_row] = GridType.Empty;

                    //int num = 0;
                    ////炸弹范围内的其他炸弹
                    //for (int k = 0; k < fire_list.Count; k++)
                    //{
                    //    for (int j = 0; j < bomb_list.Count; j++)
                    //    {
                    //        //如果火焰的坐标与土墙的坐标相同
                    //        if (bomb_list[j].X == fire_list[k].X && bomb_list[j].Y == fire_list[k].Y)
                    //        {
                    //            num++;
                    //            if (num > 1)
                    //            {
                    //                bomb_list[j].DelayTime = 1;
                    //            }
                    //        }
                    //    } 
                    //}
                    //炸弹数量自加
                    BombNumber++;
                    //放置一个炸弹就移除一个炸弹
                    bomb_list.Remove(bomb_list[i]);
                }
            }


            for (int i = 0; i < fire_list.Count; i++)
            {
                //炸弹范围内的其他炸弹
                for (int j = 0; j < bomb_list.Count; j++)
                {
                    //如果火焰的坐标与土墙的坐标相同
                    if (bomb_list[j].X == fire_list[i].X && bomb_list[j].Y == fire_list[i].Y)
                    {
                        bomb_list[j].DelayTime = 0;
                    }
                }
            }

            FireShow();
            #endregion

            #region 更新道具拾取

            for (int i = 0; i < prize_list.Count; i++)
            {
                //判断玩家是否与奖品相交
                if (HitCheck.IsIntersectDeep(prize_list[i].X, prize_list[i].Y, hero.X, hero.Y)&& prize_list[i].X==hero.X&&prize_list[i].Y==hero.Y)
                {
                    //根据奖品增加玩家属性
                    switch (prize_list[i].prizeType)
                    {
                            //生命值
                        case PrizeType.AddLife:
                            LifeCount++;break;
                            //速度
                        case PrizeType.AddSpeed:
                            hero.Speed += 4;
                            break;
                            //炸弹个数
                        case PrizeType.AddBomb:
                            BombNumber++; break;
                            //炸弹威力
                        case PrizeType.AddPower:
                            FirePower++; break;
                    }
                    //拾取
                    prize_list[i].IsPick = true;
                    //移除奖品
                    prize_list.Remove(prize_list[i]);
                    PrizeNumber--;
                }
            }
            #endregion
        }

        /// <summary>
        /// 判断前方是否通过
        /// </summary>
        /// <param name="role">游戏角色对象</param>
        /// <returns></returns>
        private bool IsMove(GameRole role)
        {
            int newX = role.X;
            int newY = role.Y;
            //前进一步，记录改变的坐标点
            switch (role.direction)
            {
                case Direction.Left://左
                    newX -= role.Speed;
                    break;
                case Direction.Up://上
                    newY -= role.Speed;
                    break;
                case Direction.Right://右
                    newX += role.Speed;
                    break;
                case Direction.Down://下
                    newY += role.Speed;
                    break;
            }

            //窗体临界点检测
            if (newX < 0 || newX > (map.Cols - 1) * UtilityResource.GridSize || newY < 0
                || newY > (map.Rows - 1) * UtilityResource.GridSize)
            {
                return false;
            }

            //碰撞检查【角色不能穿越障碍物】
            for (int x = 0; x < map.Cols; x++)
            {
                for (int y = 0; y < map.Rows; y++)
                {
                    //如果前方网格是炸弹，土墙，石墙
                    if (map.Grids[x,y] == GridType.Bomb||map.Grids[x,y] == GridType.Soil
                        ||map.Grids[x,y] == GridType.Stone)
                    {
                        //记录当前障碍物的坐标点
                        int posX = x * UtilityResource.GridSize;
                        int poxY = y * UtilityResource.GridSize;
                        
                        //如果是敌人
                        if (role is Enemy)
                        {
                            //判断敌人与障碍物的焦点
                            if (HitCheck.IsIntersect(posX, poxY, newX, newY))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            //判断玩家放置炸弹时可以通过，玩家离开炸弹就成了障碍物【可以让角色离开炸弹】
                            if (HitCheck.IsIntersect(posX, poxY, role.X, role.Y))
                            {
                                continue;
                            }
                            //判断角色与障碍物的焦点
                            if (HitCheck.IsIntersect(posX, poxY, newX, newY))
                            {
                                return false;
                            }
                        }

                        if(role is Hero && map.Grids[x,y] == GridType.Stone)
                        {
                           
                        }
                    }
                }
            }
            return true;
        }

        #region 自动调整方位

        /// <summary>
        /// 自动改变方向
        /// </summary>
        public void AutoChangeDirection(GameRole role)
        { 
            //随机调用方位
            int rDirection = random.Next(0,4);

            switch (rDirection)
            {
                case 0: role.direction = Direction.Down; break;
                case 1: role.direction = Direction.Left; break;
                case 2: role.direction = Direction.Right; break;
                case 3: role.direction = Direction.Up; break;
            }
        }
        
        #endregion

        #region 调整炸弹的位置

        /// <summary>
        /// 调整炸弹的位置
        /// </summary>
        /// <param name="role"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public void AdjustDirection(GameRole role, ref int col, ref int row)
        { 
            //获得当前角色所在的网格位置
            int cur_col = role.X / UtilityResource.GridSize;
            int cur_row = role.Y / UtilityResource.GridSize;
            //获得当前角色的偏移量坐标
            int posX = cur_col * UtilityResource.GridSize;
            int posY = cur_row * UtilityResource.GridSize;
            //角色X坐标位移量如果超过网格的一半，就在下一个网格放置炸弹
            if (Math.Abs(posX - role.X) > UtilityResource.GridSize / 2)
            {
                col = cur_col + 1;
            }
            else
            {
                col = cur_col;
            }
            if (Math.Abs(posY - role.Y) > UtilityResource.GridSize / 2)
            {
                row = cur_row + 1;
            }
            else
            {
                row = cur_row;
            }
        }
        #endregion

        /// <summary>
        /// 制造火焰
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public void CreateFire(int col, int row)
        {
            Fire fire = new Fire();
            fire.X = col * UtilityResource.GridSize;
            fire.Y = row * UtilityResource.GridSize;
            fire_list.Add(fire);
        }

        /// <summary>
        /// 炸弹爆炸
        /// </summary>
        /// <param name="bomb"></param>
        public void CreateBomb(Bomb bomb)
        { 
            //获得放置炸弹的网格
            int col = bomb.X / UtilityResource.GridSize;
            int row = bomb.Y / UtilityResource.GridSize;
            //清空火焰
            fire_list.Clear();
            //创建中心点火焰，制造火焰
            CreateFire(col, row);
            
            #region 制作火焰四个方向的效果【上、下、左、右】
            
            //创造上火焰效果（上火随Y坐标递减，递减的次数根据火焰的强度类决定）
            int cur_row = row - 1;
            for (int i = 0; i < FirePower; i++,cur_row--)
            {
                Fire fire = new Fire();
                //火焰结束
                if (cur_row < 0)
                {
                    break;
                }
                //如果遇到石墙
                if (map.Grids[col,cur_row] == GridType.Stone)
                {
                    break;
                }
                //如果遇到土墙
                else if (map.Grids[col,cur_row] == GridType.Soil)
                {
                    //产生火焰
                    CreateFire(col, cur_row);
                    break;
                }
                else
                {
                    CreateFire(col, cur_row);
                }
            }

            //创造下火焰效果（下火随Y坐标递减，递减的次数根据火焰的强度类决定）
            cur_row = row + 1;
            for (int i = 0; i < FirePower; i++, cur_row++)
            {
                Fire fire = new Fire();
                //火焰结束
                if (cur_row > map.Rows - 1)
                {
                    break;
                }
                //如果遇到石墙
                if (map.Grids[col, cur_row] == GridType.Stone)
                {
                    break;
                }
                //如果遇到土墙
                else if (map.Grids[col, cur_row] == GridType.Soil)
                {
                    //产生火焰
                    CreateFire(col, cur_row);
                    break;
                }
                else
                {
                    CreateFire(col, cur_row);
                }
            }


            //创造左火焰效果（左火焰随X坐标递减，递减的次数根据火焰的强度来决定）
            int cur_col = col - 1;

            for (int i = 0; i < FirePower; i++, cur_col --)
            {
                Fire fire = new Fire();
                //火焰结束
                if (cur_col < 0)
                {
                    break;
                }
                //如果遇到石墙
                if (map.Grids[cur_col, row] == GridType.Stone)
                {
                    break;
                }
                //如果遇到土墙
                else if (map.Grids[cur_col, row] == GridType.Soil)
                {
                    //产生火焰
                    CreateFire(cur_col, row);
                    break;
                }
                else
                {
                    CreateFire(cur_col, row);
                }
            }

            //创造右火焰效果（右火焰随X坐标递增，递增的次数根据火焰的强度来决定）
            cur_col = col + 1;

            for (int i = 0; i < FirePower; i++, cur_col++)
            {
                Fire fire = new Fire();
                //火焰结束
                if (cur_col > map.Cols - 1)
                {
                    break;
                }
                //如果遇到石墙
                if (map.Grids[cur_col, row] == GridType.Stone)
                {
                    break;
                }
                //如果遇到土墙
                else if (map.Grids[cur_col, row] == GridType.Soil)
                {
                    //产生火焰
                    CreateFire(cur_col, row);
                    break;
                }
                else
                {
                    CreateFire(cur_col, row);
                }
            }
            #endregion
        }

        /// <summary>
        /// 移除、更新火焰
        /// </summary>
        public void FireShow()
        {
            #region 更新火焰效果
            for (int i = 0; i < fire_list.Count; i++)
            {
                //火焰时间递减
                fire_list[i].DelayTime--;
                if (fire_list[i].DelayTime == 0)
                {
                    //获得火焰的网格位置
                    int col = fire_list[i].X / UtilityResource.GridSize;
                    int row = fire_list[i].Y / UtilityResource.GridSize;
                    
                    //烧毁土墙
                    for (int j = 0; j < soilwall_list.Count; j++)
                    {
                        //如果火焰的坐标与土墙的坐标相同
                        if (soilwall_list[j].X == fire_list[i].X
                            && soilwall_list[j].Y == fire_list[i].Y)
                        {
                            soilwall_list.Remove(soilwall_list[j]);
                        }
                    }
                    //烧毁敌人
                    for (int j = 0; j < enemy_list.Count; j++)
                    {
                        //敌人与火焰相交
                        if (HitCheck.IsIntersectDeep(enemy_list[j].X, enemy_list[j].Y, fire_list[i].X, fire_list[i].Y))
                        {
                            enemyNumber--;
                            enemy_list.Remove(enemy_list[j]);
                        }
                        
                    }
                    //炸弹范围内的其他炸弹
                    for (int j = 0; j < bomb_list.Count; j++)
                    {
                        //如果火焰的坐标与土墙的坐标相同
                        if (bomb_list[j].X == fire_list[i].X && bomb_list[j].Y == fire_list[i].Y)
                        {
                            bomb_list[j].DelayTime = 1;
                        }
                    }
                    //烧毁玩家
                    if (HitCheck.IsIntersectDeep(hero.X, hero.Y, fire_list[i].X, fire_list[i].Y))
                    {
                        hero.Life -= 1;
                        hero.X = 0;
                        hero.Y = 0;
                    }
                    map.Grids[col, row] = GridType.Empty;
                    //移除火焰，否则火焰会一直出现在地图上
                    fire_list.Remove(fire_list[i]);
                }
            }

            #endregion
        }
    }

    #endregion
}
