using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoins : MonoBehaviour
{
    void Start()
    {
        if (Random.Range(0,4)!=1)
        {
            gameObject.SetActive(false);
        }
    }
}
