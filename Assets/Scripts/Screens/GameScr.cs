using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actions;
using UnityEngine;
using Assets.Scripts.Dialogs;
using System.IO;
using Assets.Scripts.Games;
using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.Models;
using System;
using Newtonsoft.Json;
using LitJson;
using Assets.Scripts.Commons;

namespace Assets.Scripts.Screens
{
    public class GameScr : MyScreen, IChatable, IActionListener
    {
        public int cmx;
        public int cmxTo;

        public int cmyTo;
        public int cmy;
        public static GameScr instance;
        public Image imgSkill;
        public Image imgSkill2;
        public Image imgSelectSkill;
        public Command cmdCenter;
        public Command cmdDie;
        public bool isPaintSkill;
        public Image imgHead;
        public Image imgHp;
        public Image imgMp;
        public Image imgPower;
        public Image imgPean;
        public int tMenuDelay;
        private static int xC;
        private static int yTouchBar;
        private static int yC;
        public bool isEnter;
        // public static ChatPopup chatPopupNpc;
        public static Image imgAnalog1;

        public static GamePad gamePad = new GamePad();
        public static Image imgAnalog2;
        public TileMap tileMap;
        public Image iconSkill;
        public int dxIconSkill;
        public int dyIconSkill;
        public static bool isPointerDown;
        public static int pxFirst;
        private static long lastTimePress = 0L;
        public static int curPos = 0;
        public static int px;
        private static int xTG;

        private static int yTG;

        public static int py;
        private static int xF;

        private static int yF;
        public static int wSkill;

        public static int pyFirst;

        public static int pxLast;
        public static int xHP;

        public static int yHP;

        public static int pyLast;
        public static int xSkill;

        public static int ySkill;

        public static int padSkill;
        public static int pxMouse;

        public static int pyMouse;
        public static bool isPointerDowning;
        public static bool isPointerClick;

        public static bool isPointerJustRelease;
        public static Position[] arrPos = new Position[4];
        public static bool isPointerMove;
        public static bool isPointerJustDown = false;
        public void onCancelChat()
        {
            throw new System.NotImplementedException();
        }
        public GameScr()
        {

            this.LoadMap();
            // GameScr.chatTextField.parentScreen = (IChatable)this;
            // GameScr.cmdDie = new Command(PlayerText.DIES[0], (IActionListener)this, 1, (object)null);
            isPaintSkill = true;
            imgAnalog1 = GameCanvas.loadImage("images/nen-di-chuyen.png");
            imgAnalog2 = GameCanvas.loadImage("images/client_19.png");
            gamePad = new GamePad();
        }

        // private void GameScr()
        // {
        //     // GameScr.flyTexts = new List<FlyText>();
        //     // GameScr.imgSkill = Image.__createImage(File.ReadAllBytes("Skill\\imgSkill0.png"));
        //     // GameScr.imgSkill2 = Image.__createImage(File.ReadAllBytes("Skill\\imgSkill1.png"));
        //     // GameScr.iconSkill = Image.__createImage(File.ReadAllBytes("Skill\\icon.png"));
        //     // string[] strArray = File.ReadAllText("Skill\\dx-dy-icon-screen.txt").Split('-');
        //     // GameScr.dxIconSkill = int.Parse(strArray[0]);
        //     // GameScr.dyIconSkill = int.Parse(strArray[1]);
        //     // GameScr.imgHp = GameCanvas.loadImage("myTextHp.png");
        //     // GameScr.imgMp = GameCanvas.loadImage("myTextMp.png");
        //     // GameScr.imgPower = GameCanvas.loadImage("myTextPower.png");
        //     // GameScr.imgHead = GameCanvas.loadImage("myTextHead.png");
        //     // GameScr.imgSelectSkill = GameCanvas.loadImage("myTextSelectSkill.png");
        //     // GameScr.imgPean = GameCanvas.loadImage("dauthan.png");
        //     // GameScr.keySkills = new Skill[5];
        //     // GameScr.xSkill = 30;
        //     // GameScr.ySkill = GameCanvas.h - 120;

