using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Date",menuName = "Terrain Date")]
public class TerrainDate : ScriptableObject
{
    public List<GameObject> possibleTerrain;
    public int MaxInSuccession;
}
