using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickZone : MonoBehaviour
{

    GameObject BonusMoneyObject;
    TextMeshProUGUI BonusMoneyTMP;

    GameObject gameData;
    GameData game_data;

    [SerializeField] public Streak streak;

    public bool inZone;
    
    [SerializeField] public Circle circle;
    [SerializeField] public ClickZone otherZone;

    double minSpeed;
    double maxSpeed;
    double speedChange;
    public decimal moneyBonus;

    double idleChange = 0.00025;

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
        minSpeed = 0.5;
        maxSpeed = 1.75;
        speedChange = 0.075;

        if (game_data.store.storeMultiplier < 1)
        {
            game_data.store.storeMultiplier = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (streak.streak > 0)
        {
            moneyBonus = (streak.streak * circle.multiplier * game_data.store.storeMultiplier / (decimal)minSpeed);
        }
        else
        {
            moneyBonus = 1 * (decimal)game_data.store.storeMultiplier;
        }
        
        circle.multiplier -= (decimal)idleChange;

        if (Input.GetMouseButtonDown(0))
        {
            if (inZone)
            {
                streak.streak += 1;
                circle.multiplier += (decimal)speedChange;
                game_data.playerMoney += (decimal)moneyBonus;
            }
            else if (inZone == false & otherZone.inZone == false)
            {
                circle.multiplier -= (decimal)speedChange;
                streak.streak = 0;
            }
        }


        // speed limits
        if (circle.multiplier < (decimal)minSpeed)
        {
            circle.multiplier = (decimal)minSpeed;
        }
        else if (circle.multiplier > (decimal)maxSpeed)
        {
            circle.multiplier = (decimal)maxSpeed;
        }

        BonusMoneyTMP.text = moneyBonus.ToString("n2");
    }
}
