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
        /*offset.x = 0F;
        offset.y = 0F;
        offset.z = 0F;
        transform.position = transform.position+offset;*/
        /*transform.localPosition = offset;
        transform.LookAt(target);*/

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Exercise 1.4 -> 2.)
        //transform.rotation *= Quaternion.Euler(-43, 0, 0);
        transform.LookAt(target);
    }
}
