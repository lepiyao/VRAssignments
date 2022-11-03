using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSwitcher : MonoBehaviour
{
    public List<Transform> parents = new List<Transform>();

    public KeyCode nextParentKey = KeyCode.RightArrow;

    private int currentParent = 0;

    //public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        SetParent(0);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(nextParentKey)){
        //    SetParent((currentParent + 1) % parents.Count);
        //}
        if (Input.GetKeyDown(nextParentKey))
        {
            currentParent += 1;
        }

        if (currentParent == parents.Count)
        {
            currentParent = 0;
        }

        //Rotate the camera to -43 degree so it can see the whole model if the parent = 1
        if (currentParent == 1)
        {
            transform.rotation *= Quaternion.Euler(-43, 0, 0);
        }

        SetParent(currentParent);
    }

    void SetParent(int idx)
    {
        // TODO: Exercise 1.4 -> 1.)
        transform.SetParent(parents[idx], false);
        //currentParent += 1;
        // what is the effect of worldPositionStays?
        /*If we set the worldPositionStays as TRUE
         the object will keep the same position 
        as the previous Parent*/
    }
}
