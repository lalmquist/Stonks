using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxBuyPossible : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    int maxbuy_int;
    float maxbuy_float;

    TextMeshProUGUI textMesh;

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
        maxbuy_float = game_data.playerMoney / game_data.Stock1.price;

        maxbuy_int = Mathf.FloorToInt(maxbuy_float);

        textMesh.text = maxbuy_int.ToString();
    }
}
