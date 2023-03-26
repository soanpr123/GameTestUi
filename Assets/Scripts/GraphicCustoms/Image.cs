// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.GraphicCustoms.Image
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Commons;
using System;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.GraphicCustoms
{
    public class Image
    {
        public Texture2D texture = new Texture2D(1, 1);
        public static Image imgTemp;
        public static string filenametemp;
        public static byte[] datatemp;
        public static Image imgSrcTemp;
        public static int xtemp;
        public static int ytemp;
        public static int wtemp;
        public static int htemp;
        public static int transformtemp;
        public int w;
        public int h;
        public static int status;

        public static Image createEmptyImage() => Image.__createEmptyImage();

        public static Image createImage(string filename) => Image.__createImage(filename);

        public static Image createImage(byte[] imageData) => Image.__createImage(imageData);

        public static Image createImage(Image src, int x, int y, int w, int h, int transform) => Image.__createImage(src, x, y, w, h, transform);

        public static Image createImage(int w, int h) => Image.__createImage(w, h);

        public static Image createImage(Image img)
        {
            Image image = Image.createImage(img.w, img.h);
            image.texture = img.texture;
            image.texture.Apply();
            return image;
        }
       

        public static Image createImage(sbyte[] imageData, int offset, int lenght)
        {
            if (offset + lenght > imageData.Length)
                return (Image)null;
            byte[] imageData1 = new byte[lenght];
            for (int index = 0; index < lenght; ++index)
                imageData1[index] = Image.convertSbyteToByte(imageData[index + offset]);
            return Image.createImage(imageData1);
        }

        public static byte convertSbyteToByte(sbyte var) => var > (sbyte)0 ? (byte)var : (byte)((uint)var + 256U);

        public static byte[] convertArrSbyteToArrByte(sbyte[] var)
        {
            byte[] arrByte = new byte[var.Length];
            for (int index = 0; index < var.Length; ++index)
                arrByte[index] = var[index] <= (sbyte)0 ? (byte)((uint)var[index] + 256U) : (byte)var[index];
            return arrByte;
        }

        public static Image createRGBImage(int[] rbg, int w, int h, bool bl)
        {
            Image image = Image.createImage(w, h);
            Color[] colors = new Color[rbg.Length];
            for (int index = 0; index < colors.Length; ++index)
                colors[index] = Image.setColorFromRBG(rbg[index]);
            image.texture.SetPixels(0, 0, w, h, colors);
            image.texture.Apply();
            return image;
        }

        public static Color setColorFromRBG(int rgb)
        {
            int num1 = rgb & (int)byte.MaxValue;
            int num2 = rgb >> 8 & (int)byte.MaxValue;
            int num3 = rgb >> 16 & (int)byte.MaxValue;
            float b = (float)num1 / 256f;
            float g = (float)num2 / 256f;
            return new Color((float)num3 / 256f, g, b);
        }

        public static void update()
        {
            switch (Image.status)
            {
                case 2:
                    Image.status = 1;
                    Image.imgTemp = Image.__createEmptyImage();
                    Image.status = 0;
                    break;
                case 3:
                    Image.status = 1;
                    Image.imgTemp = Image.__createImage(Image.filenametemp);
                    Image.status = 0;
                    break;
                case 4:
                    Image.status = 1;
                    Image.imgTemp = Image.__createImage(Image.datatemp);
                    Image.status = 0;
                    break;
                case 5:
                    Image.status = 1;
                    Image.imgTemp = Image.__createImage(Image.imgSrcTemp, Image.xtemp, Image.ytemp, Image.wtemp, Image.htemp, Image.transformtemp);
                    Image.status = 0;
                    break;
                case 6:
                    Image.status = 1;
                    Image.imgTemp = Image.__createImage(Image.wtemp, Image.htemp);
                    Image.status = 0;
                    break;
            }
        }

        private static Image _createEmptyImage()
        {
            if (Image.status != 0)
                return (Image)null;
            Image.imgTemp = (Image)null;
            Image.status = 2;
            int num;
            for (num = 0; num < 500; ++num)
            {
                Thread.Sleep(5);
                if (Image.status == 0)
                    break;
            }
            if (num == 500)
                Image.status = 0;
            return Image.imgTemp;
        }

        private static Image _createImage(string filename)
        {
            if (Image.status != 0)
                return (Image)null;
            Image.imgTemp = (Image)null;
            Image.filenametemp = filename;
            Image.status = 3;
            int num;
            for (num = 0; num < 500; ++num)
            {
                Thread.Sleep(5);
                if (Image.status == 0)
                    break;
            }
            if (num == 500)
                Image.status = 0;
            return Image.imgTemp;
        }

        private static Image _createImage(byte[] imageData)
        {
            if (Image.status != 0)
                return (Image)null;
            Image.imgTemp = (Image)null;
            Image.datatemp = imageData;
            Image.status = 4;
            int num;
            for (num = 0; num < 500; ++num)
            {
                Thread.Sleep(5);
                if (Image.status == 0)
                    break;
            }
            if (num == 500)
                Image.status = 0;
            return Image.imgTemp;
        }

        private static Image _createImage(Image src, int x, int y, int w, int h, int transform)
        {
            if (Image.status != 0)
                return (Image)null;
            Image.imgTemp = (Image)null;
            Image.imgSrcTemp = src;
            Image.xtemp = x;
            Image.ytemp = y;
            Image.wtemp = w;
            Image.htemp = h;
            Image.transformtemp = transform;
            Image.status = 5;
            int num;
            for (num = 0; num < 500; ++num)
            {
                Thread.Sleep(5);
                if (Image.status == 0)
                    break;
            }
            if (num == 500)
                Image.status = 0;
            return Image.imgTemp;
        }

        private static Image _createImage(int w, int h)
        {
            if (Image.status != 0)
                return (Image)null;
            Image.imgTemp = (Image)null;
            Image.wtemp = w;
            Image.htemp = h;
            Image.status = 6;
            int num;
            for (num = 0; num < 500; ++num)
            {
                Thread.Sleep(5);
                if (Image.status == 0)
                    break;
            }
            if (num == 500)
                Image.status = 0;
            return Image.imgTemp;
        }

        public static byte[] loadData(string filename)
        {
            Image image = new Image();
            TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
            if ((UnityEngine.Object)textAsset == (UnityEngine.Object)null || textAsset.bytes == null || textAsset.bytes.Length == 0)
                throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
            Debug.LogError((object)("CHIEU DAI MANG BYTE IMAGE CREAT = " + PlayerUtil.convertToSbyteArray(textAsset.bytes).Length.ToString()));
            return textAsset.bytes;
        }

        private static Image __createImage(string filename)
        {
            Image img = new Image();
            Texture2D texture2D = Resources.Load(filename) as Texture2D;
            img.texture = !((UnityEngine.Object)texture2D == (UnityEngine.Object)null) ? texture2D : throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
            img.w = img.texture.width;
            img.h = img.texture.height;
            Image.setTextureQuality(img);
            return img;
        }

        public static Image __createImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return (Image)null;
            Image img = new Image();
            try
            {
                img.texture.LoadImage(imageData);
                img.w = img.texture.width;
                img.h = img.texture.height;
                Image.setTextureQuality(img);
                return img;
            }
            catch (Exception ex)
            {
                return img;
            }
        }

        private static Image __createImage(Image src, int x, int y, int w, int h, int transform)
        {
            Image img = new Image();
            img.texture = new Texture2D(w, h);
            y = src.texture.height - y - h;
            for (int x1 = 0; x1 < w; ++x1)
            {
                for (int y1 = 0; y1 < h; ++y1)
                {
                    int num1 = x1;
                    if (transform == 2)
                        num1 = w - x1;
                    int num2 = y1;
                    img.texture.SetPixel(x1, y1, src.texture.GetPixel(x + num1, y + num2));
                }
            }
            img.texture.Apply();
            img.w = img.texture.width;
            img.h = img.texture.height;
            Image.setTextureQuality(img);
            return img;
        }

        private static Image __createEmptyImage() => new Image();

        public static Image __createImage(int w, int h)
        {
            Image img = new Image()
            {
                texture = new Texture2D(w, h, TextureFormat.RGBA32, false)
            };
            Image.setTextureQuality(img);
            img.w = w;
            img.h = h;
            img.texture.Apply();
            return img;
        }

        public static int getImageWidth(Image image) => image.getWidth();

        public static int getImageHeight(Image image) => image.getHeight();

        public int getWidth() => this.w;

        public int getHeight() => this.h;

        private static void setTextureQuality(Image img) => Image.setTextureQuality(img.texture);

        public static void setTextureQuality(Texture2D texture)
        {
            texture.anisoLevel = 0;
            texture.filterMode = FilterMode.Point;
            texture.mipMapBias = 0.0f;
            texture.wrapMode = TextureWrapMode.Clamp;
        }
    }
}
