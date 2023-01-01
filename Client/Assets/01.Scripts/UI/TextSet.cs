using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSet : MonoBehaviour
{   
    public TextMeshPro panelText;
    
    [TextArea]
    public string infoText = "";

   private void OnCollisionStay(Collision other) {
       
        panelText.text = infoText;
   }
    
}
