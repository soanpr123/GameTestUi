// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.GraphicCustoms.MyFont
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Games;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GraphicCustoms
{
    public class MyFont
    {
        public bool isBolder;
        public static MyFont text_big_white = new MyFont(Color.white, 0);
        public static MyFont text_big_yellow;
        public static MyFont text_big_blue;
        public static MyFont text_big_black = new MyFont(Color.black, 0);
        public static MyFont text_big_focus_cmd = new MyFont(Color.white, 0);
        public static MyFont text_big_unfocus_cmd = new MyFont(Color.white, 0);
        public static MyFont text_big_red;
        public static MyFont text_big_green;
        public static MyFont text_black;
        public static MyFont text_red;
        public static MyFont text_green;
        public static MyFont text_blue;
        public static MyFont text_brown;
        public static MyFont text_white;
        public static MyFont text_yellow;
        public static MyFont text_orange;
        public static MyFont text_grey;
        public static MyFont text_health;
        public static MyFont text_critial;
        public static MyFont text_miss;
        public static MyFont text_exp;
        public static MyFont text_mini_black;
        public static MyFont text_mini_brown;
        public static MyFont text_mini_white;
        public Font myFont;
        private int height;
        private int wO;
        public Color color = Color.white;
        public int type;

        static MyFont()
        {
            MyFont.text_big_yellow = new MyFont(Color.yellow, 0);
            MyFont.text_big_blue = new MyFont(new Color(0.53f, 0.8f, 0.98f), 0);
            MyFont.text_big_red = new MyFont(new Color(0.75f, 0.0f, 0.0f), 0);
            MyFont.text_big_green = new MyFont(new Color(0.0f, 0.75f, 0.0f), 0);
            MyFont.text_mini_black = new MyFont(Color.black, 3);
            MyFont.text_mini_brown = new MyFont((Color)new Color32((byte)119, (byte)69, (byte)6, byte.MaxValue), 3);
            MyFont.text_mini_white = new MyFont(Color.white, 3);
            MyFont.text_black = new MyFont(Color.black, 1);
            MyFont.text_yellow = new MyFont(Color.yellow, 1);
            MyFont.text_brown = new MyFont((Color)new Color32((byte)119, (byte)69, (byte)6, byte.MaxValue), 1);
            MyFont.text_red = new MyFont(new Color(0.75f, 0.0f, 0.0f), 1);
            MyFont.text_green = new MyFont(new Color(0.0f, 0.75f, 0.0f), 1);
            MyFont.text_blue = new MyFont(new Color(0.0f, 0.0f, 0.75f), 1);
            MyFont.text_white = new MyFont(Color.white, 1);
            MyFont.text_orange = new MyFont((Color)new Color32((byte)223, (byte)116, (byte)20, byte.MaxValue), 1);
            MyFont.text_grey = new MyFont((Color)new Color32((byte)87, (byte)90, (byte)92, byte.MaxValue), 1);
            MyFont.text_health = new MyFont(Color.red, "Fonts/normal", true);
            MyFont.text_critial = new MyFont(Color.yellow, "Fonts/normal", true);
            MyFont.text_miss = new MyFont(Color.black, "Fonts/normal", true);
            MyFont.text_exp = new MyFont(Color.green, "Fonts/normal", true);
        }

        public MyFont(Color color, string path, bool isBolder)
        {
            this.myFont = (Font)Resources.Load(path);
            this.color = color;
            this.isBolder = isBolder;
            this.wO = this.getWidthExactOf("o");
        }

        public MyFont(Color color, int type)
        {
            this.type = type;
            string path = "Fonts/normal";
            switch (type)
            {
                case 1:
                    path = "Fonts/normal";
                    break;
                case 2:
                    path = "Fonts/normal";
                    break;
                case 3:
                    path = "Fonts/normal";
                    break;
            }
            this.myFont = (Font)Resources.Load(path);
            this.color = color;
            this.wO = this.getWidthExactOf("o");
        }

        public void setHeight(int height) => this.height = height;

        public void drawString(MyGraphics g, string st, int x, int y, int align) => this._drawString(g, st, x, y, align);

        public List<string> splitFontVector(string src, int lineWidth)
        {
            List<string> stringList = new List<string>();
            string empty = string.Empty;
            for (int index = 0; index < src.Length; ++index)
            {
                if (src[index] == '\n' || src[index] == '\b')
                {
                    stringList.Add(empty);
                    empty = string.Empty;
                }
                else
                {
                    empty += src[index].ToString();
                    if (this.getWidth(empty) > lineWidth)
                    {
                        int num = empty.Length - 1;
                        while (num >= 0 && empty[num] != ' ')
                            --num;
                        if (num < 0)
                            num = empty.Length - 1;
                        stringList.Add(empty.Substring(0, num));
                        index = index - (empty.Length - num) + 1;
                        empty = string.Empty;
                    }
                    if (index == src.Length - 1 && !empty.Trim().Equals(string.Empty))
                        stringList.Add(empty);
                }
            }
            return stringList;
        }

        public string[] splitFontArray(string src, int lineWidth)
        {
            List<string> stringList = this.splitFontVector(src, lineWidth);
            string[] strArray = new string[stringList.Count];
            for (int index = 0; index < stringList.Count; ++index)
                strArray[index] = stringList[index];
            return strArray;
        }

        public int getWidth(string s) => this.getWidthExactOf(s);

        public int getWidthExactOf(string s)
        {
            try
            {
                GUIStyle guiStyle = new GUIStyle();
                guiStyle.font = this.myFont;
                if (this.type == 0)
                    guiStyle.fontSize = 40;
                else if (this.type == 1)
                    guiStyle.fontSize = 32;
                else if (this.type == 3)
                    guiStyle.fontSize = 24;
                return (int)guiStyle.CalcSize(new GUIContent(s)).x;
            }
            catch
            {
                return this.getWidthNotExactOf(s);
            }
        }

        public int getWidthNotExactOf(string s) => s.Length * this.wO;

        public int getHeight()
        {
            if (this.height > 0)
                return this.height;
            GUIStyle guiStyle = new GUIStyle();
            guiStyle.font = this.myFont;
            if (this.type == 0)
                guiStyle.fontSize = 40;
            else if (this.type == 1)
                guiStyle.fontSize = 32;
            else if (this.type == 3)
                guiStyle.fontSize = 24;
            try
            {
                this.height = (int)guiStyle.CalcSize(new GUIContent("Adg")).y + 2;
            }
            catch
            {
                this.height = 32;
            }
            return this.height;
        }

        public void _drawString(MyGraphics g, string st, int x0, int y0, int align)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.font = this.myFont;
            if (this.type == 0)
            {
                y0 -= 2;
                style.fontSize = 40;
            }
            else if (this.type == 1)
            {
                y0 -= 2;
                style.fontSize = 32;
            }
            else if (this.type == 3)
            {
                y0 -= 2;
                style.fontSize = 24;
            }
            float x = 0.0f;
            float y = 0.0f;
            switch (align)
            {
                case 0:
                    x = (float)x0;
                    y = (float)y0;
                    style.alignment = TextAnchor.UpperLeft;
                    break;
                case 1:
                    x = (float)(x0 - GameCanvas.w);
                    y = (float)y0;
                    style.alignment = TextAnchor.UpperRight;
                    break;
                case 2:
                case 3:
                    x = (float)(x0 - GameCanvas.w / 2);
                    y = (float)y0;
                    style.alignment = TextAnchor.UpperCenter;
                    break;
            }
            style.normal.textColor = this.color;
            g.drawString(st, (int)x, (int)y, style);
        }
    }
}
