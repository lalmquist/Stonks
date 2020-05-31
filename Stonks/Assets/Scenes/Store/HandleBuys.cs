using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleBuys : MonoBehaviour
{

    GameObject gameData;
    GameData game_data;

    [SerializeField] BuyButton Buy1;

    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        Buy1.buyBool = game_data.store.quantityButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            game_data.store.quantityButton = Buy1.buyBool;
        }

        done = true;
    }
}
