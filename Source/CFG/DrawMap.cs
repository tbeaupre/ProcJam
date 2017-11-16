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
                generator.grammar.Iterate();
                Draw(MapConvert.ConvertMap(generator, 0));
            }
        }
        
        private void Draw(Map map)
        {
            Clear();
            Debug.Log(generator.start);
			Debug.Log(generator.grammar.current);
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
        }

        private void DrawTile(Tile tile, int x, int y)
        {
            drawn.Add(Instantiate((tile.isRoom ? roomTilePrefab : emptyTilePrefab), new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity));

            if (x % 2 == 0)
            {
                if (tile.left.pass < 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize - 1, y * tileSize, 0), Quaternion.identity));
                }
                if (tile.right.pass < 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize + 1, y * tileSize, 0), Quaternion.Euler(0, 0, 180)));
                }
            }
            if (y % 2 == 0)
            {
                if (tile.up.pass < 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize + 1, 0), Quaternion.Euler(0, 0, 270)));
                }
                if (tile.down.pass < 0)
                {
                    drawn.Add(Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize - 1, 0), Quaternion.Euler(0, 0, 90)));
                }
            }
        }
    }
}