using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiateTiles : MonoBehaviour
{


    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject newTile = Instantiate(tile, new Vector3((float)i,(float)j,0f), Quaternion.identity);
                newTile.GetComponent<Tile>().x = i;
                newTile.GetComponent<Tile>().y = j;
                newTile.GetComponent<Tile>().type = TileType.DIRT;
                this.gameObject.GetComponent<WorldController>().AddTile(newTile);
                newTile.GetComponent<Tile>().changeTypeEvent.AddListener(gameObject.GetComponent<WorldController>().OnTileTypeChanged);
                
            }
        }
    }


  

}
