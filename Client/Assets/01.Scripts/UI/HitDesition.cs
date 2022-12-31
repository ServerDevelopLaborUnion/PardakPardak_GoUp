using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDesition : Desition
{
    public override bool ReturnDesition()
    {
        if(isBool){
            isBool = false;
            return true;
        }
        return false;
    }

    public void OnCollisionEnter(Collision other) {
        isBool = other.gameObject.name == "Player";
    }
}
