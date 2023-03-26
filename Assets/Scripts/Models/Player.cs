// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Models.Player
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Commons;
using Assets.Scripts.Dialogs;
using Assets.Scripts.Games;
using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.Screens;
// using Assets.Scripts.Services;
// using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using static Assets.Scripts.Models.Frame;
using UnityEngine;
namespace Assets.Scripts.Models
{
    public class Player : MapObject, IMapObject
    {
        public int baseHp;
        public int baseMp;
        public int baseDamage;
        public int baseConstitution;
        public int maxDamage;
        public int critical;
        public int dodge;
        public int pointSkill;
        public int level;
        public int yen;
        public int diamond;
        public int cPK;
        public long potentialUpDamage;
        public long potentialUpHp;
        public long potentialUpMp;
        public long potentialUpConstitution;
        public static bool isLoadingMap;
        public static bool isChangingMap;
        public static bool isLockKey;
        public static Player me;
        public static bool isMoveUp;
        public static bool isMoveDown;
        public static bool isMoveRight;
        public static bool isMoveLeft;
        public MovePoint currentMovePoint;
        public int yStartFall;
        public int cp1;
        public int cp2;
        public int cp3;
        public int cvx;
        public int cvy;
        public int cxSend;
        public int cySend;
        public bool isLockMove;
        public bool isCanFly;
        public int checkStatus;
        public int delayFall;
        public List<MovePoint> movePoints;
        public List<IMapObject> focus = new List<IMapObject>();
        public Player playerFocus;
        // public ItemMap itemFocus;
        // public Npc npcFocus;
        // public Mob mobFocus;
        private int statusBeforeNothing;
        public sbyte timeInjure;
        // public Info chatInfo;
        // public SkillPaint skillPaint;
        public int sType;
        // public PlayerDart dart;
        public bool isHaveDart;
        public bool isCreateDark;
        // public Team team;
        public bool isCharge;
        // public List<Skill> skills;
        // public Skill mySkill;
        public long power;
        public long potential;
        public bool isDead;
        // public Task task;
        // public List<Item> itemsBag = new List<Item>();
        // public List<Item> itemsBox = new List<Item>();
        // public List<Item> itemsBody = new List<Item>();
        // public static List<ItemTime> itemTimes;
        public int frameT = 3;
        public static int[][][] CharInfo;
        // public static SkillPaint skillPaintTool;
        public static List<int> iconSkills = new List<int>();
        public static Dictionary<int, Dictionary<string, Frame>> frames;
        public static long LastTimeUseSkill;
        public bool isWaitDart;


        static Player()
        {
            // Player.itemTimes = new List<ItemTime>();


            Player.me = new Player();
        }

        public Player()
        {
            this.speed = 8;
            this.h = 96;
            this.w = 66;
            this.status = PlayerStatus.stand;
            this.isCanFly = true;
            this.movePoints = new List<MovePoint>();
            // this.chatInfo = new Info();
            this.x = 440;
            this.y = 864;
            this.hp = 10000L;
            this.mp = 100000L;
            this.maxHp = 10000000L;
            this.maxMp = 10000000L;
            this.head = 0;
            this.body = 0;
            this.leg = 2;
            this.frameT = int.Parse(File.ReadAllText("Player//frame.txt"));
            try
            {
                string[] strArray = File.ReadAllText("Player//toado.txt").Split('-');
                this.x = int.Parse(strArray[0]);
                this.y = int.Parse(strArray[1]);
            }
            catch (Exception ex)
            {
                LogFile.LogError("Player.cs" + ex.ToString());
            }
            // this.skills = GameCanvas.createSkill(this.gender);
            // this.itemsBag = new List<Item>();
            // for (int index = 0; index < 64; ++index)
            //     this.itemsBag.Add((Item)null);
            // Player.LoadSkillPaint();
        }

