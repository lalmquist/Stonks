using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleBuys : MonoBehaviour
{

    GameObject gameData;
    GameData game_data;

    [SerializeField] public BuyButton Buy1;
    [SerializeField] public BuyButton Buy2;

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

    }

    public void UpdateStore(float price)
    {
        game_data.store.quantityButton = Buy1.buyBool;
        game_data.store.sellAll = Buy2.buyBool;
        game_data.playerMoney = game_data.playerMoney + price;
    }

}
