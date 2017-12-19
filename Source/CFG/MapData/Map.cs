using UnityEngine;

namespace Source.CFG.MapData
{
    public class Map
    {
        private readonly Tile[,] tiles;
        
        public Map()
        {
            tiles = new Tile[MapVars.width, MapVars.height];
            InitTiles();
        }

        private void InitTiles()
        {
            // Bottom Left Corner
            tiles[0, 0] = Tile.CreateFirstTile();
            
            // Bottom Row
            for (int i = 1; i < MapVars.width; i++)
            {
                tiles[i, 0] = Tile.CreateBottomTile(ref tiles[i-1, 0].right);
            }
            // Left Column
            for (int j = 1; j < MapVars.height; j++)
            {
                tiles[0, j] = Tile.CreateLeftTile(ref tiles[0, j-1].up);
            }
            
            // Fill in the rest.
            for (int j = 1; j < MapVars.height; j++)
            {
                for (int i = 1; i < MapVars.width; i++)
                {
                    tiles[i, j] = Tile.CreateTile(ref tiles[i-1, j].right, ref tiles[i, j-1].up);
                }
            }
        }

        public Tile GetTileAt(int x, int y)
        {
            return tiles[x, y];
        }
    }
}