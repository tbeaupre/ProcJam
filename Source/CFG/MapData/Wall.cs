namespace Source.CFG.MapData
{
    public class Wall
    {
        public int Pass { get; private set; }

        public Wall()
        {
            Pass = -1;
        }

        public void SetPass(int newPass)
        {
            if (newPass > Pass)
                Pass = newPass;
        }
    }
}