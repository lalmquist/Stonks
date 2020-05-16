using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantityMultipler : MonoBehaviour
{

    TextMeshProUGUI textMesh;
    int toggle = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void click()
    {
        if (toggle < 2)
        {
            toggle += 1;
        }
        else
        {
            toggle = 0;
        }

        if (toggle == 0)
        {
            textMesh.text = "x1";
        }
        else if (toggle == 1)
        {
            textMesh.text = "x10";
        }
        else if (toggle == 2)
        {
            textMesh.text = "x100";
        }
    }
}
