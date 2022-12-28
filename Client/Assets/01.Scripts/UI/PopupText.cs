using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    [SerializeField] List<Desition> decisiones = new List<Desition>();
    [SerializeField] string message;
    private void Update() 
    {
        bool value = false;
        decisiones.ForEach(a => {
            value |= a.ReturnDesition();
            if(!value)
                return;
            UIManager.Instance.SetText(message);
        });
    }
}
