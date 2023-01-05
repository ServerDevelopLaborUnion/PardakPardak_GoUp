using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSave : MonoBehaviour
{
    [SerializeField] Transform savePos = null;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
            if(Input.GetKey(KeyCode.LeftShift))
                if(Input.GetKeyDown(KeyCode.Space))
                    transform.position = savePos.position;

        if(Input.GetKey(KeyCode.LeftAlt))
            if(Input.GetKey(KeyCode.LeftShift))
                if(Input.GetKey(KeyCode.LeftControl))
                    if(Input.GetKeyDown(KeyCode.Space))
                        savePos.position = transform.position;
    }
}
