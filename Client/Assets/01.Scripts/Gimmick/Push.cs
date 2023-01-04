using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] float force = 3f;
    [SerializeField] bool destroyOnPush;

    private Rigidbody rb = null;

    private void OnCollisionEnter(Collision other)
    {
        if(!other.gameObject.CompareTag("Player"))
            return;

        Vector3 dir = (other.transform.position - transform.position).normalized;

        if(rb == null)
            rb = other.gameObject.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.AddForce(dir * force, ForceMode.Impulse);

        if(destroyOnPush){
            Destroy(transform.root.gameObject);
        }
    }
}
