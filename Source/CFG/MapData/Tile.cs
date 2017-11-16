namespace Source.CFG.MapData
{
    public class Tile
    {
        private int x;
        private int y;
        public bool isRoom { get; set; }

        public Wall left { get; private set; }
        public Wall right { get; private set; }
        public Wall up { get; private set; }
        public Wall down { get; private set; }

        public Tile(int x, int y, Wall left, Wall down)
        {
            this.x = x;
            this.y = y;
            isRoom = false;

            this.left = left;
            this.down = down;
            right = new Wall();
            up = new Wall();
        }

        public Wall GetWall(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return up;
                case Direction.Right:
                    return right;
                case Direction.Down:
                    return down;
                default:
                    return left;
            }
        }
    }
}