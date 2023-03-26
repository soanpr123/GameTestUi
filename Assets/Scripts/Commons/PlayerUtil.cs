using System;
// using Assets.Scripts.IOs;
using UnityEngine;

namespace Assets.Scripts.Commons
{
    // Token: 0x0200005A RID: 90
    public class PlayerUtil
    {
        // Token: 0x060002F8 RID: 760 RVA: 0x000254BC File Offset: 0x000236BC
        static PlayerUtil()
        {
            PlayerUtil.tanz = new int[91];
            for (int i = 0; i <= 90; i++)
            {
                PlayerUtil.cosz[i] = PlayerUtil.sinz[90 - i];
                bool flag = PlayerUtil.cosz[i] == 0;
                if (flag)
                {
                    PlayerUtil.tanz[i] = int.MaxValue;
                }
                else
                {
                    PlayerUtil.tanz[i] = ((int)PlayerUtil.sinz[i] << 10) / (int)PlayerUtil.cosz[i];
                }
            }
        }
        public static bool inRect(int x1, int y1, int width, int height, int x2, int y2)
        {
            return x2 >= x1 && x2 <= x1 + width && y2 >= y1 && y2 <= y1 + height;
        }
        public static int abs(int i)
        {
            return (i <= 0) ? (-i) : i;
        }

        // Token: 0x060002F9 RID: 761 RVA: 0x00025564 File Offset: 0x00023764
        public static string loadJson(string filename)
        {
            return ((TextAsset)Resources.Load(filename, typeof(TextAsset))).text;
        }

        // Token: 0x060002FA RID: 762 RVA: 0x0002559C File Offset: 0x0002379C
        public static long currentTimeMillis()
        {
            DateTime dateTime = new DateTime(2000, 7, 17, 1, 17, 17, DateTimeKind.Utc);
            return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000L;
        }

        // Token: 0x060002FB RID: 763 RVA: 0x000255E0 File Offset: 0x000237E0
        public static sbyte[] convertToSbyteArray(byte[] scr)
        {
            sbyte[] array = new sbyte[scr.Length];
            for (int i = 0; i < scr.Length; i++)
            {
                array[i] = (sbyte)scr[i];
            }
            return array;
        }

        // Token: 0x060002FC RID: 764 RVA: 0x00025618 File Offset: 0x00023818
        public static byte[] convertToByteArray(sbyte[] data)
        {
            byte[] array = new byte[data.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (byte)data[i];
            }
            return array;
        }
        public static uint convertToUint(string data)
        {
            uint num = 0;
            if (data != null)
            {
                num = 2166136261U;
                for (int i = 0; i < data.Length; i++)
                {
                    num = ((uint)data[i] ^ num) * 16777619U;
                }
            }

            return num;
        }

        public static char[] convertToCharArray(sbyte[] data)
        {
            char[] array = new char[data.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (char)data[i];
            }
            return array;
        }

