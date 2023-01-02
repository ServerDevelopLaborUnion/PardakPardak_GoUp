using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWaterDesition : Desition
{
    public override bool ReturnDesition()
    {
        if(isBool){
            isBool = false;
            return true;
        }
        return false;
    }
    private void OnTriggerEnter(Collider other) {
        isBool = other.gameObject.name == "Player";
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "Player") isBool = false;
    }
}
