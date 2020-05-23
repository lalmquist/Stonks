using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadingText : MonoBehaviour
{

    TextMeshProUGUI textMesh;
    float fadeTime = 2f;
    float interval;
    bool timerRunning;
    float math;
    float updateInterval = 0.1f;
    float updateTimer;
    float alpha = 255;
    float red;
    float green;
    float blue;
    float xMovement;
    float yMovement;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        interval = fadeTime;
        textMesh.color = new Color32(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            transform.Translate(xMovement * Time.deltaTime, yMovement * Time.deltaTime, 0);
            updateTimer += Time.deltaTime;
            interval -= Time.deltaTime;

            if (updateTimer >= updateInterval)
            {
                alpha = alpha - math;
                textMesh.color = new Color32((byte)red, (byte)green, (byte)blue, (byte)alpha);
                updateTimer = 0f;
            }
        }
        else
        {
            math = (255 / (fadeTime * 10));
        }

        if (interval <= 0.0f)
        {
            timerRunning = false;
            textMesh.color = new Color32(0, 0, 0, 0);
            interval = fadeTime;
        }
    }

    public void FadeRed(string arg)
    {
        timerRunning = true;
        alpha = 255;

        red = 255;
        green = 0;
        blue = 0;

        xMovement = 1f;
        yMovement = -4f;

        transform.position = new Vector3(161, 550, 0);
        textMesh.text = "$" + arg;
    }

    public void FadeGreen(string arg)
    {
        timerRunning = true;
        alpha = 255;

        red = 0;
        green = 255;
        blue = 0;

        xMovement = 1f;
        yMovement = 4f;

        transform.position = new Vector3(161, 550, 0);
        textMesh.text = "$" + arg;
    }
}
