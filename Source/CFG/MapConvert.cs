﻿using Source.CFG.MapData;

namespace Source.CFG
{
    public static class MapConvert
    {
        public static Map ConvertMap(Generator generator, int passLevel)
        {
            Map map = new Map();

            Direction direction = Direction.Up;
            int x = (int)generator.start.x;
            int y = (int)generator.start.y;
            
            map.GetTileAt(x, y).isRoom = true;
            foreach (char c in generator.grammar.current)
            {
                switch (c)
                {
                    case 'F':
                        map.GetTileAt(x, y).GetWall(direction).SetPass(passLevel);
                        MoveInDirection(ref x, ref y, direction);
                        map.GetTileAt(x, y).isRoom = true;
                        break;
                    case 'L':
                        direction = DirectionHelper.Left(direction);
                        break;
                    case 'R':
                        direction = DirectionHelper.Right(direction);
                        break;
                }
            }

            return map;
        }

        private static void MoveInDirection(ref int x, ref int y, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    y += 1;
                    break;
                case Direction.Right:
                    x += 1;
                    break;
                case Direction.Down:
                    y -= 1;
                    break;
                case Direction.Left:
                    x -= 1;
                    break;
            }
        }
    }
}