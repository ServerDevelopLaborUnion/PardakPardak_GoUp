using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torrent : MonoBehaviour
{
    public float speed;

    [SerializeField] Transform dirTrm = null;
    private Rigidbody playerRb = null;
    private bool onTorrenting = false;

    private void FixedUpdate()
    {
        if (onTorrenting)
            playerRb.velocity = dirTrm.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(playerRb == null)
                playerRb = other.GetComponent<Rigidbody>();
            onTorrenting = true;
            playerRb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTorrenting = false;
            playerRb.useGravity = true;
            playerRb.velocity = Vector3.zero;
        }
    }
}
