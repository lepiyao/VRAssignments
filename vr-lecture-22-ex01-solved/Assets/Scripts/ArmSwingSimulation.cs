using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwingSimulation : MonoBehaviour
{
    [SerializeField]
    private Vector3 shoulderAnchorOffset = new Vector3(0, 0.45f, 0);

    public float maximumSwingDegrees = 30;

    public bool flipDirection = false;

    public float speedFactor = 3.0f;

    private Vector3 anchorPosition;

    private Vector3 localStartPosition;

    private Vector3 anchorPositionYZ
    {
        get
        {
            return new Vector3(0, anchorPosition.y, anchorPosition.z);
        }
    }

    private Vector3 localStartPositionYZ
    {
        get
        {
            return new Vector3(0, localStartPosition.y, localStartPosition.z);
        }
    }

    private Vector3 directionToAnchor
    {
        get
        {
            return (anchorPositionYZ - localStartPositionYZ);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anchorPosition = transform.localPosition + shoulderAnchorOffset;
        localStartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = CalculatePositionUpdate();
        transform.localPosition = newPosition;
    }

    Vector3 CalculatePositionUpdate()
    {
        var x = localStartPosition.x;
        var degrees = maximumSwingDegrees * Mathf.Sin(speedFactor*Time.time);
        if (flipDirection)
            degrees = -degrees;
        var newPosition = anchorPositionYZ - RotationUtils.EulerXRotation(directionToAnchor, degrees);
        newPosition.x = x;
        return newPosition;
    }
}
