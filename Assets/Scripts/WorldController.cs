using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldController : MonoBehaviour
{
    public Dictionary<Tuple<int, int>, GameObject> tilesContainer;

    public void Start()
    {
        tilesContainer= new Dictionary<Tuple<int, int>, GameObject>();
    }
    public List<GameObject> GetNearestTiles(int refi, int refj)
    {
        List<GameObject> nearestTiles = new List<GameObject>();
        for (int i=refi-1; i<=refi+1;i++)
        {
            for (int j=refj-1; j<=refj+1;j++)
            {
                if (!(i== refi && j == refj))
                {
                    if (tilesContainer.ContainsKey(new Tuple<int, int>(i, j)))
                    {
                        nearestTiles.Add(tilesContainer[new Tuple<int, int>(i, j)]);
                    }
                }
            }
        }
        return nearestTiles;
    }
    public void OnTileTypeChanged(int i, int j, TileType newType)
    {
        List<GameObject> nearestTiles=GetNearestTiles(i, j);
        foreach ( GameObject tile in nearestTiles) 
        {
            switch(newType)
            {
                case TileType.WATER:
                    if (tile.GetComponent<Tile>().type != TileType.WATER)
                    {
                        tile.GetComponent<Tile>().changeType(TileType.PLANT);
                    }
                    break;
            }
        }
    }

    public void AddTile(GameObject tile)
    {
        tilesContainer[new Tuple<int, int>(tile.GetComponent<Tile>().x, tile.GetComponent<Tile>().y)]=tile;
    }

    public GameObject GetTile(int i, int j)
    {
        return tilesContainer[new Tuple<int, int>(i, j)];
    }
}
