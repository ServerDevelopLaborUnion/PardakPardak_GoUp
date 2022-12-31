using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if(other.CompareTag("Ground"))
            Destroy(gameObject);
    }
}
