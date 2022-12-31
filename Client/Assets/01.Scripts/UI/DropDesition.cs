using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDesition : Desition
{
    Rigidbody rigid;
    [SerializeField]
    private float minVelocity;
    [SerializeField]
    private float maxVelocity;
    public override bool ReturnDesition()
    {
        return isBool&& rigid.velocity.y < minVelocity&&rigid.velocity.y > maxVelocity;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player"){
            isBool = true;
            rigid = other.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "Player")
           isBool = false;
    }
}
