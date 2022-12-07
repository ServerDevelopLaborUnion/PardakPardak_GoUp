using System.ComponentModel;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    [SerializeField] float divisor = 2f;

    private Rigidbody rb = null;
    private Vector3 velocity = new Vector3();

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        if(rb == null)
            rb = other.GetComponent<Rigidbody>();

        velocity = rb.velocity;
        velocity.y = velocity.y / divisor;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        rb.velocity = velocity;
    }
}
