using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] Transform axisTrm = null;

    private Rigidbody rb = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(rb == null)
                rb = other.GetComponent<Rigidbody>();
            
            Vector3 dir = transform.position - axisTrm.position;
            rb.AddForce(dir.normalized * power, ForceMode.Impulse);
        }
    }
}
