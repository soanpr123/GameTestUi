
namespace Assets.Scripts.Models
{
    public abstract class MapObject
    {
        public int id;
        public string name;
        public int gender = -1;
        public long hp;
        public long mp;
        public long maxHp;
        public long maxMp;
        public int speed;
        public int dir = 1;
        public string status;
        public int w;
        public int h;
        public int x;
        public int y;
        public int head;
        public int body;
        public int leg;
        public int weapon = 4;
        public int accessory = 3;
        public int frame;
        public int xSd;
        public int ySd;
        public bool isDie;
        public int typePk;
        public long lastTimeFrame;
    }
}
