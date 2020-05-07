using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyIfSold : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI self;
    TextMeshPro textmeshPro;

    GameObject gameData;
    GameData game_data;

    float possibleSell;
    float netDifference;


    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        possibleSell = game_data.Stock1.price * game_data.Stock1.sharesOwned;
        netDifference = possibleSell - game_data.Stock1.pricePaidForShares;
        if (netDifference >= 0)
        {
            self.text = "$" + netDifference.ToString("#.00");
            self.color = new Color32(0, 255, 0, 255);
        } else
        {
            self.text = "-" + "$" +  Mathf.Abs(netDifference).ToString("#.00");
            self.color = new Color32(255, 0, 0, 255);
        }

       
    }
}
