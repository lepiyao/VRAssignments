using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUtils
{
    public static Vector3 ManualYRotation(Vector3 directionXZ, float degrees)
    {
        var dirX = directionXZ.x;
        var dirZ = directionXZ.z;
        var radians = -(Mathf.Deg2Rad * degrees);
        var newDirection = Vector3.zero;
        newDirection.x = dirX * Mathf.Cos(radians) - dirZ * Mathf.Sin(radians);
        newDirection.z = dirX * Mathf.Sin(radians) + dirZ * Mathf.Cos(radians);
        return newDirection;
    }

    public static Vector3 EulerYRotation(Vector3 directionXZ, float degrees)
    {
        return Quaternion.Euler(0, degrees, 0) * directionXZ;
    }

    public static Vector3 EulerXRotation(Vector3 directionYZ, float degrees)
    {
        return Quaternion.Euler(degrees, 0, 0) * directionYZ;
    }

    public static Vector3 AngleAxisYRotation(Vector3 directionXZ, float degrees)
    {
        return Quaternion.AngleAxis(degrees, Vector3.up) * directionXZ;
    }
}
