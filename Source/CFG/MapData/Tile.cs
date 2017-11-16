namespace Source.CFG.MapData
{
    public class Tile
    {
        public bool isRoom { get; set; }

        public Wall left { get; private set; }
        public Wall right { get; private set; }
        public Wall up { get; private set; }
        public Wall down { get; private set; }

        public Tile(Wall left, Wall down)
        {
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