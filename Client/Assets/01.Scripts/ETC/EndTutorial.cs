using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] Animator cameraAnimator = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            DEFINE.VCam.m_Follow = null;
            cameraAnimator.enabled = true;
        }
    }
}
