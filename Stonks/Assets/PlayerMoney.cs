﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney.text = "1000";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
