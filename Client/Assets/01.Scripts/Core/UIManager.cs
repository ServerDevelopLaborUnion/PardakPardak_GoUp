using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager:MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    [SerializeField]
    private TextMeshProUGUI txt;
    bool changeTxt= false;
    float timer = 0;
    Material txtmat;
    private void Start() {
        txtmat = new Material(txt.fontSharedMaterial);
        txt.fontMaterial = txtmat;
    }
    private void Update() {
        if(changeTxt){
            timer += Time.deltaTime;
            txtmat.SetFloat(ShaderUtilities.ID_FaceDilate, Mathf.Lerp(-1f,0,timer*2));
            Debug.Log( Mathf.Lerp(-1f,0,timer*2));
            if(timer>2.3f){
                txt.text = "";
                timer = 0;
                changeTxt = false;
                txtmat.SetFloat(ShaderUtilities.ID_FaceDilate,-1);
            }
        }
    }

    
    public void SetText(string msg){
        if(changeTxt) return;
        txt.text = msg;
        changeTxt = true;
    }

}
