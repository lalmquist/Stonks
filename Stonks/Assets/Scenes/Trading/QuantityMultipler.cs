using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuantityMultipler : MonoBehaviour
{
    public int multiplier;

    TextMeshProUGUI textMesh;
    int toggle = 0;

    GameObject gameData;
    GameData game_data;

    [SerializeField] public Image button;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        toggle = 0;
        textMesh.text = "x1";
    }

    // Update is called once per frame
    void Update()
    {
        if (game_data.store.quantityButton == true)
        {
            button.color = new Color32(255, 255, 255, 255);
            textMesh.color = new Color32(50, 50, 50, 255);
        }
        else
        {
            button.color = new Color32(0, 0, 0, 0);
            textMesh.color = new Color32(0, 0, 0, 0);
        }
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
            multiplier = 1;
        }
        else if (toggle == 1)
        {
            textMesh.text = "x10";
            multiplier = 10;
        }
        else if (toggle == 2)
        {
            textMesh.text = "x100";
            multiplier = 100;
        }
    }
}
