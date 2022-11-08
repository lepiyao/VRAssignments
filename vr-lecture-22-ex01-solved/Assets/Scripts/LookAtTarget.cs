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
        
    }

    // Update is called once per frame
    void Update()
    {
        var forward = ((target.position + offset) - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}
