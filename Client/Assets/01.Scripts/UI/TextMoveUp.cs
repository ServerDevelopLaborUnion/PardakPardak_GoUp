using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextMoveUp : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    public float distance;


    private void Update() {
        
        MoveUp();
    }
    private void MoveUp(){

        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if(distance < 20){

            text.transform.DOMoveY(4f, 2.5f);

        }
    }
}