        // }
        public void LoadMap()
        {
            try
            {

                this.tileMap = new TileMap();
                MapTemplate uE;
                this.tileMap.imgTile = Image.__createImage(File.ReadAllBytes("Map//imgTile.png"));
                uE = JsonMapper.ToObject<MapTemplate>(File.ReadAllText("Map//Map.json"));
                this.tileMap.row = uE.row;
                this.tileMap.column = uE.column;
                this.tileMap.data = uE.data;
                TileMap.maps = new int[this.tileMap.row, this.tileMap.column];
                for (int i = 0; i < this.tileMap.row; i++)
                {
                    for (int j = 0; j < this.tileMap.column; j++)
                    {
                        TileMap.maps[i, j] = int.Parse(this.tileMap.data.Substring(0, 1));
                        this.tileMap.data = this.tileMap.data.Substring(1);
                    }
                }
                for (int k = 0; k < 4; k++)
                {
                    string[] array = uE.bgrs_color[k].Split(new char[]
                    {
                ','
                    });
                    this.tileMap.bgrs_color[k, 0] = int.Parse(array[0]);
                    this.tileMap.bgrs_color[k, 1] = int.Parse(array[1]);
                    this.tileMap.bgrs_color[k, 2] = int.Parse(array[2]);
                }
                for (int l = 0; l < uE.bgrs_id.Count; l++)
                {


                    {
                        this.tileMap.bgrs_image.Add(Image.__createImage(File.ReadAllBytes("Map//Backgrounds//" + l.ToString() + ".png")));
                    }
                }
                TileMap.pixelX = TileMap.size * (int)this.tileMap.column;
                TileMap.pixelY = TileMap.size * (int)this.tileMap.row;

                Player.me.x = TileMap.pixelX / 2;
                Player.me.y = TileMap.PlayerX(Player.me.x);
            }
            catch (Exception ex)
            {
                LogFile.LogError(ex.ToString());
            }
        }

        public void onChatFromMe(string text, string to)
        {
            throw new System.NotImplementedException();
        }

        public void perform(int idAction, object p)
        {
            throw new System.NotImplementedException();
        }

        public static GameScr gI()
        {
            if (instance == null)
                instance = new GameScr();
            return instance;
        }
        private void paintGamePad(MyGraphics g)
        {

            // g.drawImage((MyScreen.keyTouch != 5 && MyScreen.keyMouse != 5) ? imgFire0 : imgFire1, xF + 20, yF + 20, mGraphics.HCENTER | mGraphics.VCENTER);
            gamePad.paint(g);
            // g.drawImage((MyScreen.keyTouch != 13) ? imgFocus : imgFocus2, xTG + 20, yTG + 20, mGraphics.HCENTER | mGraphics.VCENTER);

        }
        public override void paint(MyGraphics g)
        {
            // GameCanvas.paintBGGameScr(g);

            this.tileMap.paint(g);
            paintGamePad(g);
            MyFont.text_big_red.drawString(g, "X-Y: " + Player.me.x.ToString() + "-" + Player.me.y.ToString(), GameCanvas.w / 2, 0, 2);
            MyFont.text_big_red.drawString(g, "status: " + Player.me.status.ToString() + " frame: " + Player.me.frame.ToString(), GameCanvas.w / 2, 32, 2);
            MyFont.text_big_red.drawString(g, "frame: " + Player.me.frame.ToString(), GameCanvas.w / 2, 65, 2);
            Player.me.paint(g);
            // GameScr.chatTextField.paint(g);



            // this.paintSkill(g);
        }


        public override void update()
        {
            // SmallImage.update();
            // this.updateFlyText();
            try
            {
                this.updateCamera();
                Player.me.update();

                setTouchBtn();
                // foreach (Mob mob in TileMap.mobs)
                //     mob.update();
                // foreach (Npc npc in GameScr.npcs)
                //     npc.update();
                // foreach (Player player in GameScr.players)
                //     player.update();
                // foreach (MonsterDart monsterDart in MonsterDart.monsterDarts)
                //     monsterDart.update();
                // foreach (Waypoint waypoint in TileMap.waypoints)
                //     waypoint.update();
                // if (GameScr.chatPopupNpc != null)
                //     GameScr.chatPopupNpc.update();
                // foreach (ItemTime itemTime in Player.itemTimes)
                //     itemTime.update();
            }
            catch
            {
            }
            // InfoMe.update();
            // if (this.tMenuDelay <= 0)
            //     return;
            // --this.tMenuDelay;
        }

