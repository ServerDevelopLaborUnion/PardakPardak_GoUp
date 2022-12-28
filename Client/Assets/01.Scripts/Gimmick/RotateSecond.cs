using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine;
using System;

public class RotateSecond : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] float duration = 1f;
    [SerializeField] float rotateDuration = 0.5f;

    [SerializeField] Transform target = null;
    private Vector3 targetRotate = new Vector3();
    private Vector3 targetPos = new Vector3();
    private Vector3 defaultRotate = new Vector3();
    private Vector3 defaultPos = new Vector3();

    private bool onAttached = false;
    private bool onRotating = false;
    private float currentTimer = 0f;

    private void Awake()
    {
        defaultRotate = transform.eulerAngles;
        defaultRotate.x = GetFixedAngle(defaultRotate.x);
        defaultRotate.y = GetFixedAngle(defaultRotate.y);
        defaultRotate.z = GetFixedAngle(defaultRotate.z);

        defaultPos = transform.position;

        targetRotate = target.eulerAngles;
        targetRotate.x = GetFixedAngle(targetRotate.x);
        targetRotate.y = GetFixedAngle(targetRotate.y);
        targetRotate.z = GetFixedAngle(targetRotate.z);

        targetPos = target.position;
    }

    private void Start()
    {
        onRotating = true;
            StartCoroutine(Rotate(targetRotate, targetPos, () => {
                StartCoroutine(Rotate(defaultRotate, defaultPos, () => {
                    onRotating = false;
                }));
            })); 
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
            StartCoroutine(Rotate(targetRotate, targetPos, () => {
                StartCoroutine(Rotate(defaultRotate, defaultPos, () => {
                    onRotating = false;
                }));
            })); 
        }
    }

    private IEnumerator Rotate(Vector3 targetRotate, Vector3 targetPosition, Action callback = null)
    {
        float timer = 0f;
        Vector3 startRotate = transform.eulerAngles;
        startRotate.x = GetFixedAngle(startRotate.x);
        startRotate.y = GetFixedAngle(startRotate.y);
        startRotate.z = GetFixedAngle(startRotate.z);

        Vector3 rotate = startRotate;

        Vector3 startPos = transform.position;
        Vector3 pos = transform.position;
        while(timer <= rotateDuration)
        {
            timer += Time.deltaTime;
            rotate = Vector3.Lerp(startRotate, targetRotate, timer / rotateDuration);
            pos = Vector3.Lerp(startPos, targetPosition, timer / rotateDuration);
            transform.eulerAngles = rotate;
            transform.position = pos;
            yield return null;
        }

        yield return new WaitForSeconds(delay);

        callback?.Invoke();
    }

    private float GetFixedAngle(float angle) => angle >= 180f ? angle - 360f : angle;

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
