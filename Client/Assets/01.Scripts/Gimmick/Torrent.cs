using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torrent : MonoBehaviour
{
    [SerializeField] Vector3 dir = new Vector3();
    private Rigidbody playerRb = null;
    private bool onTorrenting = false;

    private void Update()
    {
        if(onTorrenting)
            playerRb.velocity = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(playerRb == null)
                playerRb = other.GetComponent<Rigidbody>();
            onTorrenting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            onTorrenting = false;
    }
}
