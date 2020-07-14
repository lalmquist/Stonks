using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class zMoneyBoxMotion : MonoBehaviour
{ 
    float speed = 100.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    bool inZone;
    float minSpeed;
    float maxSpeed;
    float speedChange;


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

        if (Input.GetMouseButtonDown(0))
        {
            if (inZone)
            {
                Destroy(this.gameObject);
            }
        }
    } 
}