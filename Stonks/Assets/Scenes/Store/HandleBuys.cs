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
    [SerializeField] public BuyButton Buy3;
    [SerializeField] public IPOBuyButton Buy4;
    [SerializeField] public IPOBuyButton Buy5;
    [SerializeField] public IPOBuyButton Buy6;
    [SerializeField] public BuyButton Buy7;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();

        Buy1.buyBool = game_data.store.quantityButton;
        Buy2.buyBool = game_data.store.sellAll;
        Buy3.buyBool = game_data.store.buyAll;
        Buy4.buyBool = game_data.store.unlockStock2;
        Buy5.buyBool = game_data.store.unlockStock3;
        Buy6.buyBool = game_data.store.unlockStock4;
        Buy7.buyBool = game_data.store.doubleMoneyPrinter;

        Buy1.price = 1000f;
        Buy2.price = 2000f;
        Buy3.price = 3000f;
        Buy4.price = 10000f;
        Buy5.price = 15000f;
        Buy6.price = 20000f;
        Buy7.price = 50000f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateStore(float price)
    {
        game_data.store.quantityButton = Buy1.buyBool;
        game_data.store.sellAll = Buy2.buyBool;
        game_data.store.buyAll = Buy3.buyBool;

        game_data.store.doubleMoneyPrinter = Buy7.buyBool;

        game_data.playerMoney = game_data.playerMoney - price;
    }

}
