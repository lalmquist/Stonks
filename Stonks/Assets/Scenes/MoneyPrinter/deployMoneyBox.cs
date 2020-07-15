﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployMoneyBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moneyBoxPrefab;
    public GameObject bombPrefab;
    public GameObject canvasParent;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;
    int rand;
    

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(moneyBoxSpawn());
    }

    private void spawnBox()
    {
        GameObject a = Instantiate(moneyBoxPrefab) as GameObject;
        a.transform.SetParent(canvasParent.transform, false);
        a.transform.position = new Vector2(-145, 375);
    }

    private void spawnBomb()
    {
        GameObject a = Instantiate(bombPrefab) as GameObject;
        a.transform.SetParent(canvasParent.transform, false);
        a.transform.position = new Vector2(-145, 375);
    }

    IEnumerator moneyBoxSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            rand = Random.Range(1, 100);

            if (rand < 25)
            {
                spawnBomb();
            } else
            {
                spawnBox();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
