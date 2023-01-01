using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGizmoRange : MonoBehaviour
{
    [SerializeField] float radius = 5f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);    
    }
}
