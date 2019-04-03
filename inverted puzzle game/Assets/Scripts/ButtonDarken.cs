using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDarken : MonoBehaviour
{
    Renderer buttonRend;

    // Start is called before the first frame update
    void Start()
    {
        buttonRend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchAction.darken == true)
        {
            buttonRend.material.color = Color.gray;
        }

        else
        {
            buttonRend.material.color = Color.white;
        }
    }
}
