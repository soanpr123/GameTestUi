using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assets.Scripts.Models
{
    public class Frame
    {
        public Dictionary<int, PartImage> icons;
        public long delay;


        [JsonProperty("is_loop")]
        public bool isLoop;
    }



    public class PartImage
    {

        public int id;


        public int dx;

        public int dy;
    }
}

