 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothness);
    }
    private void Start()
    {
        
    }

}
