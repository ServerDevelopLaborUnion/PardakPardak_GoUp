using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceSound : MonoBehaviour
{
    //거리에 따라 소리 재생
    //그냥 getcomponent하면 거기 둔 오디오 가져와짐
    //그거 거리에 가까워지면 플레이 아니면 끄기
    public float inDistance;
    public string audioName;


    [SerializeField] private GameObject _player;
    private AudioSource audioSource;
    private bool _isOneCheck = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DistanceSoundOn();
        DistanceSoundOff();
    }

    void DistanceSoundOn()
    {
        if (CalcDistance() && !_isOneCheck)
        {
            AudioManager.Instance.PlayAudio(audioName, audioSource);
            _isOneCheck = true;
        }
    }
    
    void DistanceSoundOff()
    {
        if (!_isOneCheck)
        {
            audioSource.Stop();
        }
    }

    private bool CalcDistance()
    {
        float PosX = Mathf.Pow((gameObject.transform.position.x - _player.transform.position.x), 2);
        float PosY = Mathf.Pow((gameObject.transform.position.y - _player.transform.position.y), 2);

        if (Mathf.Sqrt(PosX + PosY) > inDistance) _isOneCheck = false;

        return Mathf.Sqrt(PosX + PosY) < inDistance;
    }
}
