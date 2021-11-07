using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class VrControls : MonoBehaviour
{
    public GameObject airplane;
    public AirplaneController ctrl;
    
    
    public float HorizontalSensitivity = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        ctrl = airplane.GetComponent<AirplaneController>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalAngle = Vector3.SignedAngle(transform.forward, Vector3.forward, Vector3.right);
        bool isPressed = verticalAngle > 0.0;

        ctrl.shouldAscendBecauseOfVr = isPressed;
        var rawAngle = Vector3.SignedAngle(transform.forward, -Vector3.forward, -Vector3.up);
        
        ctrl.horizontalInput = Mathf.Clamp(rawAngle, -HorizontalSensitivity, HorizontalSensitivity) / HorizontalSensitivity;

        if (Api.IsGearButtonPressed)
        {
            ctrl.RestartGame();
        }

        var temp = transform.position;
        temp.y = airplane.transform.position.y;
        transform.position = temp;
    }
}
