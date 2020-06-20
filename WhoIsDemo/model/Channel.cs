namespace WhoIsDemo.model
{
    public class Channel
    {
        public int id { get; set; }
        public int task { get; set; } // 1 enroll 0 entry control
        public int flow { get; set; } // 0 play 1 pausa
        public int loop { get; set; } // 0 run 1 quit
        
    }
}
