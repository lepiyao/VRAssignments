using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Still need some fixing
        offset.x = 0.5F;
        offset.y = 1.5F;
        offset.z = 0.5F;
        transform.position = transform.position+offset;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Exercise 1.4 -> 2.)
        transform.LookAt(target);

    }
}
