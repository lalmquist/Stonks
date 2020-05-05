using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockPrice : MonoBehaviour
{
    float interval;
    float stock_price = 0;

    [SerializeField] float stockUpdateTimer;
    [SerializeField] TextMeshProUGUI stockPrice;
    [SerializeField] float priceVariation = 10f;


    // Start is called before the first frame update
    void Start()
    {
        stockPrice.text = "145";
        interval = stockUpdateTimer;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (interval <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        float.TryParse(stockPrice.text, out stock_price);
        stock_price = stock_price + Random.Range(-priceVariation, priceVariation);

        stockPrice.text = stock_price.ToString("#.00");

        interval = stockUpdateTimer;

    }
}