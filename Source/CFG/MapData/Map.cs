using UnityEngine;

namespace Source.CFG.MapData
{
    public class Map
    {
        private readonly Tile[,] tiles = new Tile[MapVars.width, MapVars.height];
        
        public Map()
        {
            InitTiles();
        }

        private void InitTiles()
        {
            // Bottom Left Corner
            tiles[0, 0] = new Tile(0, 0, new Wall(), new Wall());
            
            // Bottom Row
            for (int i = 1; i < MapVars.width; i++)
            {
                tiles[i, 0] = new Tile(i, 0, tiles[i-1, 0].right, new Wall());
            }
            // Left Column
            for (int j = 1; j < MapVars.height; j++)
            {
                tiles[0, j] = new Tile(0, j, new Wall(), tiles[0, j-1].up);
            }
            
            // Fill in the rest.
            for (int j = 1; j < MapVars.height; j++)
            {
                for (int i = 1; i < MapVars.width; i++)
                {
                    tiles[i, j] = new Tile(i, j, tiles[i-1, j].right, tiles[i, j-1].up);
                }
            }
        }
        
        public Tile GetTileAt(Vector2 pos)
        {
            return tiles[(int)pos.x, (int)pos.y];
        }

        public Tile GetTileAt(int x, int y)
        {
            return tiles[x, y];
        }
    }
}