﻿using System.Collections;
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
    [SerializeField] public BuyButton Buy4;
    [SerializeField] public BuyButton Buy5;
    [SerializeField] public BuyButton Buy6;

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

        Buy1.price = 1000f;
        Buy2.price = 250f;
        Buy3.price = 420f;
        Buy4.price = 1f;
        Buy5.price = 1f;
        Buy6.price = 1f;
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
        game_data.store.unlockStock2 = Buy4.buyBool;
        game_data.store.unlockStock3 = Buy5.buyBool;
        game_data.store.unlockStock4 = Buy6.buyBool;

        game_data.playerMoney = game_data.playerMoney - price;
    }

}
