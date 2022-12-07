using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] float force = 3f;

    private Rigidbody rb = null;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        Vector3 dir = (other.transform.position - transform.position).normalized;

        if(rb == null)
            rb = other.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.AddForce(dir * force, ForceMode.Impulse);

        Destroy(gameObject);
    }
}
