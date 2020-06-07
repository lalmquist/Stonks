using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockInputBox : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    GameObject gameData;
    GameData game_data;

    public CanvasGroup warningText;
    public string outputValue;

    public bool InputError;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {

        if (textMesh.text.Length != 5)
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

        outputValue = textMesh.text;
    }
}
