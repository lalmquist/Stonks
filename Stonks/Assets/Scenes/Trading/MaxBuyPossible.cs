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

    public float price;

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

        maxbuy_float = game_data.playerMoney / price;

        maxbuy_int = Mathf.FloorToInt(maxbuy_float);

        if (price == 0)
        {
            maxbuy_int = 0;
        }

        textMesh.text = maxbuy_int.ToString("#,#");
    }
}
