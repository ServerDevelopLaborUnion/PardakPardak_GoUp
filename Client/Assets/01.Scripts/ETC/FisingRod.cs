using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FisingRod : MonoBehaviour
{
    [SerializeField]
    Transform transform;
    [SerializeField]
    CinemachineVirtualCamera cmCam;
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
            cmCam.Priority =20;
            other.transform.parent = transform;
            other.transform.rotation= Quaternion.identity;
            fish = other.transform;
            bite = true;
            anim.SetTrigger("End");
        }
    }
    public void ThrowFish(){
        fish.parent = null;
        rigid.AddForce(Vector3.right*100,ForceMode.Impulse);
        rigid.useGravity = true;
        StartCoroutine(TurnEndingScene());
    }
    IEnumerator TurnEndingScene(){
        yield return new WaitForSeconds(0.3f);
        SceneLoader.Instance.LoadAsync("Ending");
    }
}