        // Token: 0x060002FE RID: 766 RVA: 0x00025688 File Offset: 0x00023888
        public static int distance(int x1, int y1, int x2, int y2)
        {
            return PlayerUtil.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        // Token: 0x060002FF RID: 767 RVA: 0x000256B0 File Offset: 0x000238B0
        public static int sqrt(int a)
        {
            bool flag = a <= 0;
            int result;
            if (flag)
            {
                result = 0;
            }
            else
            {
                int num = (a + 1) / 2;
                int num2;
                do
                {
                    num2 = num;
                    num = num / 2 + a / (2 * num);
                }
                while (Math.Abs(num2 - num) > 1);
                result = num;
            }
            return result;
        }

        // Token: 0x06000300 RID: 768 RVA: 0x000256F8 File Offset: 0x000238F8
        public static string formatNumber(long number)
        {
            string str = string.Empty;
            string text = string.Empty;
            str = string.Empty;
            bool flag = number >= 1000000000L;
            string result;
            if (flag)
            {
                text = "Tỉ";
                long num = number % 1000000000L / 100000000L;
                number /= 1000000000L;
                str = number.ToString() + string.Empty;
                bool flag2 = num > 0L;
                if (flag2)
                {
                    result = str + "," + num.ToString() + text;
                }
                else
                {
                    result = str + text;
                }
            }
            else
            {
                bool flag3 = number >= 1000000L;
                if (flag3)
                {
                    text = "Tr";
                    long num2 = number % 1000000L / 100000L;
                    number /= 1000000L;
                    str = number.ToString() + string.Empty;
                    bool flag4 = num2 > 0L;
                    if (flag4)
                    {
                        result = str + "," + num2.ToString() + text;
                    }
                    else
                    {
                        result = str + text;
                    }
                }
                else
                {
                    result = number.ToString() + string.Empty;
                }
            }
            return result;
        }

        // Token: 0x06000301 RID: 769 RVA: 0x0002581C File Offset: 0x00023A1C
        public static int random(int start, int end)
        {
            return PlayerUtil.r.Next(start, end + 1);
        }

        // Token: 0x06000302 RID: 770 RVA: 0x0002583C File Offset: 0x00023A3C
        // public static sbyte[] readByteArray(MyReader dos)
        // {
        //     try
        //     {
        //         sbyte[] result = new sbyte[dos.readInt()];
        //         dos.read(ref result);
        //         return result;
        //     }
        //     catch (Exception)
        //     {
        //         Debug.Log("LOI DOC readByteArray dos");
        //     }
        //     return null;
        // }

        // // Token: 0x06000303 RID: 771 RVA: 0x0002588C File Offset: 0x00023A8C
        // public static sbyte[] readByteArray(Message msg)
        // {
        //     try
        //     {
        //         sbyte[] result = new sbyte[msg.reader().readInt()];
        //         msg.reader().read(ref result);
        //         return result;
        //     }
        //     catch (Exception)
        //     {
        //         Debug.Log("LOI DOC readByteArray NINJAUTIL");
        //     }
        //     return null;
        // }

        // Token: 0x06000304 RID: 772 RVA: 0x000258E4 File Offset: 0x00023AE4
        public static int atan(int a)
        {
            for (int i = 0; i <= 90; i++)
            {
                bool flag = PlayerUtil.tanz[i] >= a;
                if (flag)
                {
                    return i;
                }
            }
            return 0;
        }

        // Token: 0x06000305 RID: 773 RVA: 0x00025924 File Offset: 0x00023B24
        public static int angle(int dx, int dy)
        {
            bool flag = dx != 0;
            int num;
            if (flag)
            {
                num = PlayerUtil.atan(Math.Abs((dy << 10) / dx));
                bool flag2 = dy >= 0 && dx < 0;
                if (flag2)
                {
                    num = 180 - num;
                }
                bool flag3 = dy < 0 && dx < 0;
                if (flag3)
                {
                    num = 180 + num;
                }
                bool flag4 = dy < 0 && dx >= 0;
                if (flag4)
                {
                    num = 360 - num;
                }
            }
            else
            {
                num = ((dy <= 0) ? 270 : 90);
            }
            return num;
        }

        // Token: 0x06000306 RID: 774 RVA: 0x000259B8 File Offset: 0x00023BB8
        public static int sin(int a)
        {
            a = PlayerUtil.fixangle(a);
            bool flag = a >= 0 && a < 90;
            int result;
            if (flag)
            {
                result = (int)PlayerUtil.sinz[a];
            }
            else
            {
                bool flag2 = a >= 90 && a < 180;
                if (flag2)
                {
                    result = (int)PlayerUtil.sinz[180 - a];
                }
                else
                {
                    bool flag3 = a >= 180 && a < 270;
                    if (flag3)
                    {
                        result = (int)(-(int)PlayerUtil.sinz[a - 180]);
                    }
                    else
                    {
                        result = (int)(-(int)PlayerUtil.sinz[360 - a]);
                    }
                }
            }
            return result;
        }

        // Token: 0x06000307 RID: 775 RVA: 0x00025A4C File Offset: 0x00023C4C
        public static int cos(int a)
        {
            a = PlayerUtil.fixangle(a);
            bool flag = a >= 0 && a < 90;
            int result;
            if (flag)
            {
                result = (int)PlayerUtil.cosz[a];
            }
            else
            {
                bool flag2 = a >= 90 && a < 180;
                if (flag2)
                {
                    result = (int)(-(int)PlayerUtil.cosz[180 - a]);
                }
                else
                {
                    bool flag3 = a >= 180 && a < 270;
                    if (flag3)
                    {
                        result = (int)(-(int)PlayerUtil.cosz[a - 180]);
                    }
                    else
                    {
                        result = (int)PlayerUtil.cosz[360 - a];
                    }
                }
            }
            return result;
        }

        // Token: 0x06000308 RID: 776 RVA: 0x00025AE0 File Offset: 0x00023CE0
        public static int fixangle(int angle)
        {
            bool flag = angle >= 360;
            if (flag)
            {
                angle -= 360;
            }
            bool flag2 = angle < 0;
            if (flag2)
            {
                angle += 360;
            }
            return angle;
        }

        // Token: 0x06000309 RID: 777 RVA: 0x00025B20 File Offset: 0x00023D20
        public static string getMoneys(long m)
        {
            string text = string.Empty;
            long num = m / 1000L + 1L;
            int num2 = 0;
            while ((long)num2 < num)
            {
                bool flag = m >= 1000L;
                if (!flag)
                {
                    text = m.ToString() + text;
                    break;
                }
                long num3 = m % 1000L;
                text = ((num3 != 0L) ? ((num3 >= 10L) ? ((num3 >= 100L) ? ("." + num3.ToString() + text) : (".0" + num3.ToString() + text)) : (".00" + num3.ToString() + text)) : (".000" + text));
                m /= 1000L;
                num2++;
            }
            return text;
        }
        public const double PI = System.Math.PI;



        public static int min(int x, int y)
        {
            return (x >= y) ? y : x;
        }

        public static int max(int x, int y)
        {
            return (x <= y) ? y : x;
        }

        public static int pow(int data, int x)
        {
            int num = 1;
            for (int i = 0; i < x; i++)
            {
                num *= data;
            }
            return num;
        }
        // Token: 0x040003B2 RID: 946
        public static System.Random r = new System.Random();

        // Token: 0x040003B3 RID: 947
        private static int[] tanz;

        // Token: 0x040003B4 RID: 948
        private static short[] sinz = new short[]
        {
            0,
            18,
            36,
            54,
            71,
            89,
            107,
            125,
            143,
            160,
            178,
            195,
            213,
            230,
            248,
            265,
            282,
            299,
            316,
            333,
            350,
            367,
            384,
            400,
            416,
            433,
            449,
            465,
            481,
            496,
            512,
            527,
            543,
            558,
            573,
            587,
            602,
            616,
            630,
            644,
            658,
            672,
            685,
            698,
            711,
            724,
            737,
            749,
            761,
            773,
            784,
            796,
            807,
            818,
            828,
            839,
            849,
            859,
            868,
            878,
            887,
            896,
            904,
            912,
            920,
            928,
            935,
            943,
            949,
            956,
            962,
            968,
            974,
            979,
            984,
            989,
            994,
            998,
            1002,
            1005,
            1008,
            1011,
            1014,
            1016,
            1018,
            1020,
            1022,
            1023,
            1023,
            1024,
            1024
        };

        // Token: 0x040003B5 RID: 949
        private static short[] cosz = new short[91];
    }
}
