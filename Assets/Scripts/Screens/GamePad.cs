using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Commons;
using Assets.Scripts.Games;
using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Screens
{
    public class GamePad
    {

        private int xC;


        private int yC;


        private int xM;


        private int yM;


        private int xMLast;


        private int yMLast;

        private int R;

        private int r;
        private int d;


        private int xTemp;


        private int yTemp;


        private int deltaX;

        private int deltaY;


        private int delta;


        private int angle;

        public int xZone;


        public int yZone;


        public int wZone;

        public int hZone;

        private bool isGamePad;

        public bool isSmallGamePad;

        public bool isMediumGamePad;

        public bool isLargeGamePad;

        public GamePad()
        {
            R = 28;
            if (GameCanvas.w < 300)
            {
                isSmallGamePad = true;
                isMediumGamePad = false;
                isLargeGamePad = false;
            }
            if (GameCanvas.w >= 300 && GameCanvas.w <= 380)
            {
                isSmallGamePad = false;
                isMediumGamePad = true;
                isLargeGamePad = false;
            }
            if (GameCanvas.w > 380)
            {
                isSmallGamePad = false;
                isMediumGamePad = false;
                isLargeGamePad = true;
            }
            if (!isLargeGamePad)
            {
                xZone = 0;
                wZone = GameCanvas.w / 2;
                yZone = (GameCanvas.h / 2) >> 1;
                hZone = GameCanvas.h - 80;
            }
            else
            {
                xZone = 0;
                wZone = (GameCanvas.w / 2) / 4 * 3 - 20;
                yZone = (GameCanvas.h / 2) >> 1;
                hZone = GameCanvas.h;
            }

        }
        public void update()
        {
            // if (GameScr.isAnalog == 0)
            // {
            //     return;
            // }
            if (GameScr.isPointerDown && !GameScr.isPointerJustRelease)
            {
                xTemp = GameScr.pxFirst;
                yTemp = GameScr.pyFirst;
                if (xTemp < xZone || xTemp > wZone || yTemp < yZone || yTemp > hZone)
                {
                    return;
                }
                if (!isGamePad)
                {
                    xC = (xM = xTemp);
                    yC = (yM = yTemp);
                }
                isGamePad = true;
                deltaX = GameScr.px - xC;
                deltaY = GameScr.py - yC;
                delta = PlayerUtil.pow(deltaX, 2) + PlayerUtil.pow(deltaY, 2);
                d = PlayerUtil.sqrt(delta);
                if (PlayerUtil.abs(deltaX) <= 4 && PlayerUtil.abs(deltaY) <= 4)
                {
                    return;
                }
                angle = PlayerUtil.angle(deltaX, deltaY);
                if (!GameScr.isPointerHoldIn(xC - R, yC - R, 2 * R, 2 * R))
                {
                    if (d != 0)
                    {
                        yM = deltaY * R / d;
                        xM = deltaX * R / d;
                        xM += xC;
                        yM += yC;
                        if (!PlayerUtil.inRect(xC - R, yC - R, 2 * R, 2 * R, xM, yM))
                        {
                            xM = xMLast;
                            yM = yMLast;
                        }
                        else
                        {
                            xMLast = xM;
                            yMLast = yM;
                        }
                    }
                    else
                    {
                        xM = xMLast;
                        yM = yMLast;
                    }
                }
                else
                {
                    xM = GameScr.px;
                    yM = GameScr.py;
                }
                resetHold();
                if (checkPointerMove(2))
                {
                    if ((angle <= 360 && angle >= 340) || (angle >= 0 && angle <= 20))
                    {
                        Debug.Log("1");
                        // GameScr.keyHold[(!Main.isPC) ? 6 : 24] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 6 : 24] = true;
                    }
                    else if (angle > 40 && angle < 70)
                    {
                        Debug.Log("2");
                        // GameScr.keyHold[(!Main.isPC) ? 6 : 24] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 6 : 24] = true;
                    }
                    else if (angle >= 70 && angle <= 110)
                    {
                        Debug.Log("3");
                        // GameScr.keyHold[(!Main.isPC) ? 8 : 22] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 8 : 22] = true;
                    }
                    else if (angle > 110 && angle < 120)
                    {
                        Debug.Log("4");
                        // GameScr.keyHold[(!Main.isPC) ? 4 : 23] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 4 : 23] = true;
                    }
                    else if (angle >= 120 && angle <= 200)
                    {
                        Debug.Log("5");
                        // GameScr.keyHold[(!Main.isPC) ? 4 : 23] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 4 : 23] = true;
                    }
                    else if (angle > 200 && angle < 250)
                    {
                        Debug.Log("6");
                        // GameScr.keyHold[(!Main.isPC) ? 2 : 21] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 2 : 21] = true;
                        // GameScr.keyHold[(!Main.isPC) ? 4 : 23] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 4 : 23] = true;
                    }
                    else if (angle >= 250 && angle <= 290)
                    {
                        Debug.Log("7");
                        // GameScr.keyHold[(!Main.isPC) ? 2 : 21] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 2 : 21] = true;
                    }
                    else if (angle > 290 && angle < 340)
                    {
                        Debug.Log("8");
                        // GameScr.keyHold[(!Main.isPC) ? 2 : 21] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 2 : 21] = true;
                        // GameScr.keyHold[(!Main.isPC) ? 6 : 24] = true;
                        // GameScr.keyPressed[(!Main.isPC) ? 6 : 24] = true;
                    }
                }
                else
                {
                    resetHold();
                }
            }
            else
            {
                xM = (xC = 45);
                if (!isLargeGamePad)
                {
                    yM = (yC = GameCanvas.h - 90);
                }
                else
                {
                    yM = (yC = GameCanvas.h - 45);
                }
                isGamePad = false;
                resetHold();
            }
        }
        private bool checkPointerMove(int distance)
        {
            // if (GameScr.isAnalog == 0)
            // {
            //     return false;
            // }
            if (Player.me.status == PlayerStatus.jump)
            {
                return true;
            }
            try
            {
                for (int num = 2; num > 0; num--)
                {
                    int i = GameScr.arrPos[num].x - GameScr.arrPos[num - 1].x;
                    int i2 = GameScr.arrPos[num].y - GameScr.arrPos[num - 1].y;
                    if (PlayerUtil.abs(i) > distance && PlayerUtil.abs(i2) > distance)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            return true;
        }
        private void resetHold()
        {
            // GameCanvas.clearKeyHold();
        }
        public bool disableCheckDrag()
        {
            // if (GameScr.isAnalog == 0)
            // {
            //     return false;
            // }
            return isGamePad;
        }
        public bool disableClickMove()
        {
            // if (GameScr.isAnalog == 0)
            // {
            //     return false;
            // }
            // bool flag = false;
            if ((GameScr.px >= xZone && GameScr.px <= wZone && GameScr.py >= yZone && GameScr.py <= hZone) || GameScr.px >= GameCanvas.w - 50)
            {
                return true;
            }
            return false;
        }
        public void paint(MyGraphics g)
        {

            g.drawImage(GameScr.imgAnalog1, this.xC, this.yC, StaticObj.HCENTER_VCENTER);
            g.drawImage(GameScr.imgAnalog2, this.xM, this.yM, StaticObj.HCENTER_VCENTER);
        }
    }
}