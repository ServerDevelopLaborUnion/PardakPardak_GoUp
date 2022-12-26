using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolution;

    public void StartGame() 
    {
        SceneLoader.Instance.LoadAsync("Player", () => {
            
        });
    }

    public void ChangeResolution(int idx)
    {
        Vector2Int resolution = GetResolutionValue(_resolution.options[idx].text);
        Screen.SetResolution(resolution.x, resolution.y, true);
        foreach(CanvasScaler scaler in FindObjectsOfType<CanvasScaler>())
        {
            scaler.referenceResolution = resolution;
        }
        DataManager.Instance.userSetting.resolution = resolution;
    }

    private Vector2Int GetResolutionValue(string value)
    {
        string[] splited = value.Split(")")[0].Split("(")[1].Split("x",StringSplitOptions.RemoveEmptyEntries);
        return new Vector2Int(int.Parse(splited[0]), int.Parse(splited[1]));
    }
}
