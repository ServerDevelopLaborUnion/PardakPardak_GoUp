using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer = null;
    [SerializeField] string volumeKey = "Volume";
    private Slider slider = null;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }
    
    private void Start()
    {
        slider.value = DataManager.Instance.userSetting.Volume;
        audioMixer.SetFloat(volumeKey, DataManager.Instance.userSetting.Volume);
    }

    public void SetVolume()
    {
        float volume = slider.value <= -40f ? -80f : slider.value;
        audioMixer.SetFloat(volumeKey, volume);
        DataManager.Instance.userSetting.Volume = volume;
    }
}