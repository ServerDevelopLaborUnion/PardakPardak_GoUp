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
    private void OnCollisionEnter(Collision other) {
        isBool = other.gameObject.name == "Player";
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.name == "Player") isBool = false;
    }
}
