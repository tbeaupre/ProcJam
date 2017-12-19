using UnityEngine;

namespace Source
{
    public enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    public static class DirectionHelper
    {
        public static Direction Right(Direction currentDirection)
        {
            int current = (int)currentDirection;
            int next = (current + 1) % 4;
            return (Direction)next;
        }
        
        public static Direction Left(Direction currentDirection)
        {
            int current = (int)currentDirection;
            int next = (current + 3) % 4;
            return (Direction)next;
        }
    }
}