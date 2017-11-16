namespace Source.CFG.MapData
{
    public class Wall
    {
        public int pass { get; private set; }

        public Wall()
        {
            pass = -1;
        }

        public void SetPass(int newPass)
        {
            if (newPass > pass)
                pass = newPass;
        }
    }
}