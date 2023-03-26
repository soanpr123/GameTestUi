// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Models.MovePoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

namespace Assets.Scripts.Models
{
    public class MovePoint
    {
        public int xEnd;
        public int yEnd;
        public int dir;
        public int cvx;
        public int cvy;
        public int status;

        public MovePoint(int xEnd, int yEnd, int act, int dir)
        {
            this.xEnd = xEnd;
            this.yEnd = yEnd;
            this.dir = dir;
            this.status = act;
        }

        public MovePoint(int xEnd, int yEnd)
        {
            this.xEnd = xEnd;
            this.yEnd = yEnd;
        }
    }
}
