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
        speedChange = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (streak.streak > 0)
        {
            moneyBonus = (streak.streak * circle.multiplier / minSpeed);
        }
        else
        {
            moneyBonus = 1;
        }
        
        circle.multiplier -= 0.00025f;

        if (Input.GetMouseButtonDown(0))
        {
            if (inZone)
            {
                streak.streak += 1;
                circle.multiplier += speedChange;
                game_data.playerMoney += moneyBonus;
            }
            else if (inZone == false & otherZone.inZone == false)
            {
                circle.multiplier -= speedChange;
                streak.streak = 0;
            }
        }


        // speed limits
        if (circle.multiplier < minSpeed)
        {
            circle.multiplier = minSpeed;
        }
        else if (circle.multiplier > maxSpeed)
        {
            circle.multiplier = maxSpeed;
        }

        BonusMoneyTMP.text = moneyBonus.ToString("n2");
    }
}
