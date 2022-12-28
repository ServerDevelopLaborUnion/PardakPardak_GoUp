using System.Collections;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    // [field: SerializeField, Range(0f, 60f)]
    // public float CurrentOxygen { get; set; } = 60f;
    [SerializeField] float _maxOxygen = 60f;
    private float currentOxygen = 0f;
    public float CurrentOxygen {
        get => currentOxygen;
        set {
            currentOxygen = value;
            playerJump.JumpPower = currentOxygen / _maxOxygen * playerJump.DefaultJumpPower;
        }
    }

    [field: SerializeField] public bool InWater { get; set; } = false;

    [Header("Oxygen Control")]
    [SerializeField] private float _decreasePerSecond = 1f;
    [SerializeField] private float _increasePerSecond = 1f;
    [SerializeField] private float _decreaseDelay = 0.5f;

    private PlayerJump playerJump = null;

    private void Awake()
    {
        playerJump = transform.GetComponent<PlayerJump>();
    }

    private void Start()
    {
        StartCoroutine(DecreaseOxygen());
        currentOxygen = _maxOxygen;
    }

    private IEnumerator DecreaseOxygen()
    {
        while(true)
        {
            CurrentOxygen += InWater ? _increasePerSecond : -_decreasePerSecond;
            CurrentOxygen = Mathf.Min(CurrentOxygen, _maxOxygen);

            yield return new WaitForSeconds(_decreaseDelay);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Water"))
            InWater = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Water"))
            InWater = false;
    }
}
