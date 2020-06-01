using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtractOne : MonoBehaviour
{
    public int multiplier = 1;
    int value = 0;
    [SerializeField] public TextMeshProUGUI valueText;

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
        if (value - (1 * multiplier) >= 0)
        {
            value = value - (1*multiplier);
            valueText.text = value.ToString();
        }
        else
        {
            value = 0;
            valueText.text = value.ToString();
        }
    }
}
