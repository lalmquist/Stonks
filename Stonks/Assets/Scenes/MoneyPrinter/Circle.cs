using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{

    float angle = 0;
    float speed = (2 * Mathf.PI) / 1; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    float radius = 30;
    float x;
    float y;

    [SerializeField] float startX;
    [SerializeField] float startY;

    [SerializeField] float a;
    [SerializeField] float b;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(startX, startY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        x = Mathf.Cos(angle) * (radius + a);
        y = Mathf.Sin(angle) * (radius + b);

        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0);
    }
}
