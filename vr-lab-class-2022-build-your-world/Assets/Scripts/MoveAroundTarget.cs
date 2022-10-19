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
        return transform.position;
        
        // TODO: Exercise 1.5
    }

    Quaternion CalculateRotationUpdate(Vector3 newPosition)
    {
        return transform.rotation;

        // TODO: Exercise 1.5
    }
}
