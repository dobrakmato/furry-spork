using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemVr : MonoBehaviour
{
    private float _scale = 1.0f;
    private float _maxScale = 1.7f;
    private float _targetScale = 1.0f;
    
    private float _velocity;


    public enum Action
    {
        EXIT,
        START_GAME,
    }

    public Action BtnAction;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_scale - _maxScale) < 0.01)
        {
            Activate();
        }

        _scale = Mathf.Lerp(_scale, _targetScale, 0.01f);
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    void Activate()
    {
        switch (BtnAction)
        {
            case Action.EXIT:
                Application.Quit();
                break;
            case Action.START_GAME:
                FindObjectOfType<AirplaneController>().RestartGame();
                break;
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        _targetScale = _maxScale;
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        _targetScale = 1.0f;
    }
}