using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainGenerator : MonoBehaviour
{
    int Mx = 0, Mz = 0;
    float Mh = 1;
    public float ElevateHeight,BoxHeight,CircleRadius;
    public int BoxZMin = 30, BoxZMax = 100, BoxXMin = 30, BoxXMax = 100;
    public Vector2 CylinderCenter;
    public void Pip()
    {
        Terrain tTerr = GetComponent<Terrain>();
        if (tTerr == null)
        {
            Debug.Log("tTerr=null");
        }
        int heightMapW = tTerr.terrainData.heightmapResolution;
        Debug.Log(heightMapW);
        float[,] heights = tTerr.terrainData.GetHeights(0, 0, heightMapW, heightMapW);
        heights[Mz, Mx] = Mh;
        tTerr.terrainData.SetHeights(0, 0, heights);
    }
    public void SetElevation()
    {
        Terrain tTerr = GetComponent<Terrain>();
        if (tTerr == null)
        {
            Debug.Log("tTerr=null");
        }
        int heightMapW = tTerr.terrainData.heightmapResolution;
        Debug.Log(heightMapW);
        float[,] heights = tTerr.terrainData.GetHeights(0, 0, heightMapW, heightMapW);
        Vector3 MapPos;
        MapPos.z = 0;
        for (MapPos.z = 0; MapPos.z < heightMapW; MapPos.z++)
        {
            for (MapPos.x = 0; MapPos.x < heightMapW; MapPos.x++)
            {
                heights[(int)MapPos.z, (int)MapPos.x] = ElevateHeight;
            }
        }
        tTerr.terrainData.SetHeights(0, 0, heights);
    }
    public void ExtrudeBox()
    {
        Terrain tTerr = GetComponent<Terrain>();
        if (tTerr == null)
        {
            Debug.Log("tTerr=null");
        }
        int heightMapW = tTerr.terrainData.heightmapResolution;
        Debug.Log(heightMapW);
        float[,] heights = tTerr.terrainData.GetHeights(0, 0, heightMapW, heightMapW);
        Vector3 MapPos;
        for (MapPos.z = 0; MapPos.z < heightMapW; MapPos.z++)
        {
            for (MapPos.x = 0; MapPos.x < heightMapW; MapPos.x++)
            {
                if (MapPos.z > BoxZMin && MapPos.z<BoxZMax && MapPos.x>BoxXMin && MapPos.x<BoxXMax)
                {
                    heights[(int)MapPos.z, (int)MapPos.x] = BoxHeight;
                }
            }
        }
        tTerr.terrainData.SetHeights(0, 0, heights);
    }
    public void threeStairs()
    {
        BoxZMin = 0;
        BoxZMax = 10;
        BoxXMin = 0;
        BoxXMax = 10;
        BoxHeight = .1f;
        ExtrudeBox();

        BoxZMin = 0;
        BoxZMax = 10;
        BoxXMin = 10;
        BoxXMax = 20;
        BoxHeight = .2f;
        ExtrudeBox();

        BoxZMin = 0;
        BoxZMax = 10;
        BoxXMin = 20;
        BoxXMax = 30;
        BoxHeight = .3f;
        ExtrudeBox();
    }
    public void ExtrudeCylinder()
    {
        Terrain tTerr = GetComponent<Terrain>();
        if (tTerr == null)
        {
            Debug.Log("tTerr=null");
        }
        int heightMapW = tTerr.terrainData.heightmapResolution;
        Debug.Log(heightMapW);
        float[,] heights = tTerr.terrainData.GetHeights(0, 0, heightMapW, heightMapW);
        Vector3 MapPos;
        for (MapPos.z = 0; MapPos.z < heightMapW; MapPos.z++)
        {
            for (MapPos.x = 0; MapPos.x < heightMapW; MapPos.x++)
            {
                Vector2 tempPos = new Vector2(MapPos.z, MapPos.x);
                if (Vector2.Distance(tempPos,CylinderCenter)<CircleRadius)
                {
                    heights[(int)MapPos.z, (int)MapPos.x] = BoxHeight;
                }
            }
        }
        tTerr.terrainData.SetHeights(0, 0, heights);
    }
    public void ExtrudeDome()
    {
        Terrain tTerr = GetComponent<Terrain>();
        if (tTerr == null)
        {
            Debug.Log("tTerr=null");
        }
        int heightMapW = tTerr.terrainData.heightmapResolution;
        Debug.Log(heightMapW);
        float[,] heights = tTerr.terrainData.GetHeights(0, 0, heightMapW, heightMapW);
        Vector3 MapPos;
        for (MapPos.z = 0; MapPos.z < heightMapW; MapPos.z++)
        {
            for (MapPos.x = 0; MapPos.x < heightMapW; MapPos.x++)
            {
                Vector2 tempPos = new Vector2(MapPos.z, MapPos.x);
                float tempHeight = BoxHeight;
                if (Vector2.Distance(tempPos, CylinderCenter) < CircleRadius)
                {
                    tempHeight = BoxHeight* Mathf.Cos(0.5f*Mathf.PI* Vector2.Distance(tempPos, CylinderCenter) / CircleRadius);
                    heights[(int)MapPos.z, (int)MapPos.x] = tempHeight;
                }
            }
        }
        tTerr.terrainData.SetHeights(0, 0, heights);
    }
}
