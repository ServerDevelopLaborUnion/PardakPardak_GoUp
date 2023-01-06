using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class Ending : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] CinemachineVirtualCamera firstCm;
    [SerializeField] CinemachineVirtualCamera secondCm;
    [SerializeField] Button Restart;
    [SerializeField] Button GotoMenu;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource fishSource;
    public void Doma(){
        AudioManager.Instance.PlayAudio("찰박",fishSource);
    }
    public void StartEnding(){
        StartCoroutine(ShowEnding());
    }
    IEnumerator ShowEnding(){
        image.color = Color.black;
        firstCm.Priority = 0;
        secondCm.Priority = 10;
        AudioManager.Instance.PlayAudio("칼소리",fishSource);
        yield return new WaitForSeconds(2.5f);
        AudioManager.Instance.PlayAudio("보글보글",fishSource);
        AudioManager.Instance.PlayAudio("EndingBGM",BGM);
        yield return new WaitForSeconds(1f);
        Sequence seq = DOTween.Sequence();
        seq.Append(image.DOFade(0,4f));
        seq.Join(secondCm.transform.DOMove(secondCm.transform.position+ secondCm.transform.forward * -1.4f,4f));
        yield return new WaitForSeconds(4f);
        text.DOFade(1,1f);
        yield return new WaitForSeconds(1f);
        Restart.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        GotoMenu.gameObject.SetActive(true);
        seq.Kill();
    }
    public void BtnEvet(string name){

        SceneLoader.Instance.LoadAsync(name);
    }
}