        public virtual void paint(MyGraphics g)
        {
            // this.paintShadow(g);


            if (Player.me.playerFocus != null && Player.me.playerFocus.Equals((object)this))
            {
                try
                {
                    this.paintHp(g, this.x - GameScr.instance.cmx, this.y - this.h - 15 - GameScr.instance.cmy);
                }
                catch
                {
                }
            }
            // if (this.dart != null)
            //     this.dart.paint(g);
            g.setColor(Color.red);
            g.fillRect(0, this.y - GameScr.instance.cmy, GameCanvas.w, 1);
            g.fillRect(this.x - GameScr.instance.cmx, 0, 1, GameCanvas.h);
            this.paintBody(g);
        }

        public void paintBody(MyGraphics g)
        {
            this.paintShadow(g);
            g.translate(-GameScr.instance.cmx, -GameScr.instance.cmy);
            try
            {
                Frame frame = Player.frames[this.body][this.status];

                if (this.frame >= frame.icons.Count)
                {

                    this.frame = 0;
                }
                PartImage partImage = frame.icons[this.frame];
                SmallImage.drawSmallImage(g, partImage.id, this.x + partImage.dx * this.dir, this.y + partImage.dy, (this.dir == 1) ? 0 : 2, StaticObj.BOTTOM_HCENTER);

                g.setColor(Color.red);
                g.fillRect(0, this.y, 72, 1);
                g.fillRect(this.x, 0, 1, 72);
                g.drawRect(this.x - this.w / 2, this.y - this.h, this.w, this.h);

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            try
            {
                // if (this.skillPaint == null || this.getSkillInfoPaints() == null || this.skillPaint.index >= this.getSkillInfoPaints().Count)
                //     return;
                // this.paintWithSkill(g, x, y, dir);
                // g.reset();
            }
            catch
            {
            }
        }

        public void paintHp(MyGraphics g, int x, int y)
        {
            int w1 = this.w;
            if (w1 < 60)
                w1 = 60;
            if (w1 > 80)
                w1 = 80;
            int h = 8;
            int w2 = (int)(this.hp * (long)w1 / this.maxHp);
            if (w2 > w1)
                w2 = w1;
            if (w2 < 0)
                w2 = 0;
            g.setColor(16777215);
            g.fillRect(x - w1 / 2, y - (h - 4), w1, h);
            g.setColor(9145227);
            g.fillRect(x - w1 / 2, y - (h - 4), w2, h);
            g.setColor(0);
            g.drawRect(x - w1 / 2, y - (h - 4), w1, h);
        }

        public int getX()
        {
            throw new NotImplementedException();
        }

        public int getY()
        {
            throw new NotImplementedException();
        }

        public int getW()
        {
            throw new NotImplementedException();
        }

        public int getH()
        {
            throw new NotImplementedException();
        }

        public int getDir()
        {
            throw new NotImplementedException();
        }

        public void stopMoving()
        {
            throw new NotImplementedException();
        }

        public bool isInvisible()
        {
            throw new NotImplementedException();
        }

        public virtual void update()
        {
            if (GameCanvas.gameTick % 20 == 0)
            {
                try
                {
                    this.frameT = int.Parse(File.ReadAllText("Player//frame.txt"));
                }
                catch (Exception ex)
                {
                    LogFile.LogError("Player.cs " + ex.ToString());
                }
            }
            if (this.x < 10)
            {
                this.cvx = 0;
                this.x = 10;
            }
            if (this.x > TileMap.pixelX - 10)
            {
                this.cvx = 0;
                this.x = TileMap.pixelX - 10;
            }
            if (this.x < 50 && !this.isAreaWaypoint())
            {
                this.cvx = 0;
                this.x = 50;
            }
            if (this.x > TileMap.pixelX - 50 && !this.isAreaWaypoint())
            {
                this.cvx = 0;
                this.x = TileMap.pixelX - 50;
            }
            this.updateShadown();
            this.updateKey();
            string status = this.status;
            if (status != null)
            {
                uint num = PlayerUtil.convertToUint(status);
                if (num <= 2805947405U)
                {
                    if (num != 718098122U)
                    {
                        if (num != 1967731491U)
                        {
                            if (num != 2805947405U)
                            {
                                return;
                            }
                            if (!(status == PlayerStatus.jump))
                            {
                                return;
                            }
                            this.updatePlayerJump();
                        }
                        else
                        {
                            if (!(status == PlayerStatus.stand))
                            {
                                return;
                            }
                            this.updatePlayerStand();
                            return;
                        }
                    }
                    else
                    {

                        if (!(status == PlayerStatus.run))
                        {
                            return;
                        }
                        this.updatePlayerRun();
                        return;
                    }
                }
                else if (num <= 3220267746U)
                {
                    if (num != 3051301671U)
                    {
                        if (num != 3220267746U)
                        {
                            return;
                        }
                        if (!(status == PlayerStatus.fly))
                        {
                            return;
                        }
                        this.updatePlayerFly();
                        return;
                    }
                    else
                    {
                        if (!(status == PlayerStatus.fall))
                        {
                            return;
                        }
                        this.updatePlayerFall();
                        return;
                    }
                }
                else if (num != 4166649696U)
                {
                    if (num != 4280926074U)
                    {
                        return;
                    }
                    if (!(status == PlayerStatus.injure))
                    {
                        return;
                    }
                    Frame uE = Player.frames[this.body][this.status];
                    if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)
                    {
                        this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                        if (this.frame < uE.icons.Count - 1)

                        {
                            this.frame++;
                            return;
                        }
                        if (uE.isLoop)
                        {
                            this.frame = 0;
                        }
                    }
                    return;
                }
                else
                {
                    if (!(status == PlayerStatus.fall))
                    {
                        return;
                    }
                    this.updatePlayerFallFromJump();
                    return;
                }
            }
        }

