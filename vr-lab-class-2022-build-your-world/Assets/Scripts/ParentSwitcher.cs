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
        //offset = new Vector3(0.5f, 2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(nextParentKey))
            SetParent((currentParent + 1) % parents.Count);*/
        if (Input.GetKeyDown(nextParentKey))
        {
            currentParent += 1;
            /*this.transform.position = transform.position + offset;
            offset.x = 0;
            offset.y = 0;
            offset.z = 0;*/
        }

        if (currentParent == parents.Count)
            currentParent = 0;
        SetParent(currentParent);
    }

    void SetParent(int idx)
    {
        // TODO: Exercise 1.4 -> 1.)
        transform.SetParent(parents[idx], false);
        //currentParent++;
        // what is the effect of worldPositionStays?
    }
}
