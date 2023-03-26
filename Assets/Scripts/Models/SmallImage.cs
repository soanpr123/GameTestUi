// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Models.SmallImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Commons;
using Assets.Scripts.Games;
using Assets.Scripts.GraphicCustoms;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class SmallImage
    {
        public static int smallCount;
        public static short maxSmall;
        public static Dictionary<int, Image> image = new Dictionary<int, Image>();

        public static void createImage(int id)
        {
            if (SmallImage.image.ContainsKey(id))
            {
                return;
            }
            try
            {
                Image image1 = Image.__createImage(File.ReadAllBytes("Player//SmallImages//" + id.ToString() + ".png"));
                if (image1 == null)
                    return;
                Image image = Image.createImage(image1.w, image1.h);

                SmallImage.image.Add(id, image1);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
                LogFile.LogError("SmallImage.cs" + ex.ToString());
            }
            // if (SmallImage.image.ContainsKey(id))
            // {
            //     // Image image = Image.__createImage(File.ReadAllBytes("Skill//icon//" + id.ToString() + ".png"));
            //     // if (image == null)
            //     //     return;
            //     // SmallImage.smalls.Add(id, new Small(image, id));
            //     return;
            // }
            // else
            // {
            //     for (int index = 0; index < GameCanvas.mobTemplates.Count; ++index)
            //     {
            //         if (GameCanvas.mobTemplates[index].imgs.Contains(id))
            //         {
            //             Image image = Image.__createImage(File.ReadAllBytes("Map//Mobs//" + id.ToString() + ".png"));
            //             if (image == null)
            //                 return;
            //             SmallImage.smalls.Add(id, new Small(image, id));
            //             return;
            //         }
            //     }
            //     Image image1 = Image.__createImage(File.ReadAllBytes("Player//imgs//" + id.ToString() + ".png"));
            //     if (image1 == null)
            //         return;
            //     SmallImage.smalls.Add(id, new Small(image1, id));
            // }
        }

        public static void drawSmallImage(
          MyGraphics g,
          int id,
          int x,
          int y,
          int transform,
          int anchor)
        {
            if (SmallImage.image.ContainsKey(id))
                SmallImage.Paint(g, SmallImage.image[id], transform, x, y, anchor);
            else
                SmallImage.createImage(id);
        }
        public static void Paint(MyGraphics g, Image img, int transform, int x, int y, int anchor)
        {
            if (img == null)
            {
                return;
            }
            g.drawRegion(img, 0, 0, img.getWidth(), img.getHeight(), transform, x, y, anchor);
        }

        // public static void drawSmallImage(
        //   MyGraphics g,
        //   int id,
        //   int x,
        //   int y,
        //   int transform,
        //   int anchor,
        //   float angle)
        // {
        //     if (SmallImage.smalls.ContainsKey(id))
        //         SmallImage.smalls[id].paint(g, transform, x, y, anchor, angle);
        //     else
        //         SmallImage.createImage(id);
        // }

        // public static void drawSmallImage(MyGraphics g, int id, int x, int y, float angle)
        // {
        //     if (SmallImage.smalls.ContainsKey(id))
        //         SmallImage.smalls[id].paint(g, angle, x, y, 3);
        //     else
        //         SmallImage.createImage(id);
        // }

        // public static void update()
        // {
        //     int num = 0;
        //     if (GameCanvas.gameTick % 1000 != 0)
        //         return;
        //     for (int key = 0; key < SmallImage.image.Count; ++key)
        //     {
        //         if (SmallImage.image[key] != null)
        //         {
        //             ++num;
        //             SmallImage.image[key].update();
        //         }
        //     }
        // }
    }
}
