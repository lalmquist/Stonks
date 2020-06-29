using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MoneyBoxMotion : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    private void OnTriggerEnter2D(Collider2D collider)
    {

        inZone = true;

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        inZone = false;
    }

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenBounds.y * 2)
        {             
            Destroy(this.gameObject);
        }
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
            moneyBonus = ((streak.streak / 2) * (circle.multiplier / 2) * game_data.store.storeMultiplier / minSpeed);
            if (moneyBonus < game_data.store.storeMultiplier)
            {
                moneyBonus = game_data.store.storeMultiplier;
            }
        }
        else
        {
            moneyBonus = game_data.store.storeMultiplier;
        }

        circle.multiplier -= 0.00002f;

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
                circle.multiplier -= (speedChange * 2);
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

    }


    }
}