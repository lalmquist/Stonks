using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MoneyBoxCollide : MonoBehaviour
{

    GameObject BonusMoneyObject;
    TextMeshProUGUI BonusMoneyTMP;

    GameObject gameData;
    GameData game_data;

    [SerializeField] public Streak streak;

    public bool inZone;

    [SerializeField] public float multiplier;

    float minSpeed;
    float maxSpeed;
    float speedChange;
    public float moneyBonus;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        inZone = true;

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        inZone = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        BonusMoneyObject = GameObject.Find("BonusMoney");
        BonusMoneyTMP = BonusMoneyObject.GetComponent<TextMeshProUGUI>();

        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        minSpeed = 0.5f;
        maxSpeed = 1.75f;
        speedChange = 0.065f;
        multiplier = 0f;

        if (game_data.store.storeMultiplier < 1f)
        {
            game_data.store.storeMultiplier = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (game_data.store.doubleMoneyPrinter)
        {
            game_data.store.storeMultiplier = 2f;
        }
        else
        {
            game_data.store.storeMultiplier = 1f;
        }

        if (streak.streak > 0)
        {
            moneyBonus = ((streak.streak / 2) * (multiplier / 2) * game_data.store.storeMultiplier / minSpeed);
            if (moneyBonus < game_data.store.storeMultiplier)
            {
                moneyBonus = game_data.store.storeMultiplier;
            }
        }
        else
        {
            moneyBonus = game_data.store.storeMultiplier;
        }

        multiplier -= 0.00002f;

        if (Input.GetMouseButtonDown(0))
        {
            if (inZone)
            {
                streak.streak += 1;
                multiplier += speedChange;
                game_data.playerMoney += moneyBonus;
            }
            else if (inZone == false)
            {
                multiplier -= (speedChange * 2);
                streak.streak = 0;
            }
        }


        // speed limits
        if (multiplier < minSpeed)
        {
            multiplier = minSpeed;
        }
        else if (multiplier > maxSpeed)
        {
            multiplier = maxSpeed;
        }

        BonusMoneyTMP.text = moneyBonus.ToString("n2");
    }
}
