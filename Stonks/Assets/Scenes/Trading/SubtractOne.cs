using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtractOne : MonoBehaviour
{
    int value = 0;
    [SerializeField] TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void execute()
    {
        int.TryParse(valueText.text, out value);
        if (value > 0)
        {
            value = value - 1;
            valueText.text = value.ToString();
        }
    }
}
