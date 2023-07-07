using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class MaterialContainer : MonoBehaviour
{
    public Material dirtMaterial;
    public Material waterMaterial;
    public Material plantsMaterial;
    public Material humansMaterial;


    public Material GetMaterial(TileType tileType)
    {
        Material material = null;
        switch (tileType)
        {
            case TileType.DIRT: material = dirtMaterial; break;
            case TileType.WATER: material = waterMaterial; break;
            case TileType.PLANT: material = plantsMaterial; break;
            case TileType.HUMANS: material = humansMaterial; break; 
        }
        return material;
    }
}
