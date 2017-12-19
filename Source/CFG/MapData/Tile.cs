namespace Source.CFG.MapData
{
    public class Tile
    {
        public bool IsRoom { get; set; }

        public Wall left;
        public Wall right;
        public Wall up;
        public Wall down;
        
        private Tile()
        {
            IsRoom = false;

            left = new Wall();
            down = new Wall();
            right = new Wall();
            up = new Wall();
        }

        public static Tile CreateFirstTile()
        {
            return new Tile();
        }

        public static Tile CreateTile(ref Wall newLeft, ref Wall newDown)
        {
            return new Tile {left = newLeft, down = newDown};
        }
        
        public static Tile CreateBottomTile(ref Wall newLeft)
        {
            return new Tile {left = newLeft};
        }

        public static Tile CreateLeftTile(ref Wall newDown)
        {
            return new Tile {down = newDown};
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