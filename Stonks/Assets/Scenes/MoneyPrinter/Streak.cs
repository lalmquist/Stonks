using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Streak : MonoBehaviour
{

    public int streak;
    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (streak > 0)
        {
            textMesh.text = "Streak : x" + streak.ToString();
        }
        else
        {
            textMesh.text = "";
        }

    }
}
