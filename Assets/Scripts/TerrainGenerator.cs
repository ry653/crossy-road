using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainDate> terrainDatas = new List<TerrainDate>();
    [SerializeField] private Transform terrainHolder; 

    private List<GameObject> curentTerrains = new List<GameObject>();

     public Vector3 curentPosition = new Vector3(5, 5, 0);

    void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(5, 0, 0));
        }
        maxTerrainCount = curentTerrains.Count;
    }

    public void SpawnTerrain(bool isStart,Vector3 playerPos)
    {
        if (curentPosition.x - playerPos.x < minDistanceFromPlayer || (isStart))
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(0, terrainDatas[whichTerrain].MaxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0,terrainDatas[whichTerrain].possibleTerrain.Count)], curentPosition, Quaternion.identity, terrainHolder);
                curentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (curentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(curentTerrains[0]);
                        curentTerrains.RemoveAt(0);
                    }
                }
                curentPosition.x++;
            }
        }
  
    }
}
