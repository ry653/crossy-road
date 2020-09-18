using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerMovingobject : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private TerrainDate terrainDatas;
    [SerializeField] public Transform objHolder;
    [Header("music")]
    [SerializeField] private AudioSource beep1Sound;  
    [SerializeField] private AudioSource beep2Sound;

    private List<GameObject> curentCars = new List<GameObject>();
    private float time;


    void Start()
    {
        StartCoroutine(TestCoroutine());
        StartCoroutine(SoundBeep1());        
        StartCoroutine(SoundBeep2());
    }
    IEnumerator TestCoroutine()
    {
        while (true)
        {
            if (terrainDatas.name == "Log")
            {
                time = Random.Range(1.3f, 2.7f);
            }
            else
            {
                time = Random.Range(2, 7);
            }
            yield return new WaitForSeconds(time);
            Instantiate(terrainDatas.possibleTerrain[Random.Range(0, terrainDatas.possibleTerrain.Count)], spawnPos.position, Quaternion.identity, objHolder);
        }
    }
    IEnumerator SoundBeep1()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            beep1Sound.Play();
        }
    }
    IEnumerator SoundBeep2()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            beep2Sound.Play();
        }
    }
}
