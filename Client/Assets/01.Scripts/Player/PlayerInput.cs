using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] int maxJumpCount = 3;
    private int _currentJumpCount = 0;

    [Space(10f)]
    public UnityEvent<Vector3> OnJumpInput;

    private void Update()
    {
        GetJumpInput();
    }

    private void GetJumpInput()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            if(_currentJumpCount >= maxJumpCount)
                return;

            _currentJumpCount++;
            Vector3 mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Debug.Log("Jump Input");
            OnJumpInput?.Invoke(mousePos);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
            _currentJumpCount = 0;
    }
}
