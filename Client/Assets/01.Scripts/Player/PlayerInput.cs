using UnityEngine;
using UnityEngine.Events;
using static DEFINE;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] int maxJumpCount = 3;
    private int _currentJumpCount = 0;
    private Camera inputCamera = null;

    [Space(10f)]
    public UnityEvent<Vector3> OnJumpInput;

    public UnityEvent<Vector3> DefaultJump;

    private PlayerOxygen oxygen= null;
    AudioSource chalbakSound;

    private void Awake()
    {
        inputCamera = MainCam.transform.GetChild(0).GetComponent<Camera>();
        oxygen = GetComponent<PlayerOxygen>();
        chalbakSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetJumpInput();
    }

    private void GetJumpInput()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            if(_currentJumpCount >= maxJumpCount)
                return;

            _currentJumpCount++;
            Vector3 mousePos = inputCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            // Debug.Log("Jump Input");
            OnJumpInput?.Invoke(mousePos); 

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _currentJumpCount = 0;
            if(!oxygen.InWater)
                DefaultJump?.Invoke(Vector3.up);
            // rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            // OnJumpInput?.Invoke(-transform.right);
            AudioManager.Instance.PlayAudio("찰박", chalbakSound);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Water"))
            _currentJumpCount = 0;
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Water"))
            _currentJumpCount++;
            
    }
}
