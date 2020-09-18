using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class Vehicel : MonoBehaviour
{
    [SerializeField] int time;
    public bool islog;
    [SerializeField] int direction = -80;
    private Vector3 endVector;


    private void Start()
    {
        DOTween.SetTweensCapacity(3000, 50);
        endVector = transform.position + new Vector3(0, 0, direction);
        transform.DOMove(endVector, time);
    }

}


