using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<AudioManager>();

            return instance;
        }
    }

    [SerializeField] List<AudioClip> clips = new List<AudioClip>();
    private Dictionary<string, AudioClip> clipPool = new Dictionary<string, AudioClip>();

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource systemPlayer = null;

    private void Awake()
    {
        foreach (AudioClip clip in clips)
            CreateAudioPool(clip);
    }

    public void PlayBGM(string clipName) => PlayAudio(clipName, bgmPlayer);
    public void PauseBGM() => bgmPlayer.Pause();
    public void PlaySystem(string clipName) => PlayAudio(clipName, systemPlayer);
    public void PauseSystem() => systemPlayer.Pause();

    public void PlayAudio(string clipName, AudioSource player)
    {
        if (!clipPool.ContainsKey(clipName))
        {
            Debug.LogWarning("Current name of auido clip doesnt exist");
            return;
        }

        player.clip = clipPool[clipName];

        player.Play();
    }

    private void CreateAudioPool(AudioClip clip)
    {
        if (clipPool.ContainsKey(clip.name))
        {
            Debug.LogWarning("Current name of audio clip is already exist");
            return;
        }

        clipPool.Add(clip.name, clip);
    }
}