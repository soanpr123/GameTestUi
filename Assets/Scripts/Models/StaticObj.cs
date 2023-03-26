// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Models.StaticObj
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.GraphicCustoms;

namespace Assets.Scripts.Models
{
    public class StaticObj
    {
        public static int TOP_CENTER = MyGraphics.TOP | MyGraphics.HCENTER;
        public static int TOP_LEFT = MyGraphics.TOP | MyGraphics.LEFT;
        public static int TOP_RIGHT = MyGraphics.TOP | MyGraphics.RIGHT;
        public static int BOTTOM_HCENTER = MyGraphics.BOTTOM | MyGraphics.HCENTER;
        public static int BOTTOM_LEFT = MyGraphics.BOTTOM | MyGraphics.LEFT;
        public static int BOTTOM_RIGHT = MyGraphics.BOTTOM | MyGraphics.RIGHT;
        public static int VCENTER_HCENTER = MyGraphics.VCENTER | MyGraphics.HCENTER;
        public static int HCENTER_VCENTER = MyGraphics.HCENTER | MyGraphics.VCENTER;
        public static int VCENTER_LEFT = MyGraphics.VCENTER | MyGraphics.LEFT;
        public static int[] imageFly = new int[4]
        {
      347,
      348,
      349,
      350
        };
        public static int[] blindImageId = new int[3]
        {
      334,
      335,
      336
        };
    }
}
