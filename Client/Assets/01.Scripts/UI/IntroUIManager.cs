using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolution;

    [SerializeField] private RectTransform _title, _touchToStart, _btns;
    [SerializeField] private Animator _fishAnimator;

    public void LoadGame() 
    {
        SceneLoader.Instance.LoadAsync("Tutorial");
    }

    public void StartGame()
    {
        _title.DOAnchorPosY(0 + _title.rect.height, 0.4f);
        _btns.DOAnchorPosY(0 + _btns.rect.height, 0.4f);
        _touchToStart.DOAnchorPosY(0 - _touchToStart.rect.height, 0.4f);
        _fishAnimator.SetTrigger("Start");
        return;
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
