using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateSecond : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] float duration = 1f;
    [SerializeField] float rotateDuration = 0.5f;

    [SerializeField] Vector3 targetRotate = new Vector3();
    private Vector3 defaultRotate = new Vector3();

    private bool onAttached = false;
    private bool onRotating = false;
    private float currentTimer = 0f;

    private void Awake()
    {
        defaultRotate = transform.eulerAngles;
    }

    private void Update()
    {
        if(!onAttached)
            return;
        
        if(!onRotating)
            currentTimer += Time.deltaTime;

        if(currentTimer >= delay)
        {
            currentTimer = 0f;
            onRotating = true;
            StartCoroutine(Rotate(targetRotate, () => {
                StartCoroutine(Rotate(defaultRotate, () => {
                    onRotating = false;
                }));
            })); 
        }
    }

    private IEnumerator Rotate(Vector3 targetRotate, Action callback = null)
    {
        float timer = 0f;
        Vector3 rotate = transform.localEulerAngles;
        while(timer <= rotateDuration)
        {
            timer += Time.deltaTime;
            rotate = Vector3.Lerp(rotate, targetRotate, timer / rotateDuration);
            transform.localEulerAngles = rotate;
            yield return null;
        }

        callback?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            onAttached = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onAttached = false;
            currentTimer = 0f;
        }
    }
}
