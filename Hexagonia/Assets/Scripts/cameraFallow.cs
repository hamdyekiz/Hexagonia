using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 distance;
    void Start()
    {
        distance = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position ;
    }
}
