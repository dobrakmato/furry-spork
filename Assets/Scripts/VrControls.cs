using System;
using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class VrControls : MonoBehaviour
{
    public GameObject airplane;
    public AirplaneController ctrl;
    
    
    public float HorizontalSensitivity = 30f;

    private float _smoothHorizontal = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ctrl = airplane.GetComponent<AirplaneController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalAngle = Vector3.SignedAngle(transform.forward, Vector3.forward, Vector3.right);
        bool isPressed = verticalAngle > 0.0;

        ctrl.shouldAscendBecauseOfVr = isPressed;
        var rawAngle = Vector3.SignedAngle(transform.forward, -Vector3.forward, -Vector3.up);

        var nextHorInput = Mathf.Clamp(rawAngle, -HorizontalSensitivity, HorizontalSensitivity) / HorizontalSensitivity;
        _smoothHorizontal = Mathf.Lerp(_smoothHorizontal, nextHorInput, 0.6f);
        
        ctrl.horizontalInput = _smoothHorizontal;

        if (Api.IsGearButtonPressed)
        {
            ctrl.RestartGame();
        }

        var temp = transform.position;
        temp.y = airplane.transform.position.y;
        transform.position = temp;
    }
}
