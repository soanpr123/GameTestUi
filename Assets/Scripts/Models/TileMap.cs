// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Models.TileMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Games;
using Assets.Scripts.GraphicCustoms;
using Assets.Scripts.Screens;
using LitJson;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class TileMap
    {
        public int mapId;
        public int type;
        public int planetId;
        public int areaId;
        public static sbyte size = 54;
        public int column;
        public int row;
        public static int pixelX;
        public static int pixelY;
        public static int[,] maps;
        // public static List<Waypoint> waypoints;
        public static Image bong = GameCanvas.loadImage("myTexture2dbong.png");
        public string data;
        public string name;
        public List<Image> bgrs_image = new List<Image>();
        public int[,] bgrs_color = new int[4, 3];
        public Image imgTile;

        public Player player;
        // public static List<Mob> mobs;



        public static void loadMap()
        {


        }
        public void paint(MyGraphics g)
        {
            // if (Player.isLoadingMap)
            //     return;

            g.setColor((float)this.bgrs_color[0, 0], (float)this.bgrs_color[0, 1], (float)this.bgrs_color[0, 2]);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            int i = 0;

            while (i < GameCanvas.w)
            {
                g.drawImage(this.bgrs_image[0], i, GameCanvas.h / 5 * 4, StaticObj.BOTTOM_LEFT);
                i += this.bgrs_image[0].getWidth();
            }
            g.setColor((float)this.bgrs_color[1, 0], (float)this.bgrs_color[1, 1], (float)this.bgrs_color[1, 2]);
            g.fillRect(0, GameCanvas.h / 5 * 4, GameCanvas.w, GameCanvas.h / 5);
            int y1 = GameCanvas.h - (GameScr.instance.cmy >> 1) / 2;
            for (i = -((GameScr.instance.cmx >> 2)); i < GameCanvas.w; i += this.bgrs_image[1].getWidth())
            {
                g.drawImage(this.bgrs_image[1], i, y1, StaticObj.BOTTOM_LEFT);
            }
            if (y1 < GameCanvas.h)
            {
                g.setColor((float)this.bgrs_color[2, 0], (float)this.bgrs_color[2, 1], (float)this.bgrs_color[2, 2]);
                g.fillRect(0, y1, GameCanvas.w, GameCanvas.h - y1);
            }
            int y2 = GameCanvas.h - (GameScr.instance.cmy >> 1) / 2 + GameCanvas.h / 5;
            for (i = -(GameScr.instance.cmx >> 1); i < GameCanvas.w; i += this.bgrs_image[2].getWidth())
            {
                g.drawImage(this.bgrs_image[2], i, y2, StaticObj.BOTTOM_LEFT);
            }
            if (y2 < GameCanvas.h)
            {
                g.setColor((float)this.bgrs_color[3, 0], (float)this.bgrs_color[3, 1], (float)this.bgrs_color[3, 2]);
                g.fillRect(0, y2, GameCanvas.w, GameCanvas.h - y2);
            }
            g.drawImage(this.imgTile, -GameScr.instance.cmx, -GameScr.instance.cmy);
            // g.setColor(TileMap.template.colorBgrs[0]);
            // g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            // int w1 = TileMap.imgBgrs[0].w;
            // for (int x = 0; x < GameCanvas.w; x += w1)
            //     g.drawImage(TileMap.imgBgrs[0], x, GameCanvas.h / 5 * 4, StaticObj.BOTTOM_LEFT);
            // g.setColor(TileMap.template.colorBgrs[1]);
            // g.fillRect(0, GameCanvas.h / 5 * 4, GameCanvas.w, GameCanvas.h / 5);
            // int y1 = GameCanvas.h - (GameScr.instance.cmy >> 1) / 2;
            // int w2 = TileMap.imgBgrs[1].w;
            // for (int x = -(GameScr.instance.cmx >> 2); x < GameCanvas.w; x += w2)
            //     g.drawImage(TileMap.imgBgrs[1], x, y1, StaticObj.BOTTOM_LEFT);
            // if (y1 < GameCanvas.h)
            // {
            //     g.setColor(TileMap.template.colorBgrs[2]);
            //     g.fillRect(0, y1, GameCanvas.w, GameCanvas.h - y1);
            // }
            // int y2 = GameCanvas.h - (GameScr.instance.cmy >> 1) / 2 + GameCanvas.h / 5;
            // int w3 = TileMap.imgBgrs[2].w;
            // for (int x = -(GameScr.instance.cmx >> 1); x < GameCanvas.w; x += w3)
            //     g.drawImage(TileMap.imgBgrs[2], x, y2, StaticObj.BOTTOM_LEFT);
            // if (y2 < GameCanvas.h)
            // {
            //     g.setColor(TileMap.template.colorBgrs[3]);
            //     g.fillRect(0, y2, GameCanvas.w, GameCanvas.h - y2);
            // }
            // g.drawImage(TileMap.imgTile, -GameScr.instance.cmx, -GameScr.instance.cmy, 0);
            // foreach (Mob mob in TileMap.mobs)
            //     mob.paint(g);

        }

        public static bool isWall(int px, int py)
        {
            int index1 = px / (int)size;
            int index2 = py / (int)size;
            int num = 0;
            try
            {
                num = maps[index2, index1];
            }
            catch
            {
            }
            return num != 0;
        }
        public static int PlayerX(int x)
        {
            int i = 0;
            int num = 0;
            while (i < 90)
            {
                i++;
                num += size;
                if (isWall(x, num))
                {
                    if (num % size != 0)
                    {
                        num -= num % size;
                        break;
                    }
                    break;
                }
            }
            return num;
        }
        public static int tileYofPixel(int py) => py / (int)size * (int)size;

        public static int tileXofPixel(int px) => px / (int)size * (int)size;
    }
}
