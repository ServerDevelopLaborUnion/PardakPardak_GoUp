using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisingRod : MonoBehaviour
{
    [SerializeField]
    Transform transform;
    Animator anim;
    Rigidbody rigid;
    Transform fish;
    bool bite;
    private void Start() {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name =="Player"&&bite == false){
            rigid = other.GetComponent<Rigidbody>();
            Animator playerAnim = other.GetComponentInChildren<Animator>();
            playerAnim.SetTrigger("RollBack");
            rigid.useGravity = false;
            rigid.velocity = Vector3.zero;
            other.transform.parent = transform;
            other.transform.rotation= Quaternion.identity;
            fish = other.transform;
            bite = true;
            anim.SetTrigger("End");
        }
    }
    public void ThrowFish(){
        fish.parent = null;
        rigid.AddForce(Vector3.right*30,ForceMode.Impulse);
        rigid.useGravity = true;
    }
}
