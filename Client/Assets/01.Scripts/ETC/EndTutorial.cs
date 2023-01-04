using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] Animator cameraAnimator = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other);
            DEFINE.VCam.m_Follow = null;
            cameraAnimator.enabled = true;
        }
    }
}