        private static void setTouchBtn()
        {

            xTG = (xF = GameCanvas.w - 45);
            if (gamePad.isLargeGamePad)
            {
                xSkill = gamePad.wZone - 20;
                wSkill = 35;
                xHP = xF - 45;
            }
            else if (gamePad.isMediumGamePad)
            {
                xHP = xF - 45;
            }
            yF = GameCanvas.h - 45;
            yTG = yF - 45;

        }
        // Start is called before the first frame update
        private void updateCamera()
        {
            if (this.cmx < this.cmxTo)
            {
                int num = this.cmxTo - this.cmx >> 2;
                if (num < 1)
                {
                    num = 1;
                }
                this.cmx += num;
            }
            else if (this.cmx > this.cmxTo)
            {
                int num2 = this.cmx - this.cmxTo >> 2;
                if (num2 < 1)
                {
                    num2 = 1;
                }
                this.cmx -= num2;
            }
            if (this.cmy < this.cmyTo)
            {
                int num3 = this.cmyTo - this.cmy >> 2;
                if (num3 < 1)
                {
                    num3 = 1;
                }
                this.cmy += num3;
            }
            else if (this.cmy > this.cmyTo)
            {
                int num4 = this.cmy - this.cmyTo >> 2;
                if (num4 < 1)
                {
                    num4 = 1;
                }
                this.cmy -= num4;
            }

            this.loadCamera(Player.me.x, Player.me.y);

        }

        public void loadCamera(int playerX, int playerY)
        {

            this.cmxTo = playerX - GameCanvas.w / 2;
            if (this.cmxTo < 30)
            {
                this.cmxTo = 30;
            }
            if (this.cmxTo > TileMap.pixelX - GameCanvas.w - 30)
            {
                this.cmxTo = TileMap.pixelX - GameCanvas.w - 30;
            }
            this.cmyTo = playerY - GameCanvas.h * 2 / 3;
            if (this.cmyTo < 0)
            {
                this.cmyTo = 0;
            }
            if (this.cmyTo > TileMap.pixelY - GameCanvas.h - 30)
            {

                this.cmyTo = TileMap.pixelY - GameCanvas.h - 30;
            }
            yTouchBar = GameCanvas.h - 88;
            xC = GameCanvas.w - 40;
            yC = 2;
            if (GameCanvas.w <= 240)
            {
                xC = GameCanvas.w - 35;
                yC = 5;
            }
            xF = GameCanvas.w - 55;
            yF = yTouchBar + 35;
            xTG = GameCanvas.w - 37;
            yTG = yTouchBar - 1;
            if (GameCanvas.w >= 450)
            {
                yTG -= 12;
                yHP -= 7;
                xF -= 10;
                yF -= 5;
                xTG -= 10;
            }

        }


        private static void updateGamePad()
        {
            // if (isAnalog == 0 || Char.myCharz().statusMe == 14)
            // {
            //     return;
            // }
            if (isPointerHoldIn(xF, yF, 40, 40))
            {
                MyScreen.keyTouch = 5;
                if (isPointerJustRelease)
                {
                    // keyPressed[(!Main.isPC) ? 5 : 25] = true;
                    isPointerClick = (GameCanvas.isPointerJustDown = (isPointerJustRelease = false));
                }
            }
            gamePad.update();
            if (isPointerHoldIn(xTG, yTG, 34, 34))
            {
                MyScreen.keyTouch = 13;
                GameCanvas.isPointerJustDown = false;
                isPointerDowning = false;
                if (isPointerClick && isPointerJustRelease)
                {
                    // Char.myCharz().findNextFocusByKey();
                    isPointerClick = (GameCanvas.isPointerJustDown = (isPointerJustRelease = false));
                }
            }
        }
        public override void pointerClicked(int x, int y)
        {

            isPointerJustRelease = false;
            isPointerJustDown = true;
            isPointerDown = true;
            isPointerClick = true;
            isPointerMove = false;
            lastTimePress = PlayerUtil.currentTimeMillis();
            pxFirst = x;
            pyFirst = y;
            pxLast = x;
            pyLast = y;
            px = x;
            py = y;
           
        }

