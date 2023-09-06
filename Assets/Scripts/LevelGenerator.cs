using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{

    private int[,] levelMap =
 {
 {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
 {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
 {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
 {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
 {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
 {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
 {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
 {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
 {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
 {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
 {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
 }; 
    public Tile[] tiles;

    public Tilemap tilemap;
    

    // Start is called before the first frame update
    void Start()
    {

        BuildLevel();
        
    }

    void BuildLevel()
    {
        for (int x = 0; x < levelMap.GetLength(0); x++)
        {
            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                int type = getType(x,y);

                tilemap.SetTile(new Vector3Int(y - 5, 4 - x,0), tiles[type]);

                Matrix4x4 m = Matrix4x4.Rotate(getRotation(type, x, y));
                tilemap.SetTransformMatrix(new Vector3Int(y - 5, 4 - x,0),m);
            }
        }
    }

    private int getType(int x, int y)
    {
        x = Math.Min(levelMap.GetLength(0), x);
        y = Math.Min(levelMap.GetLength(1), y);
        return levelMap[x, y];
    }

    private Quaternion getRotation(int type, int x, int y)
    {
        if (type == 2)
        {
            int below = getType(x+1,y);
            if (below == 5 || below == 0) return Quaternion.Euler(0, 0, 90);
        }
        if (type == 4)
        {
            int below = getType(x+1,y);
            if (below == 5 || below == 0) return Quaternion.Euler(0, 0, 90);
        }

        return Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
