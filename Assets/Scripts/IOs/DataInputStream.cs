using System;
using System.Threading;
using Assets.Scripts.Commons;
using UnityEngine;

namespace Assets.Scripts.IOs
{
    // Token: 0x02000041 RID: 65
    public class DataInputStream
    {
        // Token: 0x0600019F RID: 415 RVA: 0x00019C7C File Offset: 0x00017E7C
        public DataInputStream(string filename)
        {
            TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
            this.r = new MyReader(PlayerUtil.convertToSbyteArray(textAsset.bytes));
        }

        // Token: 0x060001A0 RID: 416 RVA: 0x00002D1A File Offset: 0x00000F1A
        public DataInputStream(sbyte[] data)
        {
            this.r = new MyReader(data);
        }

        // Token: 0x060001A1 RID: 417 RVA: 0x00019CC0 File Offset: 0x00017EC0
        public static void update()
        {
            bool flag = DataInputStream.status == 2;
            if (flag)
            {
                DataInputStream.status = 1;
                DataInputStream.istemp = DataInputStream.__getResourceAsStream(DataInputStream.filenametemp);
                DataInputStream.status = 0;
            }
        }

        // Token: 0x060001A2 RID: 418 RVA: 0x00019CF8 File Offset: 0x00017EF8
        public static DataInputStream getResourceAsStream(string filename)
        {
            return DataInputStream.__getResourceAsStream(filename);
        }

        // Token: 0x060001A3 RID: 419 RVA: 0x00019D10 File Offset: 0x00017F10
        private static DataInputStream _getResourceAsStream(string filename)
        {
            bool flag = DataInputStream.status != 0;
            if (flag)
            {
                for (int i = 0; i < 500; i++)
                {
                    Thread.Sleep(5);
                    bool flag2 = DataInputStream.status == 0;
                    if (flag2)
                    {
                        break;
                    }
                }
                bool flag3 = DataInputStream.status != 0;
                if (flag3)
                {
                    Debug.LogError("CANNOT GET INPUTSTREAM " + filename + " WHEN GETTING " + DataInputStream.filenametemp);
                    return null;
                }
            }
            DataInputStream.istemp = null;
            DataInputStream.filenametemp = filename;
            DataInputStream.status = 2;
            int j;
            for (j = 0; j < 500; j++)
            {
                Thread.Sleep(5);
                bool flag4 = DataInputStream.status == 0;
                if (flag4)
                {
                    break;
                }
            }
            bool flag5 = j == 500;
            DataInputStream result;
            if (flag5)
            {
                Debug.LogError("TOO LONG FOR CREATE INPUTSTREAM " + filename);
                DataInputStream.status = 0;
                result = null;
            }
            else
            {
                result = DataInputStream.istemp;
            }
            return result;
        }

        // Token: 0x060001A4 RID: 420 RVA: 0x00019E04 File Offset: 0x00018004
        private static DataInputStream __getResourceAsStream(string filename)
        {
            DataInputStream result;
            try
            {
                result = new DataInputStream(filename);
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        // Token: 0x060001A5 RID: 421 RVA: 0x00019E34 File Offset: 0x00018034
        public short readShort()
        {
            return this.r.readShort();
        }

        // Token: 0x060001A6 RID: 422 RVA: 0x00019E54 File Offset: 0x00018054
        public int readInt()
        {
            return this.r.readInt();
        }

        // Token: 0x060001A7 RID: 423 RVA: 0x00019E74 File Offset: 0x00018074
        public int read()
        {
            return (int)this.r.readUnsignedByte();
        }

        // Token: 0x060001A8 RID: 424 RVA: 0x00002D30 File Offset: 0x00000F30
        public void read(ref sbyte[] data)
        {
            this.r.read(ref data);
        }

        // Token: 0x060001A9 RID: 425 RVA: 0x00002D40 File Offset: 0x00000F40
        public void close()
        {
            this.r.Close();
        }

        // Token: 0x060001AA RID: 426 RVA: 0x00002D40 File Offset: 0x00000F40
        public void Close()
        {
            this.r.Close();
        }

        // Token: 0x060001AB RID: 427 RVA: 0x00019E94 File Offset: 0x00018094
        public string readUTF()
        {
            return this.r.readUTF();
        }

        // Token: 0x060001AC RID: 428 RVA: 0x00019EB4 File Offset: 0x000180B4
        public sbyte readByte()
        {
            return this.r.readByte();
        }

        // Token: 0x060001AD RID: 429 RVA: 0x00019ED4 File Offset: 0x000180D4
        public long readLong()
        {
            return this.r.readLong();
        }

        // Token: 0x060001AE RID: 430 RVA: 0x00019EF4 File Offset: 0x000180F4
        public bool readBoolean()
        {
            return this.r.readBoolean();
        }

        // Token: 0x060001AF RID: 431 RVA: 0x00019F14 File Offset: 0x00018114
        public int readUnsignedByte()
        {
            return (int)((byte)this.r.readByte());
        }

        // Token: 0x060001B0 RID: 432 RVA: 0x00019F34 File Offset: 0x00018134
        public int readUnsignedShort()
        {
            return (int)this.r.readUnsignedShort();
        }

        // Token: 0x060001B1 RID: 433 RVA: 0x00002D30 File Offset: 0x00000F30
        public void readFully(ref sbyte[] data)
        {
            this.r.read(ref data);
        }

        // Token: 0x060001B2 RID: 434 RVA: 0x00019F54 File Offset: 0x00018154
        public int available()
        {
            return this.r.available();
        }

        // Token: 0x060001B3 RID: 435 RVA: 0x000028EF File Offset: 0x00000AEF
        internal void read(ref sbyte[] byteData, int p, int size)
        {
            throw new NotImplementedException();
        }

        // Token: 0x0400027F RID: 639
        private const int INTERVAL = 5;

        private const int MAXTIME = 500;

        // Token: 0x04000281 RID: 641
        public MyReader r;

        // Token: 0x04000282 RID: 642
        public static DataInputStream istemp;

        // Token: 0x04000283 RID: 643
        private static int status;

        // Token: 0x04000284 RID: 644
        private static string filenametemp;
    }
}
