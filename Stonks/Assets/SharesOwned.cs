using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SharesOwned : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI self;

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
        self.text = game_data.Stock1.sharesOwned.ToString();

    }
}
