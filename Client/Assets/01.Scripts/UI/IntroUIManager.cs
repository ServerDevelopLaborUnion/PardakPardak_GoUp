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

    [SerializeField] private TextMeshProUGUI _stopCancelTxt;
    [SerializeField] private string[] _cTexts;

    private int _cancelCnt = 0;

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
        _cancelCnt++;

        if(_cancelCnt % 3 == 0) 
        {
            _stopCancelTxt.text = _cTexts[(_cancelCnt / 3 - 1) < _cTexts.Length - 1 ? _cancelCnt/3 - 1 : _cTexts.Length - 1];
            Sequence seq = DOTween.Sequence();
            seq.Append(_stopCancelTxt.DOFade(1, 0.45f));
            seq.Append(_stopCancelTxt.DOFade(0, 0.1f));
        }
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
