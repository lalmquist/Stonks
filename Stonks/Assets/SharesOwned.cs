using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SharesOwned : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    GameObject gameData;
    GameData game_data;

    float possibleSell;
    float netDifference;


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
        textMesh.text = game_data.Stock1.sharesOwned.ToString();

    }
}