        public static bool isPointerHoldIn(int x, int y, int w, int h)
        {
            if (!isPointerDown && !isPointerJustRelease)
            {
                return false;
            }
            if (px >= x && px <= x + w && py >= y && py <= y + h)
            {
                return true;
            }
            return false;
        }
        public override void pointerDragged(int x, int y)
        {
            if (PlayerUtil.abs(x - pxLast) >= 10 || PlayerUtil.abs(y - pyLast) >= 10)
            {
                isPointerClick = false;
                isPointerDown = true;
                isPointerMove = true;
            }
            px = x;
            py = y;
            curPos++;
            if (curPos > 3)
            {
                curPos = 0;
            }
            arrPos[curPos] = new Position(x, y);
        }

        public override void pointerReleased(int x, int y)
        {
            isPointerDown = false;
            isPointerJustRelease = true;
            isPointerMove = false;
            MyScreen.keyTouch = -1;
            px = x;
            py = y; 
        }

        public override void pointerMove(int x, int y)
        {
            pxMouse = x;
            pyMouse = y;
        }
        public static void clearKeyPressed()
        {
            // for (int i = 0; i < keyPressed.Length; i++)
            // {
            //     keyPressed[i] = false;
            // }
            isPointerJustRelease = false;
        }
        public override void keyPress(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.Tab:
                case KeyCode.F2:
                    // Player.me.findNextFocusByKey();
                    break;
                case KeyCode.Return:
                    // if (GameScr.cmdCenter != null)
                    // {
                    //     GameScr.cmdCenter.performAction();
                    //     break;
                    // }
                    // if (Player.me.status == 1 || Player.me.status == 2 || Player.me.status == 3 || Player.me.status == 4 || Player.me.status == 10)
                    // {
                    //     this.doFire();
                    //     break;
                    // }
                    break;
                case KeyCode.Alpha1:
                    // if (GameScr.keySkills[0] != null)
                    // {
                    //     this.doSelectSkill(GameScr.keySkills[0]);
                    //     break;
                    // }
                    break;
                case KeyCode.Alpha2:
                    // if (GameScr.keySkills[1] != null)
                    // {
                    //     this.doSelectSkill(GameScr.keySkills[1]);
                    //     break;
                    // }
                    break;
                case KeyCode.Alpha3:
                    // if (GameScr.keySkills[2] != null)
                    // {
                    //     this.doSelectSkill(GameScr.keySkills[2]);
                    //     break;
                    // }
                    break;
                case KeyCode.Alpha4:
                    // if (GameScr.keySkills[3] != null)
                    // {
                    //     this.doSelectSkill(GameScr.keySkills[3]);
                    //     break;
                    // }
                    break;
                case KeyCode.Alpha5:
                    // if (GameScr.keySkills[4] != null)
                    // {
                    //     this.doSelectSkill(GameScr.keySkills[4]);
                    //     break;
                    // }
                    break;
                // case KeyCode.Alpha6:
                //     Service.upSkill(0, 1);
                //     break;
                // case KeyCode.Alpha7:
                //     Service.upPotential(1, 1);
                //     break;
                // case KeyCode.Alpha8:
                //     Player.me.isWaitDart = false;
                //     break;
                // case KeyCode.M:
                //     Service.openMenu(3);
                //     break;
                // case KeyCode.R:
                //     GameScr.chatTextField.isShow = true;
                //     break;
                case KeyCode.T:
                    //      GameCanvas.frames = JsonConvert.DeserializeObject<Dictionary<int, Frame>>(File.ReadAllText("Player//frame.json"));
                    break;
                case KeyCode.X:
                    // if (Player.skillPaintTool == null)
                    //     File.WriteAllText("error null.txt", "1");
                    // try
                    // {
                    //     File.WriteAllText("skill.json", JsonMapper.ToJson((object)Player.skillPaintTool));
                    // }
                    // catch (Exception ex)
                    // {
                    //     File.WriteAllText("error.txt", ex.ToString());
                    // }
                    //  Player.me.setAutoSkillPaint(Player.skillPaintTool, !TileMap.isWall(Player.me.x, Player.me.y) ? 1 : 0);
                    break;
                case KeyCode.Y:
                    // Player.LoadSkillPaint();
                    break;
                case KeyCode.Z:
                    //  GameCanvas.parts = JsonConvert.DeserializeObject<Dictionary<int, Part>>(File.ReadAllText("Player//Part.json"));
                    break;
                case KeyCode.UpArrow:
                    Player.me.currentMovePoint = (MovePoint)null;
                    Player.isMoveDown = false;
                    Player.isMoveUp = true;
                    break;
                case KeyCode.DownArrow:
                    Player.me.currentMovePoint = (MovePoint)null;
                    Player.isMoveDown = true;
                    break;
                case KeyCode.RightArrow:
                    Player.me.currentMovePoint = (MovePoint)null;
                    Player.isMoveLeft = false;
                    Player.isMoveRight = true;
                    break;
                case KeyCode.LeftArrow:
                    Player.me.currentMovePoint = (MovePoint)null;
                    Player.isMoveRight = false;
                    Player.isMoveLeft = true;
                    break;
                case KeyCode.F1:
                    // this.showMenu();
                    break;
            }