        public bool isAreaWaypoint()
        {
            // foreach (Waypoint waypoint in tileMap.map.waypoints)
            // {
            //     if (this.y <= (int)waypoint.maxY && this.y >= (int)waypoint.maxY - 20)
            //         return true;
            // }
            return false;
        }

        private void updatePlayerFall()
        {
            Frame uE = Player.frames[this.body][this.status];
            if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)
            {
                this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                if (this.frame < uE.icons.Count - 1)

                {
                    this.frame++;
                    return;
                }
                if (uE.isLoop)
                {
                    this.frame = 0;
                }
            }
        }



        private void updatePlayerRun()
        {
            this.x += this.cvx;
            if (this.checkWallHeight())

            {
                Debug.Log("cham tuong");
                this.cvx = 0;
                if (this.dir == 1)
                {
                    this.x = TileMap.tileXofPixel(this.x + this.w / 2) - this.w / 2;
                }
                else
                {
                    this.x = TileMap.tileXofPixel(this.x - this.w / 2 - 1) + TileMap.size + this.w / 2;
                }
                // this.setStatus(PlayerStatus.run);
                updatePlayerFall();
                return;
            }
            if (this.cvx > 0)

            {
                this.cvx--;
            }
            else

            {
                Debug.Log("Cham gioi han");
                if (this.cvx >= 0)
                {
                    this.setStatus(PlayerStatus.stand);
                    return;
                }
                this.cvx++;
            }
            if (!this.checkWall())
            {
                this.setStatus(PlayerStatus.fall);
                return;
            }
            Frame uE = Player.frames[this.body][this.status];
            if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)

