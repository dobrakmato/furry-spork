using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneShadow : MonoBehaviour
{
    private GameObject _airplane;
    private MeshRenderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _airplane = FindObjectOfType<AirplaneController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var selfPosition = transform.position;
        var airplanePosition = _airplane.transform.position;
        
        
        // shadow more promienent near ground
        float distance = Mathf.Abs(airplanePosition.y - selfPosition.y);
        float alpha = 1 - Mathf.Lerp(0, 1, Mathf.Clamp01(distance / 4));
        _renderer.material.SetColor ("_Color", new Color(1f, 1f, 1f, alpha));


        // sync x coordinate
        var copy = selfPosition;
        copy.x = airplanePosition.x;
        selfPosition = copy;
        transform.position = selfPosition;
    }
}