            // if (!GameScr.chatTextField.isShow)
            // {
            //     if (!GameCanvas.dialog.isShow)
            //     {

            //     }
            //     base.keyPress(keyCode);
            // }
            // else
            // {
            //     switch (keyCode)
            //     {
            //         case KeyCode.Backspace:
            //             // GameScr.chatTextField.right.performAction();
            //             break;
            //         case KeyCode.Return:
            //             // GameScr.chatTextField.left.performAction();
            //             break;
            //         default:
            //             // GameScr.chatTextField.keyPress(keyCode);
            //             break;
            //     }
            // }
        }

        public override void updateKey()
        {
            updateGamePad();
        }
        // public override void updateKey()
        // {
        //     Debug.Log(Player.me.status);
        //     if (Player.me.status == PlayerStatus.stand)
        //     {
        //         if (Player.isMoveUp)
        //         {
        //             if (Player.me.isLockMove)
        //                 return;
        //             this.setPlayerJump(0);
        //         }
        //         else if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //             {
        //                 Player.me.dir = -1;
        //             }
        //             else
        //             {
        //                 if (Player.me.isLockMove)
        //                     return;
        //                 if (Player.me.x - Player.me.cxSend != 0)
        //                     // Service.playerMove();
        //                     Player.me.status = PlayerStatus.run;
        //                 Player.me.cvx = -Player.me.speed;
        //             }
        //         }
        //         else
        //         {
        //             if (!Player.isMoveRight)
        //                 return;
        //             if (Player.me.dir == -1)
        //                 Player.me.dir = 1;
        //             else if (!Player.me.isLockMove)
        //             {
        //                 if (Player.me.x - Player.me.cxSend != 0)
        //                     // Service.playerMove();
        //                     Player.me.status = PlayerStatus.run;
        //                 Player.me.cvx = Player.me.speed;
        //             }
        //         }
        //     }
        //     else if (Player.me.status == PlayerStatus.run)
        //     {
        //         if (Player.isMoveUp)
        //         {
        //             if (Player.me.x - Player.me.cxSend != 0 || Player.me.y - Player.me.cySend != 0)
        //                 // Service.playerMove();
        //                 Player.me.cvy = -10;
        //             Player.me.status = PlayerStatus.jump;
        //             Player.me.cp1 = 0;
        //         }
        //         else if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //                 Player.me.dir = -1;
        //             else
        //                 Player.me.cvx = -Player.me.speed;
        //         }
        //         else
        //         {
        //             if (!Player.isMoveRight)
        //                 return;
        //             if (Player.me.dir == -1)
        //                 Player.me.dir = 1;
        //             else
        //                 Player.me.cvx = Player.me.speed;
        //         }
        //     }
        //     else if (Player.me.status == PlayerStatus.jump)
        //     {
        //         if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //                 Player.me.dir = -1;
        //             else
        //                 Player.me.cvx = -Player.me.speed;
        //         }
        //         else if (Player.isMoveRight)
        //         {
        //             if (Player.me.dir == -1)
        //                 Player.me.dir = 1;
        //             else
        //                 Player.me.cvx = Player.me.speed;
        //         }
        //         if (!Player.isMoveUp || !Player.me.isCanFly || Player.me.mp <= 0L || Player.me.cp1 >= 8 || Player.me.cvy <= -4)
        //             return;
        //         ++Player.me.cp1;
        //         Player.me.cvy = -7;
        //     }
        //     else if (Player.me.status == PlayerStatus.fall)
        //     {
        //         if (Player.isMoveUp && Player.me.mp > 0L && Player.me.isCanFly)
        //         {
        //             if ((Player.me.x - Player.me.cxSend != 0 || Player.me.y - Player.me.cySend != 0) && (Math.Abs(Player.me.x - Player.me.cxSend) > 96 || Math.Abs(Player.me.y - Player.me.cySend) > 24))
        //                 // Service.playerMove();
        //                 Player.me.cvy = -10;
        //             Player.me.status = PlayerStatus.jump;
        //             Player.me.cp1 = 0;
        //         }
        //         if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //             {
        //                 Player.me.dir = -1;
        //             }
        //             else
        //             {
        //                 ++Player.me.cp1;
        //                 Player.me.cvx = -Player.me.speed;
        //                 if (Player.me.cp1 <= 5 || Player.me.cvy <= 6)
        //                     return;
        //                 Player.me.status = PlayerStatus.fly;
        //                 Player.me.cp1 = 0;
        //                 Player.me.cvy = 0;
        //             }
        //         }
        //         else
        //         {
        //             if (!Player.isMoveRight)
        //                 return;
        //             if (Player.me.dir == -1)
        //             {
        //                 Player.me.dir = 1;
        //             }
        //             else
        //             {
        //                 ++Player.me.cp1;
        //                 Player.me.cvx = Player.me.speed;
        //                 if (Player.me.cp1 > 5 && Player.me.cvy > 6)
        //                 {
        //                     Player.me.status = PlayerStatus.fly;
        //                     Player.me.cp1 = 0;
        //                     Player.me.cvy = 0;
        //                 }
        //             }
        //         }
        //     }
        //     else if (Player.me.status == PlayerStatus.fly)
        //     {
        //         if (!Player.me.isCanFly || Player.me.mp <= 0L)
        //             return;
        //         if (Player.isMoveUp)
        //         {
        //             if ((Player.me.x - Player.me.cxSend != 0 || Player.me.y - Player.me.cySend != 0) && (Math.Abs(Player.me.x - Player.me.cxSend) > 96 || Math.Abs(Player.me.y - Player.me.cySend) > 24))
        //                 // Service.playerMove();
        //                 Player.me.cvy = -10;
        //             Player.me.status = PlayerStatus.jump;
        //             Player.me.cp1 = 0;
        //         }
        //         else if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //                 Player.me.dir = -1;
        //             else
        //                 Player.me.cvx = -(Player.me.speed + 1);
        //         }
        //         else
        //         {
        //             if (!Player.isMoveRight)
        //                 return;
        //             if (Player.me.dir == -1)
        //                 Player.me.dir = 1;
        //             else
        //                 Player.me.cvx = Player.me.speed + 1;
        //         }
        //     }
        //     else if (Player.me.status == PlayerStatus.injure)
        //     {
        //         if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //                 Player.me.dir = -1;
        //             else
        //                 Player.me.cvx = -(Player.me.speed + 2);
        //         }
        //         else
        //         {
        //             if (!Player.isMoveRight)
        //                 return;
        //             if (Player.me.dir == -1)
        //                 Player.me.dir = 1;
        //             else
        //                 Player.me.cvx = Player.me.speed - 2;
        //         }
        //     }
        //     else
        //     {
        //         if (Player.me.status != PlayerStatus.dead)
        //             return;
        //         if (Player.isMoveLeft)
        //         {
        //             if (Player.me.dir == 1)
        //                 Player.me.dir = -1;
        //         }
        //         else if (Player.isMoveRight && Player.me.dir == -1)
        //             Player.me.dir = 1;
        //     }
        // }


        public void setPlayerJump(int cvx)
        {
            if (Player.me.x - Player.me.cxSend != 0 || Player.me.y - Player.me.cySend != 0)
                // Service.playerMove();
                Player.me.cvy = -15;

            Player.me.cvx = cvx;

            Player.me.status = PlayerStatus.jump;
            Player.me.cp1 = 0;
        }
    }

}