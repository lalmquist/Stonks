using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValueInputBox : MonoBehaviour
{
    [SerializeField] public TMP_InputField textMesh;

    decimal decNumber;

    public CanvasGroup warningText;
    public decimal outputValue;

    public bool InputError;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        decimal.TryParse(textMesh.text, out decNumber);

        if (decNumber <= 0)
        {
            InputError = true;
            warningText.alpha = 1;
            warningText.interactable = true;
        }
        else
        {
            InputError = false;
            warningText.alpha = 0;
            warningText.interactable = false;
        }

        outputValue = decNumber;
    }
}
