// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.GraphicCustoms.Paint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Dialogs;
using Assets.Scripts.Games;
using Assets.Scripts.Models;
using Assets.Scripts.Screens;

namespace Assets.Scripts.GraphicCustoms
{
    public class Paint
    {
        public static Image[] goc = new Image[6];
        public static int lenCaption = 0;
        public static Image imgCheck;

        static Paint()
        {
            for (int index = 0; index < Paint.goc.Length; ++index)
                Paint.goc[index] = GameCanvas.loadImage("myTexture2dgoc" + (index + 1).ToString() + ".png");
            Paint.imgCheck = GameCanvas.loadImage("myTexture2dcheck.png");
        }

        public void paintCmdBar(MyGraphics g, Command left, Command center, Command right)
        {
            MyFont textBigWhite = MyFont.text_big_white;
            int num = 3;
            if (left != null)
            {
                Paint.lenCaption = textBigWhite.getWidth(left.caption);
                if (Paint.lenCaption > 0)
                {
                    if (left.x >= 0 && left.y > 0)
                    {
                        left.paint(g);
                    }
                    else
                    {
                        g.drawImage(GameCanvas.imgLbtn, 1, GameCanvas.h - MyScreen.cmdH - 1, 0);
                        textBigWhite.drawString(g, left.caption, 35, GameCanvas.h - MyScreen.cmdH + 3 + num, 2);
                    }
                }
            }
            if (center != null)
            {
                Paint.lenCaption = textBigWhite.getWidth(center.caption);
                if (Paint.lenCaption > 0)
                {
                    if (center.x > 0 && center.y > 0)
                    {
                        center.paint(g);
                    }
                    else
                    {
                        g.drawImage(GameCanvas.imgLbtn, GameCanvas.h / 2 - 35, GameCanvas.h - MyScreen.cmdH - 1, 0);
                        textBigWhite.drawString(g, center.caption, GameCanvas.h / 2, GameCanvas.h - MyScreen.cmdH + 3 + num, 2);
                    }
                }
            }
            if (right == null)
                return;
            Paint.lenCaption = textBigWhite.getWidth(right.caption);
            if (Paint.lenCaption <= 0)
                return;
            if (right.x > 0 && right.y > 0)
            {
                right.paint(g);
            }
            else
            {
                g.drawImage(GameCanvas.imgLbtn, GameCanvas.w - 71, GameCanvas.h - MyScreen.cmdH - 1, 0);
                textBigWhite.drawString(g, right.caption, GameCanvas.w - 35, GameCanvas.h - MyScreen.cmdH + 3 + num, 2);
            }
        }

        public void paintCheck(MyGraphics g, int x, int y, bool check, bool focus)
        {
            if (focus)
                g.drawRegion(Paint.imgCheck, 0, (!check ? 1 : 3) * 28, 32, 28, 0, x, y, 0);
            else
                g.drawRegion(Paint.imgCheck, 0, (check ? 2 : 0) * 28 + 1, 32, 28, 0, x, y, 0);
        }

        public void paintPopUp(int x, int y, int w, int h, MyGraphics g)
        {
            g.setColor(247f, 174f, 24f);
            g.fillRect(x + 18, y, (w - 36) / 2 - 32, h + 1);
            g.fillRect(x + 18 + (w - 36) / 2 + 32, y, (w - 36) / 2 - 22, h + 1);
            g.fillRect(x, y + 8, w + 1, h - 17);
            g.setColor(241f, 221f, 150f);
            g.fillRect(x + 18, y + 2, (w - 36) / 2 - 32, h - 3);
            g.fillRect(x + 18 + (w - 36) / 2 + 31, y + 2, (w - 38) / 2 - 22, h - 3);
            g.fillRect(x + 2, y + 6, w - 3, h - 11);
            g.drawImage(Paint.goc[0], x, y, MyGraphics.TOP | MyGraphics.LEFT);
            g.drawImage(Paint.goc[2], x + w + 1, y, StaticObj.TOP_RIGHT);
            g.drawImage(Paint.goc[1], x, y + h + 1, StaticObj.BOTTOM_LEFT);
            g.drawImage(Paint.goc[3], x + w + 1, y + h + 1, StaticObj.BOTTOM_RIGHT);
            g.drawImage(Paint.goc[4], x + w / 2, y, StaticObj.TOP_CENTER);
            g.drawImage(Paint.goc[5], x + w / 2, y + h + 1, StaticObj.BOTTOM_HCENTER);
        }
    }
}
