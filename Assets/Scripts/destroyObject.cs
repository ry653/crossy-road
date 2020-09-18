using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MovingObj")
        {
        Destroy(collision.gameObject);
            DOTween.Pause(collision.transform);
        }
        
    }
}
