using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringNavigation : MonoBehaviour
{
    public InputActionProperty flyAction;

    public Transform directionIndicator;

    public float speedFactor = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flyAction.action.IsPressed())
            transform.position += directionIndicator.forward * flyAction.action.ReadValue<float>() * Time.deltaTime * speedFactor;
    }
}
