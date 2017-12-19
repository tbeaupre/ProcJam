using System.Collections.Generic;
using Source.CFG.MapData;
using UnityEngine;

namespace Source.CFG
{
    public class DrawMap : MonoBehaviour
    {
        public GameObject emptyTilePrefab;
        public GameObject roomTilePrefab;
        public GameObject wallPrefab;
        private float tileSize;
        private List<GameObject> drawn;

        private Generator generator;
        
        void Start()
        {
            drawn = new List<GameObject>();
            tileSize = emptyTilePrefab.GetComponent<SpriteRenderer>().sprite.rect.width + 1;
            Debug.Log(tileSize);
            generator = new Generator();
            Draw(MapConvert.ConvertMap(generator, 0));
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                generator.Grammar.Iterate();
                
                // Clean up the product.
                generator.CleanGrammar.Current = generator.Grammar.Current;
                while (generator.CleanGrammar.Current != generator.CleanGrammar.Iterate()) {}
                generator.Grammar.Current = generator.CleanGrammar.Current;
                
                Draw(MapConvert.ConvertMap(generator, 0));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Creating new generator.");
                generator = new Generator();
                Draw(MapConvert.ConvertMap(generator, 0));
            }
        }
        
        private void Draw(Map map)
        {
            Clear();
			Debug.Log(generator.Grammar.Current);
            for (int j = 0; j < MapVars.height; j++)
            {
                for (int i = 0; i < MapVars.width; i++)
                {
                    DrawTile(map.GetTileAt(i, j), i, j);
                }
            }
        }

        private void Clear()
        {
            foreach (GameObject obj in drawn)
            {
                Destroy(obj);
            }
            drawn.Clear();
        }

        private void DrawTile(Tile tile, int x, int y)
        {
            if (tile.IsRoom)
            {
                drawn.Add(Instantiate(roomTilePrefab, new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity));
            }

            if (x % 2 == 0)
            {
                if (tile.left.Pass == 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize - 1, y * tileSize, 0), Quaternion.identity));
                }
                if (tile.right.Pass == 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize + 1, y * tileSize, 0), Quaternion.Euler(0, 0, 180)));
                }
            }
            if (y % 2 == 0)
            {
                if (tile.up.Pass == 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize + 1, 0), Quaternion.Euler(0, 0, 270)));
                }
                if (tile.down.Pass == 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize - 1, 0), Quaternion.Euler(0, 0, 90)));
                }
            }
        }
    }
}