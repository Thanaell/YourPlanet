using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum TileType
{
    DIRT, WATER, PLANT, HUMANS
}

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public TileType type;

    public UnityEvent<int, int, TileType> changeTypeEvent;

    public void changeType(TileType newType)
    {
        type = newType;
        this.gameObject.GetComponent<SpriteRenderer>().material=GameObject.Find("MaterialContainer").GetComponent<MaterialContainer>().GetMaterial(newType);
    }

    public void CycleTypes()
    {
        switch (type)
        {
            case TileType.DIRT:
                changeType(TileType.WATER); break;
            case TileType.WATER:
                changeType(TileType.PLANT); break;
            case TileType.PLANT:
                changeType(TileType.HUMANS); break;
            case TileType.HUMANS:
                changeType(TileType.DIRT);
                break;
        }
    }

    public void OnMouseDown()
    {
        CycleTypes();
        changeTypeEvent.Invoke(x, y, type);

    }
}
