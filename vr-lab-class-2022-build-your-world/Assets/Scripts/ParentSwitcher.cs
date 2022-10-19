using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSwitcher : MonoBehaviour
{
    public List<Transform> parents = new List<Transform>();

    public KeyCode nextParentKey = KeyCode.RightArrow;

    private int currentParent = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetParent(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(nextParentKey))
            SetParent((currentParent + 1) % parents.Count);
    }

    void SetParent(int idx)
    {
        // TODO: Exercise 1.4 -> 1.)
        
        // what is the effect of worldPositionStays?
    }
}
