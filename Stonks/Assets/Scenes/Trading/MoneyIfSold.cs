using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyIfSold : MonoBehaviour
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
        possibleSell = game_data.Stock1.price * game_data.Stock1.sharesOwned;
        netDifference = possibleSell - game_data.Stock1.pricePaidForShares;
        if (netDifference > 0)
        {
            textMesh.text = "$" + netDifference.ToString("n2");
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else if (netDifference == 0)
        {
            textMesh.text = "$0.00";
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else
        {
            textMesh.text = "-" + "$" + Mathf.Abs(netDifference).ToString("n2");
            textMesh.color = new Color32(255, 0, 0, 255);
        }

        if (game_data.Stock1.sharesOwned == 0)
        {
            textMesh.text = "";
        }

       
    }
}
