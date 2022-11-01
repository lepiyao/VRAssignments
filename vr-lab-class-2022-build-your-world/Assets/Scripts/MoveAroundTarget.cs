using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundTarget : MonoBehaviour
{
    public Transform target;

    public float degreesPerSecond = 20;

    private Vector3 targetPositionXZ
    {
        get
        {
            return new Vector3(target.position.x, 0, target.position.z);
        }
    }

    private Vector3 positionXZ
    {
        get
        {
            return new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    private Vector3 directionToTarget
    {
        get
        {
            return (targetPositionXZ - positionXZ);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = CalculatePositionUpdate();
        var newRotation = CalculateRotationUpdate(newPosition);
        transform.position = newPosition;
        transform.rotation = newRotation;
    }

    Vector3 CalculatePositionUpdate()
    {
        // TODO: Exercise 1.5
        //changing the degree rotation
        /*degreesPerSecond += degreesPerSecond * Time.deltaTime;
        
        float xa = target.position.x + Mathf.Cos(degreesPerSecond);
        float ya = 0;
        float za = target.position.z + Mathf.Sin(degreesPerSecond);
        Vector3 circlePos = new Vector3(xa,ya,za);
        
        transform.position += circlePos*Time.deltaTime;
        Debug.Log("after transform.position= " + transform.position);*/
        transform.RotateAround(target.transform.position,new Vector3 (0, 1, 0), degreesPerSecond*Time.deltaTime);
        return transform.position;
    }

    Quaternion CalculateRotationUpdate(Vector3 newPosition)
    {
        // TODO: Exercise 1.5
        //Debug.Log("2nd after newPosition = "+newPosition);
        //transform.RotateAround(target.transform.position, Vector3.forward, degreesPerSecond*Time.deltaTime);
        return transform.rotation;
    }
}
