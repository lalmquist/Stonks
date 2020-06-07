using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValueInputBox : MonoBehaviour
{
    [SerializeField] public TMP_InputField textMesh;

    float floatNumber;

    public CanvasGroup warningText;
    public float outputValue;

    public bool InputError;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float.TryParse(textMesh.text, out floatNumber);

        if (floatNumber <= 0f)
        {
            InputError = true;
            warningText.alpha = 1f;
            warningText.interactable = true;
        }
        else
        {
            InputError = false;
            warningText.alpha = 0f;
            warningText.interactable = false;
        }

        outputValue = floatNumber;
    }
}
