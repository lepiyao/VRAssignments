using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarBodySelection : MonoBehaviour
{
    public List<GameObject> bodyPrefabs = new List<GameObject>();

    public InputActionProperty switchBodyAction;

    public LayerMask mirrorLayer;

    public Transform headTransform;

    private GameObject bodyInstance;

    private int currentBodyIndex = 0;

    private bool disableInputHandling = false;

    // Start is called before the first frame update
    void Start()
    {
        AttachBodyPrefab(0);
    }

    // Update is called once per frame
    void Update()
    {
        int nextBodyIndex = CalcNextBodyIndex();
        if(nextBodyIndex != -1 && IsLookingAtMirror())
            AttachBodyPrefab(nextBodyIndex);
    }

    int CalcNextBodyIndex() // -1 means invalid aka "do nothing"
    {
        int counter = 0;
        bool isJoystickLeft = false;
        bool isJoystickRight = false;
        bool isCentered = false;
        //checked the pressed button
        //print("the pressed input=" );

        //checked the position of the joystick, and add 1 to a counter
        if (counter == 0 & isJoystickLeft)
        {
            counter = 1;
            //ChangeTheClothes
        } else if (counter == 0 & isJoystickRight)
        {
            counter = 1;
            //ChangeTheClothes
        }
        else
        {
            print("Joystick is not centered yet!");
        }

        //if it centered, then reset the counter
        //if it is not centered, then disable the CalcNextBodyIndex
        if (isCentered == true)
        {
            counter = 0;
        } else
        {
            counter = 1;
        }

        return -1;
    }

    bool IsLookingAtMirror()
    {
        //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
        //Example
        //// Bit shift the index of the layer (8) to get a bit mask
        //int layerMask = 1 << 8;

        //// This would cast rays only against colliders in layer 8.
        //// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        //RaycastHit hit;
        //// Does the ray intersect any objects excluding the player layer
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //    Debug.Log("Did Hit");
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //    Debug.Log("Did not Hit");
        //}

        //Simple Raycast detector
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(transform.position, fwd, 10))
        //    print("There is something in front of the object!");

        return false;
    }

    private void AttachBodyPrefab(int index)
    {
        if(index < 0 || index >= bodyPrefabs.Count)
        {
            Debug.LogWarning("Body selection offers no prefab at given index '" + index + "'");
            return;
        }

        if(bodyInstance != null)
        {
            Destroy(bodyInstance);
            bodyInstance = null;
        }

        currentBodyIndex = index;
        bodyInstance = Instantiate(bodyPrefabs[currentBodyIndex], transform);
    }
}
