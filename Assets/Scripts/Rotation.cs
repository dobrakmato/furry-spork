using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float Speed;

    private float _offset;
    
    // Start is called before the first frame update
    void Start()
    {
        _offset = Random.Range(0, Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Mathf.Sin(_offset + Speed * Time.time) * 15, 0);
    }
}
