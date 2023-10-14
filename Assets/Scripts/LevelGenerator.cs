using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
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

    public GameObject powerpellet;
    

    // Awake is called when editor opens (execute in edit mode)
    void Awake()
    {

        foreach (Transform child in transform) {
	        DestroyImmediate(child.gameObject);
        }
        tilemap.ClearAllTiles();
        BuildLevel();      
    }

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (Transform child in transform) {
	        DestroyImmediate(child.gameObject);
        }
        tilemap.ClearAllTiles();
        BuildLevel();
    }

    void BuildLevel()
    {
        for (int x = 0; x < levelMap.GetLength(0) * 2 - 1; x++)
        {
            for (int y = 0; y < levelMap.GetLength(1) * 2; y++)
            {
                placeTile(x, y);
                
            }
        }
    }

    private void placeTile(int x, int y)
    {
        int type = readMap(x,y);
        if (type == 6)
        {
            GameObject pellet = Instantiate(powerpellet, new Vector3(y + 0.5f, -x + 0.5f, 0), Quaternion.identity);
            pellet.transform.parent = transform; 
            return;
        }
        tilemap.SetTile(new Vector3Int(y, -x, 0), tiles[type]);
        Matrix4x4 m = Matrix4x4.Rotate(getRotation(type, x, y));
        tilemap.SetTransformMatrix(new Vector3Int(y, -x, 0),m);
    }

    public int readMap(int x, int y)
    {
        x = (x >= levelMap.GetLength(0)) ? levelMap.GetLength(0) * 2 - 2 - x : x;
        y = (y >= levelMap.GetLength(1)) ? levelMap.GetLength(1) * 2 - 1 - y : y;
        if (x < 0 || y < 0) return 0;
        return levelMap[x, y];
    }

    private Quaternion getRotation(int type, int x, int y)
    {
        int downt = readMap(x+1,y);
        bool down = downt == 5 || downt == 6 || downt == 0;
        int upt = readMap(x-1,y);
        bool up = upt == 5 || upt == 6 || upt == 0;
        int rightt = readMap(x,y+1);
        bool right = rightt == 5 || rightt == 6 || rightt == 0;
        int leftt = readMap(x,y-1);
        bool left = leftt == 5 || leftt == 6 || leftt == 0;

        if (type == 1)
        {
            if (downt == 2 && leftt == 2) return Quaternion.Euler(0, 0, 270);
            if (upt == 2 && rightt == 2) return Quaternion.Euler(0, 0, 90);
            if (upt == 2 && leftt == 2) return Quaternion.Euler(0, 0, 180);
        }
        if (type == 2)
        {
            if (rightt == 2 || rightt == 1 || leftt == 2 || leftt == 1) return Quaternion.Euler(0, 0, 90);
        }
        if (type == 3)
        {
            //wall below pointing at this tile?
            if (downt == 4 && getRotation(downt, x+1, y).Equals(Quaternion.identity))
            {
                //wall to the right?
                if (rightt == 4 && getRotation(rightt, x, y+1).Equals(Quaternion.Euler(0, 0, 90)))
                {
                    return Quaternion.identity;
                }
                //wall to the left?
                if (leftt == 4 && getRotation(leftt, x, y-1).Equals(Quaternion.Euler(0, 0, 90)))
                {
                    return Quaternion.Euler(0, 0, 270);
                }

            }

            //if wall above?
            if (upt == 4 && getRotation(upt, x-1, y).Equals(Quaternion.identity))
            {
                //wall to the right?
                if (rightt == 4 && getRotation(rightt, x, y+1).Equals(Quaternion.Euler(0, 0, 90)))
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                //wall to the left?
                if (leftt == 4 && getRotation(leftt, x, y-1).Equals(Quaternion.Euler(0, 0, 90)))
                {
                    return Quaternion.Euler(0, 0, 180);
                }

            }


            if ((downt == 4 || downt == 3) && (leftt == 4 || leftt == 3)) return Quaternion.Euler(0, 0, 270);
            if ((upt == 4 || upt == 3) && (rightt == 4 || rightt == 3)) return Quaternion.Euler(0, 0, 90);
            if ((upt == 4 || upt == 3) && (leftt == 4 || leftt == 3)) return Quaternion.Euler(0, 0, 180);
        }
        if (type == 4)
        {
            if (down || up) return Quaternion.Euler(0, 0, 90);
        }

        if (type == 7)
        {
            int flip = 0;
            if (leftt == 2 || leftt == 1)
            {
                if (upt == 4 || upt == 3)
                {
                    flip = 180;
                }
                return Quaternion.Euler(flip, 0, 270);
            }
            if (rightt == 2 || rightt == 1)
            {
                if (downt == 4 || downt == 3)
                {
                    flip = 180;
                }
                return Quaternion.Euler(flip, 0, 90);
            }

            //for marking not used in given level.
            if (downt == 2 || downt == 1)
            {
                if (leftt == 4 || leftt == 3)
                {
                    flip = 180;
                }
                return Quaternion.Euler(0, flip, 0);
            }
            if (upt == 2 || upt == 1)
            {
                if (rightt == 4 || rightt == 3)
                {
                    flip = 180;
                }
                return Quaternion.Euler(0, flip, 180);
            }

        }

        return Quaternion.identity;
    }


}
