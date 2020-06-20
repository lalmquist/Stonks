using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] public Circle circle;
    [SerializeField] public Image fill;
    public Slider slider;
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = circle.multiplier;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
