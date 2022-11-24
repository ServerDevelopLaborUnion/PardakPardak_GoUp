using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 5f;

    [SerializeField] private Vector3 _minClamp, _maxClamp;

    private Rigidbody _rigid = null;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        _rigid.velocity = new Vector3(
            Mathf.Clamp(_rigid.velocity.x, _minClamp.x, _maxClamp.x),
            Mathf.Clamp(_rigid.velocity.y, float.MinValue, _maxClamp.y),
            Mathf.Clamp(_rigid.velocity.z, _minClamp.z, _maxClamp.z)
        );
    }

    public void CommonJump(Vector3 mousePos)
    {
        if(mousePos.y >= transform.position.y) return;

        Vector3 dir = (transform.position - mousePos).normalized;
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(dir * _jumpPower);
    }
}
