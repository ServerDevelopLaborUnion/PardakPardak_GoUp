using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Property")]
    public float DefaultJumpPower = 10f;
    [SerializeField] private float _minJumpPower;
    [SerializeField] private float _jumpPower = 5f;
    public float JumpPower { get => _jumpPower; set => _jumpPower = Mathf.Clamp(value, _minJumpPower, DefaultJumpPower); }

    private Rigidbody _rigid = null;
    // [Space(10f)]
    // [SerializeField] private Vector3 _minClamp;
    // [SerializeField] private Vector3 _maxClamp;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // private void FixedUpdate()
    // {
    //     _rigid.velocity = new Vector3(
    //         Mathf.Clamp(_rigid.velocity.x, _minClamp.x, _maxClamp.x),
    //         Mathf.Clamp(_rigid.velocity.y, float.MinValue, _maxClamp.y),
    //         Mathf.Clamp(_rigid.velocity.z, _minClamp.z, _maxClamp.z)
    //     );
    // }

    public void DefaultJump(Vector3 dir)
    {
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(dir.normalized * JumpPower, ForceMode.Impulse);
    }

    public void CommonJump(Vector3 mousePos)
    {
        // if(mousePos.y >= transform.position.y) return;

        Vector3 dir = (transform.position - mousePos).normalized;
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(dir * _jumpPower, ForceMode.Impulse);
    }
}
