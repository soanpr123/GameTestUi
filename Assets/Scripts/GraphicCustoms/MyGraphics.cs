
using Assets.Scripts.Games;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GraphicCustoms
{
    public class MyGraphics
    {
        public static int HCENTER = 1;
        public static int VCENTER = 2;
        public static int LEFT = 4;
        public static int RIGHT = 8;
        public static int TOP = 16;
        public static int BOTTOM = 32;
        public float r;
        public float g;
        public float b;
        public float a;
        public int clipX;
        public int clipY;
        public int clipW;
        public int clipH;
        private bool isClip;
        private bool isTranslate = true;
        private int translateX;
        private int translateY;
        private float translateXf;
        private float translateYf;
        public static Hashtable cachedTextures = new Hashtable();
        private int clipTX;
        private int clipTY;
        private Vector2 pos = new Vector2(0.0f, 0.0f);
        private Rect rect;
        private Matrix4x4 matrixBackup;
        private Vector2 pivot;
        public Vector2 size = new Vector2(128f, 128f);
        public Vector2 relativePosition = new Vector2(0.0f, 0.0f);
        private Material lineMaterial;

        private void cache(string key, Texture value)
        {
            if (MyGraphics.cachedTextures.Count > 400)
                MyGraphics.cachedTextures.Clear();
            if (value.width * value.height >= GameCanvas.w * GameCanvas.h)
                return;
            MyGraphics.cachedTextures.Add((object)key, (object)value);
        }

        public void translate(int tx, int ty)
        {
            this.translateX += tx;
            this.translateY += ty;
            this.isTranslate = true;
            if (this.translateX != 0 || this.translateY != 0)
                return;
            this.isTranslate = false;
        }

        public void translate(float x, float y)
        {
            this.translateXf += x;
            this.translateYf += y;
            this.isTranslate = true;
            if ((double)this.translateXf != 0.0 || (double)this.translateYf != 0.0)
                return;
            this.isTranslate = false;
        }

        public int getTranslateX() => this.translateX;

        public int getTranslateY() => this.translateY;

        public void setClip(int x, int y, int w, int h)
        {
            this.clipTX = this.translateX;
            this.clipTY = this.translateY;
            this.clipX = x;
            this.clipY = y;
            this.clipW = w;
            this.clipH = h;
            this.isClip = true;
        }

        public void drawRect(int x, int y, int w, int h)
        {
            int num = 1;
            this.fillRect(x, y, w, num);
            this.fillRect(x, y, num, h);
            this.fillRect(x + w, y, num, h + 1);
            this.fillRect(x, y + h, w + 1, num);
        }

        public void fillRect(int x, int y, int w, int h, int color)
        {
            float alpha = 0.5f;
            this.setColor(color, alpha);
            this.fillRect(x, y, w, h);
        }

        public void fillRect(int x, int y, int w, int h)
        {
            if (w < 0 || h < 0)
                return;
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            int width1 = 1;
            int height1 = 1;
            string key = "fr" + width1.ToString() + height1.ToString() + this.r.ToString() + this.g.ToString() + this.b.ToString() + this.a.ToString();
            Texture2D image = (Texture2D)MyGraphics.cachedTextures[(object)key];
            if ((Object)image == (Object)null)
            {
                image = new Texture2D(width1, height1);
                Color color = new Color(this.r, this.g, this.b, this.a);
                image.SetPixel(0, 0, color);
                image.Apply();
                this.cache(key, (Texture)image);
            }
            int x1 = 0;
            int y1 = 0;
            int width2 = 0;
            int height2 = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                y1 = this.clipY;
                width2 = this.clipW;
                height2 = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    y1 += this.clipTY;
                }
            }
            if (this.isClip)
                GUI.BeginGroup(new Rect((float)x1, (float)y1, (float)width2, (float)height2));
            GUI.DrawTexture(new Rect((float)(x - x1), (float)(y - y1), (float)w, (float)h), (Texture)image);
            if (!this.isClip)
                return;
            GUI.EndGroup();
        }

        public void fillRect(
          int x,
          int y,
          int w,
          int h,
          int topLeftRadius,
          int topRightRadius,
          int bottomLeftRadius,
          int bottomRightRadius)
        {
            this.fillRect(x, y, w, h, 10, topLeftRadius, topRightRadius, bottomLeftRadius, bottomRightRadius);
        }

        public void fillRect(
          int x,
          int y,
          int w,
          int h,
          int wBorder,
          int topLeftRadius,
          int topRightRadius,
          int bottomLeftRadius,
          int bottomRightRadius)
        {
            if (w < 0 || h < 0)
                return;
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            int width1 = 1;
            int height1 = 1;
            string key = "fr" + width1.ToString() + height1.ToString() + this.r.ToString() + this.g.ToString() + this.b.ToString() + this.a.ToString();
            Color color = new Color(this.r, this.g, this.b, this.a);
            Texture2D image = (Texture2D)MyGraphics.cachedTextures[(object)key];
            if ((Object)image == (Object)null)
            {
                image = new Texture2D(width1, height1);
                image.SetPixel(0, 0, color);
                image.Apply();
                this.cache(key, (Texture)image);
            }
            int x1 = 0;
            int y1 = 0;
            int width2 = 0;
            int height2 = 0;
            Vector4 borderWidths = new Vector4((float)x, (float)y, (float)(w - 2 * wBorder), (float)h);
            Vector4 borderRadiuses = new Vector4((float)topLeftRadius, (float)topRightRadius, (float)bottomRightRadius, (float)bottomLeftRadius);
            if (this.isClip)
            {
                x1 = this.clipX;
                y1 = this.clipY;
                width2 = this.clipW;
                height2 = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    y1 += this.clipTY;
                }
            }
            if (this.isClip)
                GUI.BeginGroup(new Rect((float)x1, (float)y1, (float)width2, (float)height2));
            GUI.DrawTexture(new Rect((float)(x - x1), (float)(y - y1), (float)w, (float)h), (Texture)image, ScaleMode.StretchToFill, false, 0.0f, GUI.color, borderWidths, borderRadiuses);
            if (!this.isClip)
                return;
            GUI.EndGroup();
        }

        public void setColor(int rgb)
        {
            int num1 = rgb & (int)byte.MaxValue;
            int num2 = rgb >> 8 & (int)byte.MaxValue;
            int num3 = rgb >> 16 & (int)byte.MaxValue;
            this.b = (float)num1 / 256f;
            this.g = (float)num2 / 256f;
            this.r = (float)num3 / 256f;
            this.a = 1f;
        }

        public void setColor(float r, float g, float b)
        {
            this.b = b / 256f;
            this.g = g / 256f;
            this.r = r / 256f;
            this.a = 1f;
        }

        public void setColor(float r, float g, float b, float a)
        {
            this.b = b / 256f;
            this.g = g / 256f;
            this.r = r / 256f;
            this.a = a;
        }

        public void setColor(Color color)
        {
            this.b = color.b;
            this.g = color.g;
            this.r = color.r;
            this.a = color.a;
        }

        public void setColor(string rgb)
        {
            try
            {
                string[] strArray = rgb.Split(',');
                this.r = float.Parse(strArray[0]) / 256f;
                this.g = float.Parse(strArray[1]) / 256f;
                this.b = float.Parse(strArray[2]) / 256f;
                this.a = 1f;
            }
            catch
            {
                this.setColor(0);
            }
        }

        public void setColor(Color color, float a)
        {
            this.b = color.b;
            this.g = color.g;
            this.r = color.r;
            this.a = a;
        }

        public void drawString(string s, int x, int y, GUIStyle style)
        {
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            int x1 = 0;
            int y1 = 0;
            int width = 0;
            int height = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                y1 = this.clipY;
                width = this.clipW;
                height = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    y1 += this.clipTY;
                }
            }
            if (this.isClip)
                GUI.BeginGroup(new Rect((float)x1, (float)y1, (float)width, (float)height));
            GUI.Label(new Rect((float)(x - x1), (float)(y - y1), (float)Screen.width, 100f), s, style);
            if (!this.isClip)
                return;
            GUI.EndGroup();
        }

        public void setColor(int rgb, float alpha)
        {
            int num1 = rgb & (int)byte.MaxValue;
            int num2 = rgb >> 8 & (int)byte.MaxValue;
            int num3 = rgb >> 16 & (int)byte.MaxValue;
            this.b = (float)num1 / 256f;
            this.g = (float)num2 / 256f;
            this.r = (float)num3 / 256f;
            this.a = alpha;
        }

        private void UpdatePos(int anchor)
        {
            Vector2 vector2 = new Vector2(0.0f, 0.0f);
            switch (anchor)
            {
                case 3:
                    vector2 = new Vector2(this.size.x / 2f, this.size.y / 2f);
                    break;
                case 6:
                    vector2 = new Vector2(0.0f, (float)(Screen.height / 2));
                    break;
                case 10:
                    vector2 = new Vector2((float)Screen.width, (float)(Screen.height / 2));
                    break;
                case 17:
                    vector2 = new Vector2((float)(Screen.width / 2), 0.0f);
                    break;
                case 20:
                    vector2 = new Vector2(0.0f, 0.0f);
                    break;
                case 24:
                    vector2 = new Vector2((float)Screen.width, 0.0f);
                    break;
                case 33:
                    vector2 = new Vector2((float)(Screen.width / 2), (float)Screen.height);
                    break;
                case 36:
                    vector2 = new Vector2(0.0f, (float)Screen.height);
                    break;
                case 40:
                    vector2 = new Vector2((float)Screen.width, (float)Screen.height);
                    break;
            }
            this.pos = vector2 + this.relativePosition;
            this.rect = new Rect(this.pos.x - this.size.x * 0.5f, this.pos.y - this.size.y * 0.5f, this.size.x, this.size.y);
            this.pivot = new Vector2(this.rect.xMin + this.rect.width * 0.5f, this.rect.yMin + this.rect.height * 0.5f);
        }

        public void drawRegion(
          Image arg0,
          int x0,
          int y0,
          int w0,
          int h0,
          int arg5,
          int x,
          int y,
          int arg8)
        {
            this._drawRegion(arg0, (float)x0, (float)y0, w0, h0, arg5, x, y, arg8);
        }

        public void drawRegionSmall(
          Image arg0,
          int x0,
          int y0,
          int w0,
          int h0,
          int transform,
          int x,
          int y,
          int anchor)
        {
            this._drawRegion(arg0, (float)x0, (float)y0, w0, h0, transform, x, y, anchor);
        }

        public void drawRegionSmall(
          Image arg0,
          int x0,
          int y0,
          int w0,
          int h0,
          int transform,
          int x,
          int y,
          int anchor,
          float angel)
        {
            this._drawRegion(arg0, (float)x0, (float)y0, w0, h0, transform, x, y, anchor, angel);
        }

        public void drawRegionWithTransform(
          Image arg0,
          int x0,
          int y0,
          int w0,
          int h0,
          float angel,
          int x,
          int y,
          int anchor)
        {
            this._drawRegionWithTransform(arg0, (float)x0, (float)y0, w0, h0, angel, x, y, anchor);
        }

        public void drawRegionWith(
          Image arg0,
          int x0,
          int y0,
          int w0,
          int h0,
          float angel,
          int x,
          int y,
          int anchor,
          int transform)
        {
            this._drawRegionWith(arg0, (float)x0, (float)y0, w0, h0, angel, x, y, anchor, transform);
        }

        public void drawRegion(
          Image arg0,
          int x0,
          int y0,
          int w0,
          int h0,
          int arg5,
          int x,
          int y,
          int arg8,
          bool isClip)
        {
            this.drawRegion(arg0, x0, y0, w0, h0, arg5, x, y, arg8);
        }

        public void __drawRegion(
          Image image,
          int x0,
          int y0,
          int w,
          int h,
          int transform,
          float x,
          float y,
          int anchor)
        {
            if (image == null)
                return;
            if (this.isTranslate)
            {
                x += (float)this.translateX;
                y += (float)this.translateY;
            }
            float num1 = (float)w;
            float num2 = (float)h;
            float num3 = 0.0f;
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            float num7 = 1f;
            float num8 = 0.0f;
            int num9 = 1;
            if ((anchor & MyGraphics.HCENTER) == MyGraphics.HCENTER)
                num5 -= num1 / 2f;
            if ((anchor & MyGraphics.VCENTER) == MyGraphics.VCENTER)
                num6 -= num2 / 2f;
            if ((anchor & MyGraphics.RIGHT) == MyGraphics.RIGHT)
                num5 -= num1;
            if ((anchor & MyGraphics.BOTTOM) == MyGraphics.BOTTOM)
                num6 -= num2;
            x += num5;
            y += num6;
            int x1 = 0;
            int width = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                int clipY = this.clipY;
                width = this.clipW;
                int clipH = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    clipY += this.clipTY;
                }
                Rect r1 = new Rect(x, y, (float)w, (float)h);
                Rect r2 = new Rect((float)x1, (float)clipY, (float)width, (float)clipH);
                Rect rect = this.intersectRect(r1, r2);
                if ((double)rect.width <= 0.0 || (double)rect.height <= 0.0)
                    return;
                num1 = rect.width;
                num2 = rect.height;
                num3 = rect.x - r1.x;
                num4 = rect.y - r1.y;
            }
            float num10 = 0.0f;
            float num11 = 0.0f;
            switch (transform)
            {
                case 1:
                    num9 = -1;
                    num11 += num2;
                    break;
                case 2:
                    num10 += num1;
                    num7 = -1f;
                    if (this.isClip)
                    {
                        if ((double)x1 > (double)x)
                            num8 = 0.0f - num3;
                        else if ((double)(x1 + width) < (double)x + (double)w)
                            num8 = (float)(0.0 - ((double)(x1 + width) - (double)x - (double)w));
                        break;
                    }
                    break;
                case 3:
                    num9 = -1;
                    num11 += num2;
                    num7 = -1f;
                    num10 += num1;
                    break;
            }
            int num12 = 0;
            int num13 = 0;
            if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
            {
                this.matrixBackup = GUI.matrix;
                this.size = new Vector2((float)w, (float)h);
                this.relativePosition = new Vector2(x, y);
                this.UpdatePos(3);
                switch (transform)
                {
                    case 5:
                        this.size = new Vector2((float)w, (float)h);
                        this.UpdatePos(3);
                        break;
                    case 6:
                        this.UpdatePos(3);
                        break;
                }
                switch (transform)
                {
                    case 4:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num10 += num1;
                        num7 = -1f;
                        if (this.isClip)
                        {
                            if ((double)x1 > (double)x)
                                num8 = 0.0f - num3;
                            else if ((double)(x1 + width) < (double)x + (double)w)
                                num8 = (float)(0.0 - ((double)(x1 + width) - (double)x - (double)w));
                            break;
                        }
                        break;
                    case 5:
                        GUIUtility.RotateAroundPivot(90f, this.pivot);
                        break;
                    case 6:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        break;
                    case 7:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num9 = -1;
                        num11 += num2;
                        break;
                }
            }
            Graphics.DrawTexture(new Rect(x + num3 + num10 + (float)num12, y + num4 + (float)num13 + num11, num1 * num7, num2 * (float)num9), (Texture)image.texture, new Rect(((float)x0 + num3 + num8) / (float)image.texture.width, (float)((double)image.texture.height - (double)num2 - ((double)y0 + (double)num4)) / (float)image.texture.height, num1 / (float)image.texture.width, num2 / (float)image.texture.height), 0, 0, 0, 0);
            if (transform != 5 && transform != 6 && transform != 4 && transform != 7)
                return;
            GUI.matrix = this.matrixBackup;
        }

        public void _drawRegion(
          Image image,
          float x0,
          float y0,
          int w,
          int h,
          int transform,
          int x,
          int y,
          int anchor)
        {
            if (image == null)
                return;
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            float num1 = (float)w;
            float num2 = (float)h;
            float num3 = 0.0f;
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            float num7 = 1f;
            float num8 = 0.0f;
            int num9 = 1;
            if ((anchor & MyGraphics.HCENTER) == MyGraphics.HCENTER)
                num5 -= num1 / 2f;
            if ((anchor & MyGraphics.VCENTER) == MyGraphics.VCENTER)
                num6 -= num2 / 2f;
            if ((anchor & MyGraphics.RIGHT) == MyGraphics.RIGHT)
                num5 -= num1;
            if ((anchor & MyGraphics.BOTTOM) == MyGraphics.BOTTOM)
                num6 -= num2;
            x += (int)num5;
            y += (int)num6;
            int x1 = 0;
            int width = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                int clipY = this.clipY;
                width = this.clipW;
                int clipH = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    clipY += this.clipTY;
                }
                Rect r1 = new Rect((float)x, (float)y, (float)w, (float)h);
                Rect r2 = new Rect((float)x1, (float)clipY, (float)width, (float)clipH);
                Rect rect = this.intersectRect(r1, r2);
                if ((double)rect.width <= 0.0 || (double)rect.height <= 0.0)
                    return;
                num1 = rect.width;
                num2 = rect.height;
                num3 = rect.x - r1.x;
                num4 = rect.y - r1.y;
            }
            float num10 = 0.0f;
            float num11 = 0.0f;
            switch (transform)
            {
                case 1:
                    num9 = -1;
                    num11 += num2;
                    break;
                case 2:
                    num10 += num1;
                    num7 = -1f;
                    if (this.isClip)
                    {
                        if (x1 > x)
                            num8 = 0.0f - num3;
                        else if (x1 + width < x + w)
                            num8 = (float)-(x1 + width - x - w);
                        break;
                    }
                    break;
                case 3:
                    num9 = -1;
                    num11 += num2;
                    num7 = -1f;
                    num10 += num1;
                    break;
            }
            int num12 = 0;
            int num13 = 0;
            if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
            {
                this.matrixBackup = GUI.matrix;
                this.size = new Vector2((float)w, (float)h);
                this.relativePosition = new Vector2((float)x, (float)y);
                this.UpdatePos(3);
                switch (transform)
                {
                    case 5:
                        this.size = new Vector2((float)w, (float)h);
                        this.UpdatePos(3);
                        break;
                    case 6:
                        this.UpdatePos(3);
                        break;
                }
                switch (transform)
                {
                    case 4:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num10 += num1;
                        num7 = -1f;
                        if (this.isClip)
                        {
                            if (x1 > x)
                                num8 = 0.0f - num3;
                            else if (x1 + width < x + w)
                                num8 = (float)-(x1 + width - x - w);
                            break;
                        }
                        break;
                    case 5:
                        GUIUtility.RotateAroundPivot(90f, this.pivot);
                        break;
                    case 6:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        break;
                    case 7:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num9 = -1;
                        num11 += num2;
                        break;
                }
            }
            Graphics.DrawTexture(new Rect((float)x + num3 + num10 + (float)num12, (float)y + num4 + (float)num13 + num11, num1 * num7, num2 * (float)num9), (Texture)image.texture, new Rect((x0 + num3 + num8) / (float)image.texture.width, (float)((double)image.texture.height - (double)num2 - ((double)y0 + (double)num4)) / (float)image.texture.height, num1 / (float)image.texture.width, num2 / (float)image.texture.height), 0, 0, 0, 0);
            if (transform != 5 && transform != 6 && transform != 4 && transform != 7)
                return;
            GUI.matrix = this.matrixBackup;
        }

        public void _drawRegion(
          Image image,
          float x0,
          float y0,
          int w,
          int h,
          int transform,
          int x,
          int y,
          int anchor,
          float angel)
        {
            if (image == null)
                return;
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            float num1 = (float)w;
            float num2 = (float)h;
            float num3 = 0.0f;
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            float num7 = 1f;
            float num8 = 0.0f;
            int num9 = 1;
            if ((anchor & MyGraphics.HCENTER) == MyGraphics.HCENTER)
                num5 -= num1 / 2f;
            if ((anchor & MyGraphics.VCENTER) == MyGraphics.VCENTER)
                num6 -= num2 / 2f;
            if ((anchor & MyGraphics.RIGHT) == MyGraphics.RIGHT)
                num5 -= num1;
            if ((anchor & MyGraphics.BOTTOM) == MyGraphics.BOTTOM)
                num6 -= num2;
            x += (int)num5;
            y += (int)num6;
            int x1 = 0;
            int width = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                int clipY = this.clipY;
                width = this.clipW;
                int clipH = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    clipY += this.clipTY;
                }
                Rect r1 = new Rect((float)x, (float)y, (float)w, (float)h);
                Rect r2 = new Rect((float)x1, (float)clipY, (float)width, (float)clipH);
                Rect rect = this.intersectRect(r1, r2);
                if ((double)rect.width <= 0.0 || (double)rect.height <= 0.0)
                    return;
                num1 = rect.width;
                num2 = rect.height;
                num3 = rect.x - r1.x;
                num4 = rect.y - r1.y;
            }
            float num10 = 0.0f;
            float num11 = 0.0f;
            switch (transform)
            {
                case 1:
                    num9 = -1;
                    num11 += num2;
                    break;
                case 2:
                    num10 += num1;
                    num7 = -1f;
                    if (this.isClip)
                    {
                        if (x1 > x)
                            num8 = 0.0f - num3;
                        else if (x1 + width < x + w)
                            num8 = (float)-(x1 + width - x - w);
                        break;
                    }
                    break;
                case 3:
                    num9 = -1;
                    num11 += num2;
                    num7 = -1f;
                    num10 += num1;
                    break;
            }
            int num12 = 0;
            int num13 = 0;
            if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
            {
                this.matrixBackup = GUI.matrix;
                this.size = new Vector2((float)w, (float)h);
                this.relativePosition = new Vector2((float)x, (float)y);
                this.UpdatePos(3);
                switch (transform)
                {
                    case 5:
                        this.size = new Vector2((float)w, (float)h);
                        this.UpdatePos(3);
                        break;
                    case 6:
                        this.UpdatePos(3);
                        break;
                }
                switch (transform)
                {
                    case 4:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num10 += num1;
                        num7 = -1f;
                        if (this.isClip)
                        {
                            if (x1 > x)
                                num8 = 0.0f - num3;
                            else if (x1 + width < x + w)
                                num8 = (float)-(x1 + width - x - w);
                            break;
                        }
                        break;
                    case 5:
                        GUIUtility.RotateAroundPivot(90f, this.pivot);
                        break;
                    case 6:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        break;
                    case 7:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num9 = -1;
                        num11 += num2;
                        break;
                }
            }
            GUIUtility.RotateAroundPivot(angel, this.pivot);
            Graphics.DrawTexture(new Rect((float)x + num3 + num10 + (float)num12, (float)y + num4 + (float)num13 + num11, num1 * num7, num2 * (float)num9), (Texture)image.texture, new Rect((x0 + num3 + num8) / (float)image.texture.width, (float)((double)image.texture.height - (double)num2 - ((double)y0 + (double)num4)) / (float)image.texture.height, num1 / (float)image.texture.width, num2 / (float)image.texture.height), 0, 0, 0, 0);
            if (transform != 5 && transform != 6 && transform != 4 && transform != 7)
                return;
            GUI.matrix = this.matrixBackup;
        }

        public void _drawRegionWithTransform(
          Image image,
          float x0,
          float y0,
          int w,
          int h,
          float angle,
          int x,
          int y,
          int anchor)
        {
            int num1 = 5;
            if (image == null)
                return;
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            float num2 = (float)w;
            float num3 = (float)h;
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            float num7 = 0.0f;
            float num8 = 1f;
            float num9 = 0.0f;
            int num10 = 1;
            if ((anchor & MyGraphics.HCENTER) == MyGraphics.HCENTER)
                num6 -= num2 / 2f;
            if ((anchor & MyGraphics.VCENTER) == MyGraphics.VCENTER)
                num7 -= num3 / 2f;
            if ((anchor & MyGraphics.RIGHT) == MyGraphics.RIGHT)
                num6 -= num2;
            if ((anchor & MyGraphics.BOTTOM) == MyGraphics.BOTTOM)
                num7 -= num3;
            x += (int)num6;
            y += (int)num7;
            int x1 = 0;
            int width = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                int clipY = this.clipY;
                width = this.clipW;
                int clipH = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    clipY += this.clipTY;
                }
                Rect r1 = new Rect((float)x, (float)y, (float)w, (float)h);
                Rect r2 = new Rect((float)x1, (float)clipY, (float)width, (float)clipH);
                Rect rect = this.intersectRect(r1, r2);
                if ((double)rect.width <= 0.0 || (double)rect.height <= 0.0)
                    return;
                num2 = rect.width;
                num3 = rect.height;
                num4 = rect.x - r1.x;
                num5 = rect.y - r1.y;
            }
            float num11 = 0.0f;
            float num12 = 0.0f;
            switch (num1)
            {
                case 1:
                    num10 = -1;
                    num12 += num3;
                    break;
                case 2:
                    num11 += num2;
                    num8 = -1f;
                    if (this.isClip)
                    {
                        if (x1 > x)
                            num9 = 0.0f - num4;
                        else if (x1 + width < x + w)
                            num9 = (float)-(x1 + width - x - w);
                        break;
                    }
                    break;
                case 3:
                    num10 = -1;
                    num12 += num3;
                    num8 = -1f;
                    num11 += num2;
                    break;
            }
            int num13 = 0;
            int num14 = 0;
            if (num1 == 5 || num1 == 6 || num1 == 4 || num1 == 7)
            {
                this.matrixBackup = GUI.matrix;
                this.size = new Vector2((float)w, (float)h);
                this.relativePosition = new Vector2((float)x, (float)y);
                this.UpdatePos(3);
                switch (num1)
                {
                    case 5:
                        this.size = new Vector2((float)w, (float)h);
                        this.UpdatePos(3);
                        break;
                    case 6:
                        this.UpdatePos(3);
                        break;
                }
                switch (num1)
                {
                    case 4:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num11 += num2;
                        num8 = -1f;
                        if (this.isClip)
                        {
                            if (x1 > x)
                                num9 = 0.0f - num4;
                            else if (x1 + width < x + w)
                                num9 = (float)-(x1 + width - x - w);
                            break;
                        }
                        break;
                    case 5:
                        GUIUtility.RotateAroundPivot(angle, this.pivot);
                        break;
                    case 6:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        break;
                    case 7:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num10 = -1;
                        num12 += num3;
                        break;
                }
            }
            Graphics.DrawTexture(new Rect((float)x + num4 + num11 + (float)num13, (float)y + num5 + (float)num14 + num12, num2 * num8, num3 * (float)num10), (Texture)image.texture, new Rect((x0 + num4 + num9) / (float)image.texture.width, (float)((double)image.texture.height - (double)num3 - ((double)y0 + (double)num5)) / (float)image.texture.height, num2 / (float)image.texture.width, num3 / (float)image.texture.height), 0, 0, 0, 0);
            if (num1 != 5 && num1 != 6 && num1 != 4 && num1 != 7)
                return;
            GUI.matrix = this.matrixBackup;
        }

        public void _drawRegionWith(
          Image image,
          float x0,
          float y0,
          int w,
          int h,
          float angle,
          int x,
          int y,
          int anchor,
          int transform)
        {
            int num1 = transform;
            if (image == null)
                return;
            if (this.isTranslate)
            {
                x += this.translateX;
                y += this.translateY;
            }
            float num2 = (float)w;
            float num3 = (float)h;
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            float num7 = 0.0f;
            float num8 = 1f;
            float num9 = 0.0f;
            int num10 = 1;
            if ((anchor & MyGraphics.HCENTER) == MyGraphics.HCENTER)
                num6 -= num2 / 2f;
            if ((anchor & MyGraphics.VCENTER) == MyGraphics.VCENTER)
                num7 -= num3 / 2f;
            if ((anchor & MyGraphics.RIGHT) == MyGraphics.RIGHT)
                num6 -= num2;
            if ((anchor & MyGraphics.BOTTOM) == MyGraphics.BOTTOM)
                num7 -= num3;
            x += (int)num6;
            y += (int)num7;
            int x1 = 0;
            int width = 0;
            if (this.isClip)
            {
                x1 = this.clipX;
                int clipY = this.clipY;
                width = this.clipW;
                int clipH = this.clipH;
                if (this.isTranslate)
                {
                    x1 += this.clipTX;
                    clipY += this.clipTY;
                }
                Rect r1 = new Rect((float)x, (float)y, (float)w, (float)h);
                Rect r2 = new Rect((float)x1, (float)clipY, (float)width, (float)clipH);
                Rect rect = this.intersectRect(r1, r2);
                if ((double)rect.width <= 0.0 || (double)rect.height <= 0.0)
                    return;
                num2 = rect.width;
                num3 = rect.height;
                num4 = rect.x - r1.x;
                num5 = rect.y - r1.y;
            }
            float num11 = 0.0f;
            float num12 = 0.0f;
            switch (num1)
            {
                case 1:
                    num10 = -1;
                    num12 += num3;
                    break;
                case 2:
                    num11 += num2;
                    num8 = -1f;
                    if (this.isClip)
                    {
                        if (x1 > x)
                            num9 = 0.0f - num4;
                        else if (x1 + width < x + w)
                            num9 = (float)-(x1 + width - x - w);
                        break;
                    }
                    break;
                case 3:
                    num10 = -1;
                    num12 += num3;
                    num8 = -1f;
                    num11 += num2;
                    break;
            }
            int num13 = 0;
            int num14 = 0;
            if (num1 == 5 || num1 == 6 || num1 == 4 || num1 == 7 || num1 == 0 || num1 == 2)
            {
                this.matrixBackup = GUI.matrix;
                this.size = new Vector2((float)w, (float)h);
                this.relativePosition = new Vector2((float)x, (float)y);
                this.UpdatePos(3);
                switch (num1)
                {
                    case 5:
                        this.size = new Vector2((float)w, (float)h);
                        this.UpdatePos(3);
                        break;
                    case 6:
                        this.UpdatePos(3);
                        break;
                }
                switch (num1)
                {
                    case 0:
                    case 2:
                    case 5:
                        GUIUtility.RotateAroundPivot(angle, this.pivot);
                        break;
                    case 4:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num11 += num2;
                        num8 = -1f;
                        if (this.isClip)
                        {
                            if (x1 > x)
                                num9 = 0.0f - num4;
                            else if (x1 + width < x + w)
                                num9 = (float)-(x1 + width - x - w);
                            break;
                        }
                        break;
                    case 6:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        break;
                    case 7:
                        GUIUtility.RotateAroundPivot(270f, this.pivot);
                        num10 = -1;
                        num12 += num3;
                        break;
                }
            }
            Graphics.DrawTexture(new Rect((float)x + num4 + num11 + (float)num13, (float)y + num5 + (float)num14 + num12, num2 * num8, num3 * (float)num10), (Texture)image.texture, new Rect((x0 + num4 + num9) / (float)image.texture.width, (float)((double)image.texture.height - (double)num3 - ((double)y0 + (double)num5)) / (float)image.texture.height, num2 / (float)image.texture.width, num3 / (float)image.texture.height), 0, 0, 0, 0);
            if (num1 != 5 && num1 != 6 && num1 != 4 && num1 != 7 && num1 != 0 && num1 != 2)
                return;
            GUI.matrix = this.matrixBackup;
        }

        public void drawImage(Image image, int x, int y, int anchor)
        {
            if (image == null)
                return;
            this.drawRegion(image, 0, 0, MyGraphics.getImageWidth(image), MyGraphics.getImageHeight(image), 0, x, y, anchor);
        }

        public void drawImage(int x, int y, Image image, int transform, int anchor)
        {
            if (image == null)
                return;
            this.drawRegion(image, 0, 0, MyGraphics.getImageWidth(image), MyGraphics.getImageHeight(image), transform, x, y, anchor);
        }

        public void drawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            this.drawRegion(image, 0, 0, MyGraphics.getImageWidth(image), MyGraphics.getImageHeight(image), 0, x, y, MyGraphics.TOP | MyGraphics.LEFT);
        }

        public void reset()
        {
            this.isClip = false;
            this.isTranslate = false;
            this.translateX = 0;
            this.translateY = 0;
        }

        public Rect intersectRect(Rect r1, Rect r2)
        {
            float x1 = r1.x;
            float y1 = r1.y;
            float x2 = r2.x;
            float y2 = r2.y;
            float num1 = x1 + r1.width;
            float num2 = y1 + r1.height;
            float num3 = x2 + r2.width;
            float num4 = y2 + r2.height;
            if ((double)x1 < (double)x2)
                x1 = x2;
            if ((double)y1 < (double)y2)
                y1 = y2;
            if ((double)num1 > (double)num3)
                num1 = num3;
            if ((double)num2 > (double)num4)
                num2 = num4;
            float width = num1 - x1;
            float height = num2 - y1;
            if ((double)width < -30000.0)
                width = -30000f;
            if ((double)height < -30000.0)
                height = -30000f;
            return new Rect(x1, y1, (float)(int)width, (float)(int)height);
        }

        public void drawImageScale(Image image, int x, int y, int w, int h, int tranform)
        {
            GUI.color = Color.red;
            if (image == null)
                return;
            Graphics.DrawTexture(new Rect((float)(x + this.translateX), (float)(y + this.translateY), tranform != 0 ? (float)-w : (float)w, (float)h), (Texture)image.texture);
        }

        public void drawImageSimple(Image image, int x, int y)
        {
            if (image == null)
                return;
            Graphics.DrawTexture(new Rect((float)x, (float)y, (float)image.w, (float)image.h), (Texture)image.texture);
        }

        public static int getImageWidth(Image image) => image.getWidth();

        public static int getImageHeight(Image image) => image.getHeight();

        public void CreateLineMaterial()
        {
            if ((bool)(Object)this.lineMaterial)
                return;
            this.lineMaterial = new Material(Shader.Find("Specular"));
            this.lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            this.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        }
    }
}
