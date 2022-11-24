using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    [field: SerializeField, Range(0f, 60f)]
    public float CurrentOxygen { get; set; } = 60f;
    [field: SerializeField] public bool InWater { get; set; } = false;

    [SerializeField] private float _decreasePerSecond = 1f;

    private void Start()
    {
        StartCoroutine(DecreaseOxygen());
    }

    private IEnumerator DecreaseOxygen()
    {
        while(CurrentOxygen > 0)
        {
            if(!InWater)
            CurrentOxygen -= _decreasePerSecond;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Water"))
            InWater = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Water"))
            InWater = false;
    }
}
