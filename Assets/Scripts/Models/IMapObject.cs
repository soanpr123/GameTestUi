// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Models.IMapObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 705B5AB7-C97A-43C5-B3FB-6A8B004045E9
// Assembly location: C:\Users\luuvi\Downloads\RongThanOnl\Rong Than Online_Data\Managed\Assembly-CSharp.dll

namespace Assets.Scripts.Models
{
    public interface IMapObject
    {
        int getX();

        int getY();

        int getW();

        int getH();

        int getDir();

        void stopMoving();

        bool isInvisible();
    }
}
