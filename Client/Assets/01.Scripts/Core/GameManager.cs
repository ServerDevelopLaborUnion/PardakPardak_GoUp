using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null)
            return;

        instance = this;
    }

    private void Start()
    {
        Vector2Int resolution = DataManager.Instance.userSetting.resolution;
        Screen.SetResolution(resolution.x, resolution.y, true);
        foreach(CanvasScaler scaler in FindObjectsOfType<CanvasScaler>())
        {
            scaler.referenceResolution = resolution;
        }
    }
}
