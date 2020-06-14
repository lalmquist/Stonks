using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Circle : MonoBehaviour
{

    GameObject speedObject;
    TextMeshProUGUI speedTMP;

    float angle = 0;
    float speed = (2 * Mathf.PI) / 1; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    [SerializeField] float radius = 150;
    float x;
    float y;
    public float multiplier = 0f;

    [SerializeField] float startX = 100;
    [SerializeField] float startY = 100;

    // Start is called before the first frame update
    void Start()
    {
        speedObject = GameObject.Find("Speed");
        speedTMP = speedObject.GetComponent<TextMeshProUGUI>();

        transform.position = new Vector3(startX, startY, 0);
        radius = 150;
    }

    // Update is called once per frame
    void Update()
    {
        angle = angle + (speed * Time.deltaTime * multiplier); //if you want to switch direction, use -= instead of +=
        x = Mathf.Cos(angle) * radius;
        y = Mathf.Sin(angle) * radius;

        //transform.position = new Vector3(x * Time.deltaTime * multiplier, y * Time.deltaTime * multiplier, 0);
        transform.position = new Vector3(x + startX, y + startY, 0);

        speedTMP.text = "Speed : " + multiplier.ToString("n2");
    }
}