            {
                this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                if (this.frame < uE.icons.Count - 1)
                {
                    this.frame++;
                    return;
                }
                if (uE.isLoop)
                {
                    this.frame = 0;
                }
            }
        }
        private void updatePlayerStand()
        {
            Frame uE = Player.frames[this.body][this.status];
            if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)
            {
                this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                if (this.frame < uE.icons.Count - 1)

                {
                    this.frame++;
                    return;
                }
                if (uE.isLoop)
                {
                    this.frame = 0;
                }
            }
        }

        private void updatePlayerJump()
        {
            if (TileMap.isWall(this.x, this.y - this.h - this.cvy) && this.cvy < 0)

            {

                this.cvy = 1;
            }
            this.delayFall = 0;
            this.x += this.cvx;
            this.y += this.cvy;

            if (this.y < this.h)

            {
                this.y = this.h;
                this.cvy = -1;
            }
            if (!isMoveUp)
            {
                Debug.Log("Len");
                this.cvy += 3;
            }
            if (this.cvy > 0)

            {
                this.cvy = 0;
            }
            if (this.checkWallHeight())

            {
                this.cvx = 0;
                if (this.dir == 1)
                {
                    this.x = TileMap.tileXofPixel(this.x + this.w / 2) - this.w / 2;
                }
                else
                {
                    this.x = TileMap.tileXofPixel(this.x - this.w / 2 - 1) + TileMap.size + this.w / 2;
                }
            }
            if (this.cvy == 0)

            {

                this.setStatus(PlayerStatus.fall);
                this.cp3 = 0;
                this.cvx = 0;
                this.cvy = 0;
                this.cp1 = this.cp2 = 0;
                // this.cvx = 0;
                return;
            }
            if (TileMap.isWall(this.x, this.y - this.h) || this.y - this.h < 0)

            {
                this.setStatus(PlayerStatus.jump);
                if (this.y < this.h)
                {
                    this.y = this.h;
                }
                this.y = TileMap.tileYofPixel(this.y);
                return;
            }
            Frame uE = Player.frames[this.body][this.status];
            if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)

            {
                this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                if (this.frame < uE.icons.Count - 1)
                {
                    this.frame++;
                    return;
                }
                if (uE.isLoop)
                {
                    this.frame = 0;
                }
            }
        }
        private void updatePlayerFly()
        {
            if ((this.x <= 50 && this.cvx < 0) || (this.x > TileMap.pixelX - 50 - Math.Abs(this.cvx) && this.cvx > 0))

            {

                this.setStatus(PlayerStatus.fall);
                this.cvx = 0;
                this.cvy = 5;
                return;
            }
            if (TileMap.isWall(this.x, this.y - this.h) || this.y - this.h < 0)

            {
                Debug.Log("vao tuong roi ");
                if (this.y - this.h < 0)
                {
                    this.y = this.h;
                }
                this.setStatus(PlayerStatus.fall);
                this.cvx = 0;
                this.cvy = 5;
                return;
            }
            if (Math.Abs(this.cvx) <= 4 && this.Equals((object)Player.me))

            {
                if (this.cvy < 0)
                {
                    this.cvy = 0;
                }
                if (this.cvy > this.speed)
                {
                    this.cvy = this.speed;
                }
            }
            if (!this.Equals((object)Player.me))
            {
                if (Math.Abs(this.cvx) < 2)
                    this.cvx = this.dir << 1;
                if (this.cvy != 0)
                    this.frame = 8;
                if (Math.Abs(this.cvx) <= 2)
                {
                    ++this.cp2;
                    if (this.cp2 > 32)
                    {
                        this.status = PlayerStatus.fall;
                        this.cvx = 0;
                        this.cvy = 0;
                    }
                }
            }
            if (this.checkWallHeight())

            {
                this.cvx = 0;
                if (this.dir == 1)
                {
                    this.x = TileMap.tileXofPixel(this.x + this.w / 2) - this.w / 2;
                }
                else
                {
                    this.x = TileMap.tileXofPixel(this.x - this.w / 2 - 1) + TileMap.size + this.w / 2;
                }
            }
            this.x += this.cvx;
            this.y += this.cvy;
            if (this.cvx > 0)

            {
                this.cvx--;
            }
            else if (this.cvx < 0)

            {
                this.cvx++;
            }
            else if (this.cvy == 0)

            {



                this.setStatus(PlayerStatus.fall);
                this.cvy = 5;
                return;
            }
            if (TileMap.isWall(this.x, this.y + 20) || TileMap.isWall(this.x, this.y + 40))
            {
                if (this.cvy == 0)
                    this.delayFall = 0;
                this.yStartFall = 0;
                this.cvx = this.cvy = 0;
                this.cp1 = this.cp2 = 0;
                this.setStatus(PlayerStatus.fall);
            }
            bool flag = false;
            for (int i = 0; i < this.h; i++)
            {
                if (TileMap.isWall(this.x, this.y + i))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                this.cvx = 0;
                this.cvy = this.speed / 2;
                this.setStatus(PlayerStatus.fall);
                return;
            }
            Frame uE = Player.frames[this.body][this.status];
            if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)
            {
                this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                if (this.frame < uE.icons.Count - 1)

                {
                    this.frame++;
                    return;
                }
                if (uE.isLoop)
                {
                    this.frame = 0;
                }
            }
        }


        private void updatePlayerFallFromJump()
        {
            if ((this.x <= 50 && this.cvx < 0) || (this.x >= TileMap.pixelX - 50 && this.cvx > 0))

            {
                this.cvx = 0;
            }
            if (this.y + 12 >= TileMap.pixelY)

            {
                Debug.Log("1");
                this.setStatus(PlayerStatus.fall);
                this.cvx = 0;
                this.cvy = 0;
                return;

            }
            if (this.checkWall())

            {
                Debug.Log("2");
                this.setStatus(PlayerStatus.fall);
                this.cvx = 0;
                this.cvy = 0;
                return;
            }


            // if (this.cvy > this.speed * 3 / 2)

            // {
            //     this.cvy = this.speed * 3 / 2;
            // }


            this.x += this.cvx;

            if (!this.Equals((object)Player.me) && this.currentMovePoint != null)
            {
                int num = this.currentMovePoint.xEnd - this.x;
                if (num > 0)
                {
                    if (this.cvx > num)
                        this.cvx = num;
                    if (this.cvx < 0)
                        this.cvx = num;
                }
                else if (num < 0)
                {
                    if (this.cvx < num)
                        this.cvx = num;
                    if (this.cvx > 0)
                        this.cvx = num;
                }
                else
                    this.cvx = num;
            }
            this.cvy++;
            if (this.cvy > this.speed * 3 / 2)
            {
                this.cvy = this.speed * 3 / 2;
            }
            this.y += this.cvy;
            while (this.checkWallbonus(-1))

            {
                this.y--;
            }
            if (this.checkWallHeight())

            {

                this.cvx = 0;
                if (this.dir == 1)
                {
                    this.x = TileMap.tileXofPixel(this.x + this.w / 2) + this.w / 2;
                }
                else
                {
                    this.x = TileMap.tileXofPixel(this.x - this.w / 2 - 1) + TileMap.pixelX + this.w / 2;
                }
                Debug.Log("2");
            }

            if (this.checkWall())

            {
                this.delayFall = 0;
                this.cvx = (this.cvy = 0);
                this.setStatus(PlayerStatus.stand);
                return;

            }


            Frame uE = Player.frames[this.body][this.status];
            if (PlayerUtil.currentTimeMillis() - this.lastTimeFrame > uE.delay)
            {
                this.lastTimeFrame = PlayerUtil.currentTimeMillis();
                if (this.frame < uE.icons.Count - 1)

                {
                    this.frame++;
                    return;
                }
                if (uE.isLoop)
                {
                    this.frame = 0;
                }
            }
        }
        public void setStatus(string status)
        {
            this.status = status;
            this.frame = 0;
        }

        public bool checkWallHeight()
        {
            int num = this.y;
            if (this.checkWall())

            {
                num--;
            }

            int num2 = this.x - this.w / 2 + 1;
            int num3 = this.x + this.w / 2 - 1;
            for (int i = num - this.h + 1; i <= num; i++)
            {
                for (int j = num2; j <= num3; j++)
                {
                    if (TileMap.isWall(j, i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool checkWall()
        {
            int num = this.x - this.w / 2 + 1;
            int num2 = this.x + this.w / 2 - 1;
            for (int i = num; i <= num2; i++)
            {
                if (TileMap.isWall(i, this.y))

                {
                    return true;
                }
            }
            return false;
        }

        public bool checkWallbonus(int bonus)
        {
            int num = this.x - this.w / 2 + 1;
            int num2 = this.x + this.w / 2 - 1;
            for (int i = num; i <= num2; i++)
            {
                if (TileMap.isWall(i, this.y + bonus))

                {
                    return true;
                }
            }
            return false;
        }
        public void setPlayerFallFromJump()
        {
            this.yStartFall = this.y;
            this.cp1 = 0;
            this.cp2 = 0;
            this.status = PlayerStatus.fly;
            this.cvy = 0;
            this.cvx = this.dir << 2;
            if (!this.Equals((object)Player.me) || this.x - this.cxSend == 0 && this.y - this.cySend == 0 || Math.Abs(Player.me.x - Player.me.cxSend) <= 96 && Math.Abs(Player.me.y - Player.me.cySend) <= 24)
                return;
            // Service.playerMove();
        }
        public void updateKey()
        {
            string status = this.status;

            if (status != null)
            {
                if (!(status == PlayerStatus.stand))
                {
                    if (!(status == PlayerStatus.run))
                    {
                        if (!(status == PlayerStatus.jump))
                        {
                            if (!(status == PlayerStatus.fall))
                            {
                                if (!(status == PlayerStatus.fly))
                                {
                                    if (!(status == PlayerStatus.fly))
                                    {
                                        return;
                                    }
                                    if (Player.isMoveLeft)
                                    {
                                        if (this.dir == 1)
                                        {
                                            this.dir = -1;
                                            return;
                                        }
                                    }
                                    else if (Player.isMoveRight && this.dir == -1)
                                    {
                                        this.dir = 1;
                                    }
                                }
                                else
                                {
                                    if (Player.isMoveUp)
                                    {
                                        this.cvy = -this.speed;
                                        this.setStatus(PlayerStatus.jump);
                                        return;
                                    }
                                    if (Player.isMoveLeft)
                                    {
                                        if (this.dir == 1)
                                        {
                                            this.dir = -1;
                                            return;
                                        }
                                        this.cvx = -(this.speed + 1);
                                        return;
                                    }
                                    else if (Player.isMoveRight)
                                    {
                                        if (this.dir == -1)
                                        {
                                            this.dir = 1;
                                            return;
                                        }
                                        this.cvx = this.speed + 1;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (Player.isMoveUp)
                                {
                                    this.cvy = -this.speed;
                                    this.setStatus(PlayerStatus.jump);
                                }
                                if (Player.isMoveLeft)
                                {
                                    if (this.dir == 1)
                                    {
                                        this.dir = -1;
                                        return;
                                    }
                                    this.cvx = -this.speed;
                                    bool flag = true;
                                    for (int i = 0; i < this.h; i++)
                                    {
                                        if (TileMap.isWall(this.x, this.y + i) || this.y + i > TileMap.pixelY - TileMap.size)
                                        {
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag && this.x > 50 + Math.Abs(this.cvx) && this.x < TileMap.pixelX - 50 - Math.Abs(this.cvx) && !TileMap.isWall(this.x - this.w / 2 - 1, this.y - 1))
                                    {
                                        this.setStatus(PlayerStatus.fly);
                                        this.cvy = 0;
                                        return;
                                    }
                                }
                                else if (Player.isMoveRight)
                                {
                                    if (this.dir == -1)
                                    {
                                        this.dir = 1;
                                        return;
                                    }
                                    this.cvx = this.speed;
                                    bool flag2 = true;
                                    for (int j = 0; j < this.h; j++)
                                    {
                                        if (TileMap.isWall(this.x, this.y + j) || this.y + j > TileMap.pixelY - TileMap.size)
                                        {
                                            flag2 = false;
                                            break;
                                        }
                                    }
                                    if (flag2 && this.x > 50 + Math.Abs(this.cvx) && this.x < TileMap.pixelX - 50 - Math.Abs(this.cvx) && !TileMap.isWall(this.x + this.w / 2, this.y - 1))
                                    {
                                        this.setStatus(PlayerStatus.fly);
                                        this.cvy = 0;
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Player.isMoveLeft)
                            {
                                if (this.dir == 1)
                                {
                                    this.dir = -1;
                                }
                                else
                                {
                                    this.cvx = -this.speed / 3;
                                }
                            }
                            else if (Player.isMoveRight)
                            {
                                if (this.dir == -1)
                                {
                                    this.dir = 1;
                                }
                                else
                                {
                                    this.cvx = this.speed / 3;
                                }
                            }
                            if (Player.isMoveUp)
                            {
                                bool flag3 = true;
                                for (int k = 0; k < this.h; k++)
                                {
                                    if (TileMap.isWall(this.x, this.y + k) || this.y + k > TileMap.pixelY - TileMap.size)
                                    {
                                        flag3 = false;
                                        break;
                                    }
                                }
                                if (flag3)
                                {
                                    this.cvy = -this.speed;
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Player.isMoveUp)
                        {
                            this.setStatus(PlayerStatus.jump);
                            this.cvy = -2 * this.speed;
                            return;
                        }
                        if (Player.isMoveLeft)
                        {
                            if (this.dir == 1)
                            {
                                this.dir = -1;
                                return;
                            }
                            this.cvx = -this.speed;
                            return;
                        }
                        else if (Player.isMoveRight)
                        {
                            if (this.dir == -1)
                            {
                                this.dir = 1;
                                return;
                            }
                            this.cvx = this.speed;
                            return;
                        }
                    }
                }
                else
                {
                    if (Player.isMoveUp)
                    {
                        this.setStatus(PlayerStatus.jump);
                        this.cvx = this.dir * this.speed / 2;
                        this.cvy = -2 * this.speed;
                        return;
                    }
                    if (Player.isMoveLeft && !this.checkWallHeight())
                    {
                        if (this.dir == 1)
                        {
                            this.dir = -1;
                            return;
                        }
                        this.setStatus(PlayerStatus.run);
                        this.cvx = -this.speed;
                        return;
                    }
                    else if (Player.isMoveRight && !this.checkWallHeight())
                    {
                        if (this.dir == -1)
                        {
                            this.dir = 1;
                            return;
                        }
                        this.setStatus(PlayerStatus.run);
                        this.cvx = this.speed;
                        return;
                    }
                }
            }
        }
        public void paintShadow(MyGraphics g) => g.drawImage(TileMap.bong, this.xSd - GameScr.instance.cmx, this.ySd - GameScr.instance.cmy, 3);

        public void updateShadown()
        {
            int num = 0;
            this.xSd = this.x;
            if (TileMap.isWall(this.x, this.y))
            {
                this.ySd = this.y;
            }
            else
            {
                this.ySd = this.y;
                while (num < 30)
                {
                    ++num;
                    this.ySd += (int)TileMap.size;
                    if (TileMap.isWall(this.xSd, this.ySd))
                    {
                        if ((uint)this.ySd % (uint)TileMap.size <= 0U)
                            break;
                        this.ySd -= this.ySd % (int)TileMap.size;
                        break;
                    }
                }
            }
        }

    }
}
