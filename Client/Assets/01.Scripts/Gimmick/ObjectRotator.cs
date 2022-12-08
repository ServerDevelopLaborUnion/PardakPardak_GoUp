using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    X = 0,
    Y = 1,
    Z = 2,
}

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] bool repeat = false;

    [Space(10f)]
    [SerializeField] Axis axis = Axis.X;
    [SerializeField] float speed = 5f;

    [Space(10f)]
    [SerializeField] float minDeg = -90f;
    [SerializeField] float maxDeg = 90f;
    [SerializeField] float repeatDelay = 0.5f;

    private Dictionary<Axis, Action> rotateActions = new Dictionary<Axis, Action>();

    private Vector3 rotate = new Vector3();
    private bool stop = false;
    
    private bool onDecreasing = false;
    public bool OnDecreasing {
        get => onDecreasing;
        set {
            if(onDecreasing != value)
                StartCoroutine(RepeatCoroutine(repeatDelay));

            onDecreasing = value;
        }
    }

    private void Awake()
    {
        rotateActions[Axis.X] = () => rotate.x = DoRotate(rotate.x);
        rotateActions[Axis.Y] = () => rotate.y = DoRotate(rotate.y);
        rotateActions[Axis.Z] = () => rotate.z = DoRotate(rotate.z);
    }

    private void Start()
    {
        rotate = transform.localEulerAngles;
    }

    private void Update()
    {
        if(stop) return;

        rotateActions[axis]?.Invoke();
        transform.rotation = Quaternion.Euler(rotate);
    }

    public float DoRotate(float target)
    {
        float incValue = speed * Time.deltaTime;

        if(repeat)
        {
            OnDecreasing = OnDecreasing ? (target > minDeg) : (target >= maxDeg);
            incValue *= OnDecreasing ? -1 : 1;
        }

        target += incValue;

        return target;
    }

    private IEnumerator RepeatCoroutine(float delay)
    {
        stop = true;
        yield return new WaitForSeconds(delay);
        stop = false;
    }
}
