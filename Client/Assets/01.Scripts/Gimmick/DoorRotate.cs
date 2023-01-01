using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorRotate : MonoBehaviour
{   

    private void OnTriggerEnter(Collider other) {
        
        Rotate();
    }

    public void Rotate(){

        transform.DORotate(new Vector3(0, -110, 0), 12f);
    }
}
