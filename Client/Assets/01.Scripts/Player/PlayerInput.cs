using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnJumpInput;

    void Update()
    {
        GetJumpInput();
    }

    private void GetJumpInput()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Debug.Log("Jump Input");
            OnJumpInput?.Invoke(mousePos);
        }
    }
}
