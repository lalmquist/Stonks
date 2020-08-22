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

    public Animator animator;

    [SerializeField] public Streak streak;

    public bool inZone;

    [SerializeField] public deployMoneyBox deploy;

    public float conveyorSpeed = 100.0f;

    float minSpeed;
    float maxSpeed;
    float speedChange;
    public float moneyBonus;

    float minRespawn = 5f;
    float maxRespawn = 0.4f;

    string ColliderName;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        inZone = true;
        ColliderName = collider.name;

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
        minSpeed = 50f;
        maxSpeed = 600f;

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
            moneyBonus = ((streak.streak / 2) * game_data.store.storeMultiplier);
            if (moneyBonus < game_data.store.storeMultiplier)
            {
                moneyBonus = game_data.store.storeMultiplier;
            }
        }
        else
        {
            moneyBonus = game_data.store.storeMultiplier;
        }

        animator.SetBool("Print", false);

        if (Input.GetMouseButtonDown(0))
        {

            if (inZone)
            {

                if (ColliderName == "BombBox(Clone)")
                {
                    streak.streak = 0;
                    conveyorSpeed = minSpeed;
                    deploy.respawnTime = minRespawn/2;
                }
                else
                {
                    streak.streak += 1;
                    game_data.playerMoney += moneyBonus;
                    animator.SetBool("Print", true);
                    conveyorSpeed += 10f;
                    deploy.respawnTime -= 0.3f;
                }

            }
            else if (inZone == false)
            {
                streak.streak = 0;
                conveyorSpeed -= 50f;
                deploy.respawnTime += 0.2f;
            }

        }

        // speed limits
        if (conveyorSpeed < minSpeed)
        {
            conveyorSpeed = minSpeed;
        }
        else if (conveyorSpeed > maxSpeed)
        {
            conveyorSpeed = maxSpeed;
        }

        // respawn limits
        if (deploy.respawnTime > minRespawn)
        {
            deploy.respawnTime = minRespawn;
        }
        else if (deploy.respawnTime < maxRespawn)
        {
            deploy.respawnTime = maxRespawn;
        }

        BonusMoneyTMP.text = moneyBonus.ToString("n2");
    }
}
